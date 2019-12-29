using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DataAccessLayer;
using VIS_Desktop.DTO;

namespace VIS_Desktop.DataAccessLayer.DataMappers
{
    public class VedouciDataMapper
    {
        private Database db;

        public VedouciDataMapper()
        {
            db = new Database();
        }
        
        public List<Vedouci> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT vid, jmeno, pw, datumN, kontakt FROM Vedouci");

                List<Vedouci> data = new List<Vedouci>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new Vedouci(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4)));                    
                }             

                return data;
            }
        }

        public Vedouci TryLogin(string username, string pw)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT vid, jmeno, pw, datumN, kontakt FROM Vedouci WHERE Jmeno = :nick AND Pw = :pw AND rownum = 1");

                command.Parameters.AddWithValue(":nick", username);
                command.Parameters.AddWithValue(":pw", pw);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string jmeno = reader.GetString(1);
                    string password = reader.GetString(2);
                    DateTime datumN = reader.GetDateTime(3);
                    string kontakt = reader.GetString(4);
                    return new Vedouci(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                }
                return null;
            }
        }

        public Vedouci SelectById(int vid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT vid, jmeno, pw, datumN, kontakt FROM Vedouci WHERE vid = :vid AND rownum = 1");

                command.Parameters.AddWithValue(":vid", vid);

                Vedouci data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data = new Vedouci(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                }
                return data;
            }
        }

        public Vedouci SelectByName(string name)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM Vedouci WHERE Jmeno = :jmeno AND rownum = 1");

                command.Parameters.AddWithValue(":jmeno", name);

                Vedouci data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data = new Vedouci(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                }
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(Vedouci vedouci)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("SELECT * FROM Vedouci WHERE vID = :ID AND rownum = 1");

                    command.Parameters.AddWithValue(":ID", vedouci.vid);

                    var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                        command.CommandText = "UPDATE Vedouci SET Jmeno = :Jmeno, pw = :pw, DatumN = :DatumN, Kontakt = :Kontakt WHERE vid = :vid";
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO Vedouci (vid, jmeno, pw, datumN, kontakt) VALUES (:vid, :Jmeno, :pw, :DatumN, :Kontakt)";
                    }
                    command.Parameters.AddWithValue(":vid", vedouci.vid);
                    command.Parameters.AddWithValue(":Jmeno", vedouci.Jmeno);
                    command.Parameters.AddWithValue(":pw", vedouci.Pw);
                    command.Parameters.AddWithValue(":DatumN", vedouci.DatumN);
                    command.Parameters.AddWithValue(":Kontakt", vedouci.Kontakt);

                    command.ExecuteNonQuery();
                
            }
        }

        //REMOVE FROM
        public void Delete(Vedouci vedouci)
        {
            using(db.GetConnection()){
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Vedouci WHERE ID = :ID");
                command.Parameters.AddWithValue(":ID", vedouci.vid);

                
            }
        }

        public void ExportToCSV(string path)
        {
            using (db.GetConnection())
            {
                db.Connect();
                using (var w = new StreamWriter(path))
                {
                    List<Vedouci> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        Vedouci v = toCSV[i];
                        string line = v.vid + ", " + v.Jmeno + ", " + v.Pw + ", " + v.DatumN + ", " + v.Kontakt;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
                
            }
        }
    }
} 