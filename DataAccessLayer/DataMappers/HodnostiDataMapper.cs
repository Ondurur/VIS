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
    public class HodnostiDataMapper
    {
        private Database db;

        public HodnostiDataMapper()
        {
            db = new Database();
        }


        public List<Hodnosti> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM Hodnosti");

                List<Hodnosti> data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new Hodnosti(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }
                return data;
            }
        }

        public Hodnosti SelectById(int hid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM Hodnosti WHERE hid = :hid AND rownum = 1");

                command.Parameters.AddWithValue(":hid", hid);

                Hodnosti data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data = new Hodnosti(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                }
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(Hodnosti hodnosti)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("SELECT * FROM Hodnosti WHERE hid = :hid AND rownum = 1");

                command.Parameters.AddWithValue(":hid", hodnosti.hid);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    command.CommandText = "UPDATE Hodnosti SET Nazev = :Nazev, MinVek = :MinVek WHERE hid = :hid";
                }
                else
                {
                    command.CommandText = "INSERT INTO Hodnosti (hid, Nazev, MinVek) VALUES (:hid, :Nazev, :MinVek)";
                }
                command.Parameters.AddWithValue(":hid", hodnosti.hid);
                command.Parameters.AddWithValue(":Nazev", hodnosti.Nazev);
                command.Parameters.AddWithValue(":MinVek", hodnosti.MinVek);

                command.ExecuteNonQuery();

            }
        }

        //REMOVE FROM
        public void Delete(Hodnosti hodnosti)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Hodnosti WHERE ID = :ID");
                command.Parameters.AddWithValue(":ID", hodnosti.hid);


            }
        }

        public void ExportToCSV(string path)
        {
            using (db.GetConnection())
            {
                db.Connect();
                using (var w = new StreamWriter(path))
                {
                    List<Hodnosti> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        Hodnosti v = toCSV[i];
                        string line = v.hid + ", " + v.Nazev + ", " + v.MinVek;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }

            }
        }
    }
}

