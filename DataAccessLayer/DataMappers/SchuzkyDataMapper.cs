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
                OracleCommand command = db.CreateCommand("SELECT s.sid,s.nazev_druziny, s.pocet_deti, s.datum_konani, v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt, f.fid, f.nazev, f.povinnosti FROM Schuzky s LEFT JOIN vedouci v ON v.vid = s.vedouci_vid LEFT JOIN funkce f ON f.fid = v.funkce_fid");

                List<Schuzky> data = new List<Schuzky>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    //nová instance vedoucího, upravit select
                    Funkce f = new Funkce(reader.GetInt32(9), reader.GetString(10), reader.GetString(11));
                    Vedouci v = new Vedouci(reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetString(8), f);
                    data.Add(new Schuzky(id, reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), v));
                }
                reader.Close();
                return data;
            }
        }

        public Schuzky SelectById(int sid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT s.sid,s.nazev_druziny, s.pocet_deti, s.datum_konani, v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt, f.fid, f.nazev, f.povinnosti FROM Schuzky s LEFT JOIN vedouci v ON v.vid = s.vedouci_vid LEFT JOIN funkce f ON f.fid = v.funkce_fid WHERE sid = :sid");

                command.Parameters.AddWithValue(":sid", sid);

                Schuzky data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    Funkce f = new Funkce(reader.GetInt32(9), reader.GetString(10), reader.GetString(11));
                    Vedouci v = new Vedouci(reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetString(8), f);
                    data = new Schuzky(id, reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), v);
                }
                reader.Close();
                return data;
            }
        }

        public List<Tuple<Deti,Schuzky>> SelectWithDeti()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT d.did, d.Jmeno, d.Nickname, d.Heslo, d.Datum_Narozeni, d.stav, d.reg_akci,h.hid, h.nazev, h.minimalni_vek, s.sid, s.nazev_druziny, s.pocet_deti, s.datum_konani,v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt,f.fid, f.nazev, f.povinnosti,r.rid, r.jmeno, r.login, r.heslo, r.kontakt FROM Deti d LEFT JOIN hodnosti h ON h.hid = d.hodnosti_hid LEFT JOIN Schuzky s ON s.sid = d.schuzky_sid LEFT JOIN vedouci v ON v.vid = s.vedouci_vid LEFT JOIN funkce f ON f.fid = v.funkce_fid LEFT JOIN rodic r ON r.rid = d.rodic_rid");

                List<Tuple<Deti, Schuzky>> data = new List<Tuple<Deti, Schuzky>>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Hodnosti h = new Hodnosti(reader.GetInt32(7), reader.GetString(8), reader.GetInt32(9));
                    Funkce f = new Funkce(reader.GetInt32(19), reader.GetString(20), reader.GetString(21));
                    Vedouci v = new Vedouci(reader.GetInt32(14), reader.GetString(15), reader.GetString(16), reader.GetDateTime(17), reader.GetString(18), f);
                    Schuzky s = new Schuzky(reader.GetInt32(10), reader.GetString(11), reader.GetInt32(12), reader.GetInt32(13), v);
                    Rodic r = new Rodic(reader.GetInt32(22), reader.GetString(23), reader.GetString(24), reader.GetString(25), reader.GetString(26));
                    data.Add(new Tuple<Deti, Schuzky>(new Deti(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetInt32(5), h, s, reader.GetInt32(6), r),s));
                }
                reader.Close();
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(Schuzky schuzky)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand select = db.CreateCommand("SELECT sid,nazev_druziny, pocet_deti, datum_konani, vedouci_vid FROM Schuzky WHERE sid = :sid AND rownum = 1");

                select.Parameters.AddWithValue(":ID", schuzky.Sid);

                var reader = select.ExecuteReader();

                if (reader.HasRows)
                {
                    OracleCommand command = db.CreateCommand("UPDATE Schuzky SET Nazev = :Nazev_druziny, pocet_deti = :pocet_deti, datum_konani = :datum_konani, vedouci_vid = :vedouci_vid WHERE sid = :sid");
                    command.Parameters.AddWithValue(":sid", schuzky.Sid);
                    command.Parameters.AddWithValue(":Nazev_druziny", schuzky.Nazev);
                    command.Parameters.AddWithValue(":pocet_deti", schuzky.Pocet_Deti);
                    command.Parameters.AddWithValue(":datum_konani", schuzky.Datum_konani);
                    command.Parameters.AddWithValue(":vedouci_vid", schuzky.Vedouci_vid.Vid);

                    command.ExecuteNonQuery();
                }
                else
                {
                    OracleCommand command = db.CreateCommand("INSERT INTO Schuzky (sid, Nazev, pocet_deti, datum_konani, vedouci_vid) VALUES (:sid, :Nazev_druziny, :pocet_deti, :datum_konani, :vedouci_vid)");
                    command.Parameters.AddWithValue(":sid", schuzky.Sid);
                    command.Parameters.AddWithValue(":Nazev_druziny", schuzky.Nazev);
                    command.Parameters.AddWithValue(":pocet_deti", schuzky.Pocet_Deti);
                    command.Parameters.AddWithValue(":datum_konani", schuzky.Datum_konani);
                    command.Parameters.AddWithValue(":vedouci_vid", schuzky.Vedouci_vid.Vid);

                    command.ExecuteNonQuery();
                }

            }
        }

        //REMOVE FROM
        public void Delete(Schuzky schuzky)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Schuzky WHERE sid = :sid");
                command.Parameters.AddWithValue(":sid", schuzky.Sid);

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
                    List<Schuzky> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        Schuzky v = toCSV[i];
                        string line = v.Sid + ", " + v.Nazev + ", " + v.Pocet_Deti + ", " + v.Datum_konani + ", " + v.Vedouci_vid.Vid;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }

            }
        }
    }
}
