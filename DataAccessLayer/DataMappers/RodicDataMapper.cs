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
    public class RodicDataMapper
    {
        private Database db;

        public RodicDataMapper()
        {
            db = new Database();
        }


        public List<Rodic> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT rid, jmeno, login, heslo, kontakt FROM Rodic");

                List<Rodic> data = new List<Rodic>();

                var reader = command.ExecuteReader();

                DetiDataMapper ddm = new DetiDataMapper();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data.Add(new Rodic(id, reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                }
                reader.Close();
                return data;
            }
        }

        public Rodic SelectById(int rid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT rid, jmeno, login, heslo, kontakt FROM Rodic WHERE rid = :rid AND rownum = 1");

                command.Parameters.AddWithValue(":rid", rid);

                Rodic data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data = new Rodic(id, reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                }
                reader.Close();
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(Rodic rodic)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("SELECT rid, jmeno, login, heslo, kontakt FROM Rodic WHERE rid = :rid AND rownum = 1");

                command.Parameters.AddWithValue(":rid", rodic.Rid);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    OracleCommand commandUpdate = db.CreateCommand("UPDATE Rodic SET jmeno = :jmeno , login = :login , heslo = :heslo , kontakt= :kontakt WHERE rid = :rid");
                    commandUpdate.Parameters.AddWithValue(":rid", rodic.Rid);
                    commandUpdate.Parameters.AddWithValue(":jmeno", rodic.Jmeno);
                    commandUpdate.Parameters.AddWithValue(":login", rodic.Login);
                    commandUpdate.Parameters.AddWithValue(":heslo", rodic.Heslo);
                    commandUpdate.Parameters.AddWithValue(":kontakt", rodic.Kontakt);
                    Console.WriteLine(rodic.Rid + rodic.Jmeno + rodic.Login + rodic.Heslo + rodic.Kontakt);
                    commandUpdate.ExecuteNonQuery();
                }
                else
                {
                    OracleCommand commandInsert = db.CreateCommand("INSERT INTO Rodic (rid, jmeno, login, heslo, kontakt) VALUES (:rid, :jmeno, :login, :heslo, :kontakt)");
                    commandInsert.Parameters.AddWithValue(":rid", rodic.Rid);
                    commandInsert.Parameters.AddWithValue(":jmeno", rodic.Jmeno);
                    commandInsert.Parameters.AddWithValue(":login", rodic.Login);
                    commandInsert.Parameters.AddWithValue(":heslo", rodic.Heslo);
                    commandInsert.Parameters.AddWithValue(":kontakt", rodic.Kontakt);
                    Console.WriteLine(rodic.Rid + rodic.Jmeno + rodic.Login + rodic.Heslo + rodic.Kontakt);
                    commandInsert.ExecuteNonQuery();
                }
            }
        }

        //REMOVE FROM
        public void Delete(Rodic rodic)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Rodic WHERE rid = :rid");
                command.Parameters.AddWithValue(":rid", rodic.Rid);

                command.ExecuteNonQuery();
            }
        }

        public void ExportToCSV(string path)
        {
            using (db.GetConnection())
            {
                db.Connect();
                using (var w = new StreamWriter(path))
                {
                    List<Rodic> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        Rodic v = toCSV[i];
                        string line = v.Rid + ", " + v.Jmeno + ", " + v.Login + ", " + v.Heslo + ", " + v.Kontakt;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
            }
        }
    }
}
