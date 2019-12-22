using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
                OracleCommand command = db.CreateCommand("SELECT * FROM Vedouci");

                List<Vedouci> data = null;

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
                OracleCommand command = db.CreateCommand("SELECT TOP 1 * FROM Vedouci WHERE Jmeno = :nick AND Pw = :pw");

                command.Parameters.Add(":nick", username);
                command.Parameters.Add(":pw", pw);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
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
                OracleCommand command = db.CreateCommand("SELECT TOP 1 * FROM Vedouci WHERE vid = :vid");

                command.Parameters.Add(":vid", vid);

                Vedouci data = null;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
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
                OracleCommand command = db.CreateCommand("SELECT TOP 1 * FROM Vedouci WHERE Jmeno = :jmeno");

                command.Parameters.Add(":jmeno", name);

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

                OracleCommand command = db.CreateCommand("SELECT TOP 1 * FROM Vedouci WHERE vID = :ID");

                    command.Parameters.Add(":ID", vedouci.vid);

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        command.CommandText = "UPDATE Vedouci SET Jmeno = :Jmeno, pw = :pw, DatumN = :DatumN, Kontakt = :Kontakt WHERE vid = :vid";
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO Vedouci (vid, jmeno, pw, datum_narozeni, kontakt) VALUES (:vid, :Jmeno, :pw, :DatumN, :Kontakt)";
                    }
                    command.Parameters.Add(":vid", vedouci.vid);
                    command.Parameters.Add(":Jmeno", vedouci.Jmeno);
                    command.Parameters.Add(":pw", vedouci.Pw);
                    command.Parameters.Add(":DatumN", vedouci.DatumN);
                    command.Parameters.Add(":Kontakt", vedouci.Kontakt);

                    command.ExecuteNonQuery();
                
            }
        }

        //REMOVE FROM
        public void Delete(Vedouci vedouci)
        {
            using(db.GetConnection()){
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Vedouci WHERE ID = :ID");
                command.Parameters.Add(":ID", vedouci.vid);

                
            }
        }

    }
} 