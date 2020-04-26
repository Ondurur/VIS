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
        FunkceDataMapper fdm;

        public VedouciDataMapper()
        {
            db = new Database();
            fdm = new FunkceDataMapper();
        }
        
        public List<Vedouci> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT vid, jmeno, heslo, datum_narozeni, kontakt, funkce_fid FROM vedouci");

                List<Vedouci> data = new List<Vedouci>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Funkce funkce = null;
                    if (!reader.IsDBNull(5))
                        funkce = fdm.SelectById(reader.GetInt32(5));
                    data.Add(new Vedouci(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), funkce));                    
                }             

                return data;
            }
        }

        public Vedouci TryLogin(string username, string heslo)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT vid, jmeno, heslo, datum_narozeni, kontakt, funkce_fid FROM vedouci WHERE Jmeno = :nick AND Heslo = :heslo AND rownum = 1");

                command.Parameters.AddWithValue(":nick", username);
                command.Parameters.AddWithValue(":heslo", heslo);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string jmeno = reader.GetString(1);
                    string password = reader.GetString(2);
                    DateTime datum_narozeni = reader.GetDateTime(3);
                    string kontakt = reader.GetString(4);
                    return new Vedouci(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), fdm.SelectById(reader.GetInt32(5)));
                }
                return null;
            }
        }

        public Vedouci SelectById(int vid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT vid, jmeno, heslo, datum_narozeni, kontakt, funkce_fid FROM vedouci WHERE vid = :vid AND rownum = 1");

                command.Parameters.AddWithValue(":vid", vid);

                Vedouci data = null;
                int? funkceID = -1;
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(5))
                    {
                        funkceID = reader.GetInt32(5);
                    }

                    data = new Vedouci(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), fdm.SelectById(funkceID));
                }
                return data;
            }
        }

        public Vedouci SelectByName(string name)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT vid, jmeno, heslo, datum_narozeni, kontakt, funkce_fid FROM Vedouci WHERE Jmeno = :jmeno AND rownum = 1");

                command.Parameters.AddWithValue(":jmeno", name);

                Vedouci data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data = new Vedouci(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), fdm.SelectById(reader.GetInt32(5)));
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

                OracleCommand select = db.CreateCommand("SELECT vid, jmeno, heslo, datum_narozeni, kontakt, funkce_fid FROM Vedouci WHERE vID = :ID AND rownum = 1");

                    select.Parameters.AddWithValue(":ID", vedouci.Vid);

                    var reader = select.ExecuteReader();

                if (reader.HasRows)
                {
                    OracleCommand command = db.CreateCommand("UPDATE Vedouci SET Jmeno = :Jmeno, heslo = :heslo, Datum_narozeni = :Datum_narozeni, Kontakt = :Kontakt WHERE vid = :vid");
                    command.Parameters.AddWithValue(":vid", vedouci.Vid);
                    command.Parameters.AddWithValue(":Jmeno", vedouci.Jmeno);
                    command.Parameters.AddWithValue(":heslo", vedouci.Heslo);
                    command.Parameters.AddWithValue(":Datum_narozeni", vedouci.Datum_narozeni);
                    command.Parameters.AddWithValue(":Kontakt", vedouci.Kontakt);

                    command.ExecuteNonQuery();
                }
                else
                {
                    OracleCommand command = db.CreateCommand("INSERT INTO Vedouci (vid, jmeno, heslo, datum_narozeni, kontakt) VALUES (:vid, :Jmeno, :heslo, :Datum_narozeni, :Kontakt)");
                    command.Parameters.AddWithValue(":vid", vedouci.Vid);
                    command.Parameters.AddWithValue(":Jmeno", vedouci.Jmeno);
                    command.Parameters.AddWithValue(":heslo", vedouci.Heslo);
                    command.Parameters.AddWithValue(":Datum_narozeni", vedouci.Datum_narozeni);
                    command.Parameters.AddWithValue(":Kontakt", vedouci.Kontakt);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Tuple<string, string, string> VedouciSchuzkaDite(int p_vID)
        {
            using (db.GetConnection())
            {
                Tuple<string, string, string> ret = null;

                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT v.jmeno, (SELECT s.nazev_druziny FROM schuzky s WHERE s.vedouci_vid = v.vid),(SELECT jmeno FROM(SELECT did, jmeno, datum_narozeni FROM deti d JOIN schuzky s ON s.sid = d.schuzky_sid AND s.vedouci_vid = :p_vID WHERE ROWNUM = 1))FROM vedouci v WHERE v.vid = :p_vID");

                command.Parameters.AddWithValue(":p_vID", p_vID);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.IsDBNull(1) || reader.IsDBNull(2) || reader.IsDBNull(0))
                        return null;
                    ret = new Tuple<string, string, string>(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                }
                return ret;
            }
        }

        //REMOVE FROM
        public void Delete(Vedouci vedouci)
        {
            using(db.GetConnection()){
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Vedouci WHERE ID = :ID");
                command.Parameters.AddWithValue(":ID", vedouci.Vid);

                command.ExecuteNonQuery();
            }
        }

        public void DiteBecomeVedouci(int p_dID)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand execProcedure = db.CreateCommand("DITEBECOMEVEDOUCI");
                execProcedure.CommandType = System.Data.CommandType.StoredProcedure;
                execProcedure.Parameters.Add("p_dID", OracleDbType.Varchar2).Value = p_dID;

                execProcedure.ExecuteNonQuery();
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
                        string line = v.Vid + ", " + v.Jmeno + ", " + v.Heslo + ", " + v.Datum_narozeni + ", " + v.Kontakt;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
                
            }
        }
    }
} 