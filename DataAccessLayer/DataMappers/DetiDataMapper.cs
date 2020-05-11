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
    public class DetiDataMapper
    {
        private Database db;

        public DetiDataMapper()
        {
            db = new Database();
        }


        //SelectAll 3.4
        public List<Deti> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT d.did, d.Jmeno, d.Nickname, d.Heslo, d.Datum_Narozeni, d.stav, d.reg_akci,h.hid, h.nazev, h.minimalni_vek, s.sid, s.nazev_druziny, s.pocet_deti, s.datum_konani,v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt,f.fid, f.nazev, f.povinnosti,r.rid, r.jmeno, r.login, r.heslo, r.kontakt FROM Deti d LEFT JOIN hodnosti h ON h.hid = d.hodnosti_hid LEFT JOIN Schuzky s ON s.sid = d.schuzky_sid LEFT JOIN vedouci v ON v.vid = s.vedouci_vid LEFT JOIN funkce f ON f.fid = v.funkce_fid LEFT JOIN rodic r ON r.rid = d.rodic_rid");

                List<Deti> data = new List<Deti>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Hodnosti h = new Hodnosti(reader.GetInt32(7), reader.GetString(8), reader.GetInt32(9));
                    Funkce f = new Funkce(reader.GetInt32(19), reader.GetString(20), reader.GetString(21));
                    Vedouci v = new Vedouci(reader.GetInt32(14), reader.GetString(15), reader.GetString(16),reader.GetDateTime(17), reader.GetString(18), f);
                    Schuzky s = new Schuzky(reader.GetInt32(10), reader.GetString(11), reader.GetInt32(12), reader.GetInt32(13), v);
                    Rodic r = new Rodic(reader.GetInt32(22), reader.GetString(23), reader.GetString(24), reader.GetString(25), reader.GetString(26));
                    data.Add(new Deti(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetInt32(5), h, s, reader.GetInt32(6), r));
                }
                reader.Close();
                return data;;
            }
        }

        public Deti TryLoginCSV(string username, string heslo)
        {
            return null;
        }

        public Deti SelectById(int did)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT d.did, d.Jmeno, d.Nickname, d.Heslo, d.Datum_Narozeni, d.stav, d.reg_akci,h.hid, h.nazev, h.minimalni_vek, s.sid, s.nazev_druziny, s.pocet_deti, s.datum_konani,v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt,f.fid, f.nazev, f.povinnosti,r.rid, r.jmeno, r.login, r.heslo, r.kontakt FROM Deti d LEFT JOIN hodnosti h ON h.hid = d.hodnosti_hid LEFT JOIN Schuzky s ON s.sid = d.schuzky_sid LEFT JOIN vedouci v ON v.vid = s.vedouci_vid LEFT JOIN funkce f ON f.fid = v.funkce_fid LEFT JOIN rodic r ON r.rid = d.rodic_rid WHERE d.dID = :dID");

                command.Parameters.AddWithValue(":dID", did);

                Deti data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Hodnosti h = new Hodnosti(reader.GetInt32(7), reader.GetString(8), reader.GetInt32(9));
                    Funkce f = new Funkce(reader.GetInt32(19), reader.GetString(20), reader.GetString(21));
                    Vedouci v = new Vedouci(reader.GetInt32(14), reader.GetString(15), reader.GetString(16), reader.GetDateTime(17), reader.GetString(18), f);
                    Schuzky s = new Schuzky(reader.GetInt32(10), reader.GetString(11), reader.GetInt32(12), reader.GetInt32(13), v);
                    Rodic r = new Rodic(reader.GetInt32(22), reader.GetString(23), reader.GetString(24), reader.GetString(25), reader.GetString(26));
                    data = new Deti(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetInt32(5), h, s, reader.GetInt32(6), r);
                }
                reader.Close();
                return data;
            }
        }

        public Deti TryLogin(string nick, string heslo)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT d.did, d.Jmeno, d.Nickname, d.Heslo, d.Datum_Narozeni, d.stav, d.reg_akci,h.hid, h.nazev, h.minimalni_vek, s.sid, s.nazev_druziny, s.pocet_deti, s.datum_konani,v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt,f.fid, f.nazev, f.povinnosti,r.rid, r.jmeno, r.login, r.heslo, r.kontakt FROM Deti d LEFT JOIN hodnosti h ON h.hid = d.hodnosti_hid LEFT JOIN Schuzky s ON s.sid = d.schuzky_sid LEFT JOIN vedouci v ON v.vid = s.vedouci_vid LEFT JOIN funkce f ON f.fid = v.funkce_fid LEFT JOIN rodic r ON r.rid = d.rodic_rid WHERE d.Nickname = :nick AND d.Heslo = :heslo AND rownum = 1 AND d.stav = 0");

                command.Parameters.AddWithValue(":nick", nick);
                command.Parameters.AddWithValue(":heslo", heslo);

                var reader = command.ExecuteReader();

                Deti data = null;

                while (reader.Read())
                {
                    Hodnosti h = new Hodnosti(reader.GetInt32(7), reader.GetString(8), reader.GetInt32(9));
                    Funkce f = new Funkce(reader.GetInt32(19), reader.GetString(20), reader.GetString(21));
                    Vedouci v = new Vedouci(reader.GetInt32(14), reader.GetString(15), reader.GetString(16), reader.GetDateTime(17), reader.GetString(18), f);
                    Schuzky s = new Schuzky(reader.GetInt32(10), reader.GetString(11), reader.GetInt32(12), reader.GetInt32(13), v);
                    Rodic r = new Rodic(reader.GetInt32(22), reader.GetString(23), reader.GetString(24), reader.GetString(25), reader.GetString(26));
                    data = new Deti(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetInt32(5), h, s, reader.GetInt32(6), r);
                }
                reader.Close();
                return data;
            }
        }

        //INSERT 3.1
        public void Insert(Deti deti)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand commandInsert = db.CreateCommand("INSERT INTO Deti (did, Jmeno, Nickname,Heslo,datum_narozeni,Stav, hodnosti_hid,schuzky_sid, reg_akci, rodic_rid) VALUES (:did, :Jmeno, :Nickname,:Heslo,:datum_narozeni,:Stav, :hodnosti_hid,:schuzky_sid, :reg_akci, :rodic_rid)");
                commandInsert.Parameters.AddWithValue(":did", deti.Did);
                commandInsert.Parameters.AddWithValue(":Jmeno", deti.Jmeno);
                commandInsert.Parameters.AddWithValue(":Nickname", deti.Nickname);
                commandInsert.Parameters.AddWithValue(":Heslo", deti.Heslo);
                commandInsert.Parameters.AddWithValue(":datum_narozeni", deti.Datum_narozeni);
                commandInsert.Parameters.AddWithValue(":Stav", deti.Stav);
                commandInsert.Parameters.AddWithValue(":hodnosti_hid", deti.Hodnosti_hid.Hid);
                commandInsert.Parameters.AddWithValue(":schuzky_sid", deti.Schuzky_sid.Sid);
                commandInsert.Parameters.AddWithValue(":reg_akci", deti.Reg_akci);
                commandInsert.Parameters.AddWithValue(":rodic_rid", deti.Rodic_rid.Rid);

                commandInsert.ExecuteNonQuery();
            }
        }

        //UPDATE 3.3
        public void Update(Deti deti)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand commandUpdate = db.CreateCommand("UPDATE Deti SET Jmeno = :Jmeno, Nickname = :Nickname, Heslo = :Heslo, datum_narozeni = :datum_narozeni, Stav = :Stav, hodnosti_hid = :hodnosti_hid, schuzky_sid = :schuzky_sid, rodic_rid = :rodic_rid WHERE did = :did"); commandUpdate.Parameters.AddWithValue(":Jmeno", deti.Jmeno);
                commandUpdate.Parameters.AddWithValue(":Nickname", deti.Nickname);
                commandUpdate.Parameters.AddWithValue(":Heslo", deti.Heslo);
                commandUpdate.Parameters.AddWithValue(":datum_narozeni", deti.Datum_narozeni);
                commandUpdate.Parameters.AddWithValue(":Stav", deti.Stav);
                commandUpdate.Parameters.AddWithValue(":hodnosti_hid", deti.Hodnosti_hid.Hid);
                commandUpdate.Parameters.AddWithValue(":schuzky_sid", deti.Schuzky_sid.Sid);
                commandUpdate.Parameters.AddWithValue(":reg_akci", deti.Reg_akci);
                commandUpdate.Parameters.AddWithValue(":rodic_rid", deti.Rodic_rid.Rid);

                commandUpdate.ExecuteNonQuery();
            }
        }

        //NejpocetnejsiAkce 3.5
        public List<Tuple<int, string, int, int>> NejpocetnejsiAkce()
        {
            using (db.GetConnection())
            {
                List<Tuple<int, string, int, int>> ret = new List<Tuple<int, string, int, int>>();
                Tuple<int, string, int, int> item = null;
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT did, jmeno, stav, hodnosti_hid FROM Deti WHERE dID IN(SELECT Deti_dID FROM akcedeti WHERE Akce_aID IN( SELECT aID FROM Akce WHERE aid IN( SELECT aid FROM Akce a WHERE(SELECT COUNT(*) FROM akcedeti ad WHERE a.aid = ad.Akce_aid) = (SELECT MAX(t.pocet) AS maxpocet FROM(SELECT COUNT(akce_aid) AS pocet FROM akcedeti group by akce_aid) t)AND Vedouci_vID IN(SELECT v.vID FROM Vedouci v WHERE(SELECT count(*) FROM Schuzky s WHERE s.Vedouci_vID = v.vID) = ( SELECT max(t.pocet) as maxpocet FROM(SELECT count(Vedouci_vID) as pocet FROM Schuzky group by Vedouci_vID) t)))))and Stav = 0");

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2) || reader.IsDBNull(3))
                    {
                        item = new Tuple<int, string, int, int>(0, "null", 0, 0);
                        Console.WriteLine(item.Item1 + "|" + item.Item2 + "|" + item.Item3 + "|" + item.Item4);
                        ret.Add(item);
                    }
                    else
                    {
                        item = new Tuple<int, string, int, int>(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                        Console.WriteLine(item.Item1 + "|" + item.Item2 + "|" + item.Item3 + "|" + item.Item4);
                        ret.Add(item);
                    }
                }
                return ret;
            }
        }

        //REMOVE FROM - UPDATE "stav" to -1 3.2
        public void Delete(Deti deti)
        {
            using (db.GetConnection())
            {          
                db.Connect();
                OracleCommand command = db.CreateCommand("UPDATE Deti SET Stav = -1 WHERE ID = :ID");
                command.Parameters.AddWithValue(":ID", deti.Did);

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
                    List<Deti> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        Deti v = toCSV[i];
                        string line = v.Did + ", " + v.Jmeno + ", " + v.Nickname + ", " + v.Heslo + ", " + v.Datum_narozeni + ", " + v.Stav + ", " + v.Hodnosti_hid.Hid + ", " + v.Schuzky_sid.Sid;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
            }
        }
    }
}
