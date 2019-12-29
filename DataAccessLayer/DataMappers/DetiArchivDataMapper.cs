using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DTO;

namespace VIS_Desktop.DataAccessLayer.DataMappers
{
    public class DetiArchivDataMapper
    {
        private Database db;

        public DetiArchivDataMapper()
        {
            db = new Database();
        }


        public List<DetiArchiv> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM DetiArchiv");

                List<DetiArchiv> data = new List<DetiArchiv>();

                var reader = command.ExecuteReader();

                DetiDataMapper ddm = new DetiDataMapper();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data.Add(new DetiArchiv(id, reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), ddm.SelectById(id)));
                }
                return data;
            }
        }

        public DetiArchiv SelectById(int did)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM DetiArchiv WHERE did = :did AND rownum = 1");

                command.Parameters.AddWithValue(":did", did);

                DetiArchiv data = null;

                var reader = command.ExecuteReader();

                DetiDataMapper ddm = new DetiDataMapper();

                while (reader.Read())
                {
                    data = new DetiArchiv(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), ddm.SelectById(did));
                }
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(DetiArchiv detiArchiv)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("SELECT * FROM DetiArchiv WHERE did = :did AND rownum = 1");

                command.Parameters.AddWithValue(":did", detiArchiv.did);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    command.CommandText = "UPDATE DetiArchiv SET Jmeno = :Jmeno, DatumN = :DatumN, kontaktNR = :kontaktNR, archivD=:archivD WHERE did = :did";
                }
                else
                {
                    command.CommandText = "INSERT INTO DetiArchiv (did, Jmeno, DatumN, kontaktNR, archivD) VALUES (:did, :Jmeno, :DatumN, :kontaktNR, :archivD)";
                }
                command.Parameters.AddWithValue(":did", detiArchiv.did);
                command.Parameters.AddWithValue(":Jmeno", detiArchiv.Jmeno);
                command.Parameters.AddWithValue(":DatumN", detiArchiv.DatumN);
                command.Parameters.AddWithValue(":kontaktNR", detiArchiv.kontaktNR);
                command.Parameters.AddWithValue(":archivD", detiArchiv.archivD.did);

                command.ExecuteNonQuery();

            }
        }

        //REMOVE FROM
        public void Delete(DetiArchiv detiArchiv)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM DetiArchiv WHERE ID = :ID");
                command.Parameters.AddWithValue(":ID", detiArchiv.did);


            }
        }

        public void ExportToCSV(string path)
        {
            using (db.GetConnection())
            {
                db.Connect();
                using (var w = new StreamWriter(path))
                {
                    List<DetiArchiv> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        DetiArchiv v = toCSV[i];
                        string line = v.did + ", " + v.Jmeno + ", " + v.DatumN + ", " + v.kontaktNR + ", " + v.archivD.did;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
            }
        }
    }
}
