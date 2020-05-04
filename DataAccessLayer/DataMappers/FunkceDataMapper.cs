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
    public class FunkceDataMapper
    {
        private Database db;

        public FunkceDataMapper()
        {
            db = new Database();
        }

        //SelectAll 4.4
        public List<Funkce> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT fid, nazev,povinnosti FROM Funkce");

                List<Funkce> data = new List<Funkce>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new Funkce(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
                reader.Close();
                return data;
            }
        }

        public Funkce SelectById(int? fid)
        {
            if(fid == null)
            {
                return null;
            }

            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT fid, nazev,povinnosti FROM Funkce WHERE fid = :fid AND rownum = 1");

                command.Parameters.AddWithValue(":fid", fid);

                Funkce data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data = new Funkce(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
                reader.Close();
                return data;
            }
        }

        //UPDATE 4.3
        public void Update(Funkce Funkce)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("UPDATE Funkce SET Nazev = :Nazev, Povinnosti = :Povinnosti WHERE fid = :fid");
                command.Parameters.AddWithValue(":fid", Funkce.Fid);
                command.Parameters.AddWithValue(":Nazev", Funkce.Nazev);
                command.Parameters.AddWithValue(":Povinnosti", Funkce.Povinnosti);

                command.ExecuteNonQuery();
            }
        }

        //STORED PROCEDURE "NOVAFUNKCE" 4.1
        public void NovaFunkce(string nazev, string povinnosti)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand execProcedure = db.CreateCommand("VYTVOR_FUNKCI");
                execProcedure.CommandType = System.Data.CommandType.StoredProcedure;
                execProcedure.Parameters.Add("p_nazev", OracleDbType.Varchar2).Value = nazev;
                execProcedure.Parameters.Add("p_povinnosti", OracleDbType.Varchar2).Value = povinnosti;

                execProcedure.ExecuteNonQuery();
            }
        }

        //DELETE NOT USED! 4.2

        public void ExportToCSV(string path)
        {
            using (db.GetConnection())
            {
                db.Connect();
                using (var w = new StreamWriter(path))
                {
                    List<Funkce> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        Funkce v = toCSV[i];
                        string line = v.Fid + ", " + v.Nazev + ", " + v.Povinnosti;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }

            }
        }
    }
}

