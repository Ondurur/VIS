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
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(Funkce Funkce)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand select = db.CreateCommand("SELECT fid, nazev,povinnosti FROM Funkce WHERE fid = :fid AND rownum = 1");

                select.Parameters.AddWithValue(":fid", Funkce.Fid);

                var reader = select.ExecuteReader();

                if (reader.HasRows)
                {
                    OracleCommand command = db.CreateCommand("UPDATE Funkce SET Nazev = :Nazev, Povinnosti = :Povinnosti WHERE fid = :fid");
                    command.Parameters.AddWithValue(":fid", Funkce.Fid);
                    command.Parameters.AddWithValue(":Nazev", Funkce.Nazev);
                    command.Parameters.AddWithValue(":Povinnosti", Funkce.Povinnosti);

                    command.ExecuteNonQuery();
                }
                else
                {
                    OracleCommand command = db.CreateCommand("INSERT INTO Funkce (fid, Nazev, Povinnosti) VALUES (:fid, :Nazev, :Povinnosti)");
                    command.Parameters.AddWithValue(":fid", Funkce.Fid);
                    command.Parameters.AddWithValue(":Nazev", Funkce.Nazev);
                    command.Parameters.AddWithValue(":Povinnosti", Funkce.Povinnosti);

                    command.ExecuteNonQuery();
                }

            }
        }

        //STORED PROCEDURE "NOVAFUNKCE"
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

        //REMOVE FROM
        public void Delete(Funkce Funkce)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Funkce WHERE fid = :ID");
                command.Parameters.AddWithValue(":ID", Funkce.Fid);

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

