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
    public class LogDataMapper
    {
        private Database db;
        VedouciDataMapper vdm;

        public LogDataMapper()
        {
            db = new Database();
            vdm = new VedouciDataMapper();
        }
        
        public List<Log> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT l.lid, l.pocet_vedoucich, l.pocet_deti, l.datum_zalohy, v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt, f.fid, f.nazev, f.povinnosti  FROM Log l LEFT JOIN vedouci v ON v.vid = l.vedouci_vid LEFT JOIN funkce f ON f.fid = v.funkce_fid");

                List<Log> data = new List<Log>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new Log(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), vdm.SelectById(reader.GetInt32(4))));                    
                }             

                reader.Close();
                return data;
            }
        }

        public Log SelectById(int lid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT l.lid, l.pocet_vedoucich, l.pocet_deti, l.datum_zalohy, v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt, f.fid, f.nazev, f.povinnosti  FROM Log l LEFT JOIN vedouci v ON v.vid = l.vedouci_vid LEFT JOIN funkce f ON f.fid = v.funkce_fid WHERE lid = :lid");

                command.Parameters.AddWithValue(":lid", lid);

                Log data = null;
                int? funkceID = -1;
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(5))
                    {
                        funkceID = reader.GetInt32(5);
                    }
                    Funkce f = new Funkce(reader.GetInt32(9), reader.GetString(10), reader.GetString(11));
                    Vedouci v = new Vedouci(reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetString(8), f);

                    data = new Log(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), v);
                }
                reader.Close();
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(Log Log)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand select = db.CreateCommand("SELECT lid, pocet_vedoucich, pocet_deti, datum_zalohy, vedouci_vid FROM Log WHERE lid = :ID AND rownum = 1");

                    select.Parameters.AddWithValue(":ID", Log.Lid);

                    var reader = select.ExecuteReader();

                if (reader.HasRows)
                {
                    OracleCommand command = db.CreateCommand("UPDATE Log SET Pocet_vedoucich = :Pocet_vedoucich, pocet_deti = :pocet_deti, Datum_zalohy = :Datum_zalohy, vedouci_vid = :vedouci_vid WHERE lid = :lid");
                    command.Parameters.AddWithValue(":lid", Log.Lid);
                    command.Parameters.AddWithValue(":Pocet_vedoucich", Log.Pocet_vedoucich);
                    command.Parameters.AddWithValue(":pocet_deti", Log.Pocet_deti);
                    command.Parameters.AddWithValue(":Datum_zalohy", Log.Datum_zalohy);
                    command.Parameters.AddWithValue(":vedouci_vid", Log.Vedouci_vid.Vid);

                    command.ExecuteNonQuery();
                }
                else
                {
                    OracleCommand command = db.CreateCommand("INSERT INTO Log (lid, pocet_vedoucich, pocet_deti, datum_zalohy, vedouci_vid) VALUES (:lid, :Pocet_vedoucich, :pocet_deti, :Datum_zalohy, :vedouci_vid)");
                    command.Parameters.AddWithValue(":lid", Log.Lid);
                    command.Parameters.AddWithValue(":Pocet_vedoucich", Log.Pocet_vedoucich);
                    command.Parameters.AddWithValue(":pocet_deti", Log.Pocet_deti);
                    command.Parameters.AddWithValue(":Datum_zalohy", Log.Datum_zalohy);
                    command.Parameters.AddWithValue(":vedouci_vid", Log.Vedouci_vid.Vid);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void MakeLog(int p_vID)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("MAKELOG");
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("p_vedouciID", OracleDbType.Int32).Value = 1;
                command.ExecuteNonQuery();
            }
        }

        //REMOVE FROM
        public void Delete(Log Log)
        {
            using(db.GetConnection()){
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Log WHERE lid = :ID");
                command.Parameters.AddWithValue(":ID", Log.Lid);

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
                    List<Log> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        Log v = toCSV[i];
                        string line = v.Lid + ", " + v.Pocet_vedoucich + ", " + v.Pocet_deti + ", " + v.Datum_zalohy + ", " + v.Vedouci_vid.Vid;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }                
            }
        }
    }
} 