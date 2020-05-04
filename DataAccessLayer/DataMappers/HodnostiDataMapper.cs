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

        //SelectAll 7.4
        public List<Hodnosti> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT hid, nazev, minimalni_vek FROM Hodnosti");

                List<Hodnosti> data = new List<Hodnosti>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new Hodnosti(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }
                reader.Close();
                return data;
            }
        }

        public Hodnosti SelectById(int hid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT hid, nazev, minimalni_vek FROM Hodnosti WHERE hid = :hid AND rownum = 1");

                command.Parameters.AddWithValue(":hid", hid);

                Hodnosti data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data = new Hodnosti(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                }
                reader.Close();
                return data;
            }
        }

        //INSERT 7.1
        public void Insert(Hodnosti hodnosti)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("INSERT INTO Hodnosti (hid, Nazev, minimalni_vek) VALUES (:hid, :Nazev, :minimalni_vek)");
                command.Parameters.AddWithValue(":hid", hodnosti.Hid);
                command.Parameters.AddWithValue(":Nazev", hodnosti.Nazev);
                command.Parameters.AddWithValue(":minimalni_vek", hodnosti.Minimalni_vek);

                command.ExecuteNonQuery();
            }
        }

        //UPDATE 7.3
        public void Update(Hodnosti hodnosti)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("UPDATE Hodnosti SET Nazev = :Nazev, minimalni_vek = :minimalni_vek WHERE hid = :hid");
                command.Parameters.AddWithValue(":hid", hodnosti.Hid);
                command.Parameters.AddWithValue(":Nazev", hodnosti.Nazev);
                command.Parameters.AddWithValue(":minimalni_vek", hodnosti.Minimalni_vek);

                command.ExecuteNonQuery();
            }
        }

        //DELETE NOT USED! 7.2

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
                        string line = v.Hid + ", " + v.Nazev + ", " + v.Minimalni_vek;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }

            }
        }
    }
}

