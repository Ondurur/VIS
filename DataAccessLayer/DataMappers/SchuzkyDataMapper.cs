using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DTO;

namespace VIS_Desktop.DataAccessLayer.DataMappers
{
    public class SchuzkyDataMapper
    {
        private Database db;
        VedouciDataMapper vdm;

        public SchuzkyDataMapper()
        {
            db = new Database();
            vdm = new VedouciDataMapper();
        }

        public List<Schuzky> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM Schuzky");

                List<Schuzky> data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data.Add(new Schuzky(id, reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), vdm.SelectById(id)));
                }
                return data;
            }
        }

        public Schuzky SelectById(int sid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM Schuzky WHERE sid = :sid AND rownum = 1");

                command.Parameters.AddWithValue(":sid", sid);

                Schuzky data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data = new Schuzky(id, reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), vdm.SelectById(id));
                }
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(Schuzky schuzky)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("SELECT * FROM Schuzky WHERE sid = :sid AND rownum = 1");

                command.Parameters.AddWithValue(":ID", schuzky.sid);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    command.CommandText = "UPDATE Schuzky SET Nazev = :Nazev, pocetD = :pocetD, DatumK = :DatumK, vedouciS = :vedouciS WHERE sid = :sid";
                }
                else
                {
                    command.CommandText = "INSERT INTO Schuzky (sid, Nazev, pocetD, DatumK, vedouciS) VALUES (:sid, :Nazev, :pocetD, :DatumK, :vedouciS)";
                }
                command.Parameters.AddWithValue(":sid", schuzky.sid);
                command.Parameters.AddWithValue(":Nazev", schuzky.Nazev);
                command.Parameters.AddWithValue(":pocetD", schuzky.PocetD);
                command.Parameters.AddWithValue(":DatumK", schuzky.DatumK);
                command.Parameters.AddWithValue(":vedouciS", schuzky.VedouciS);

                command.ExecuteNonQuery();

            }
        }

        //REMOVE FROM
        public void Delete(Schuzky schuzky)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Schuzky WHERE ID = :ID");
                command.Parameters.AddWithValue(":ID", schuzky.sid);


            }
        }

        public void ExportToCSV(string path)
        {
            using (db.GetConnection())
            {
                db.Connect();
                using (var w = new StreamWriter(path))
                {
                    List<Schuzky> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        Schuzky v = toCSV[i];
                        string line = v.sid + ", " + v.Nazev + ", " + v.PocetD + ", " + v.DatumK + ", " + v.VedouciS.vid;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }

            }
        }
    }
}
