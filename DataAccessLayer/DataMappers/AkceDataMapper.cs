using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DataAccessLayer;
using VIS_Desktop.DTO;

namespace VIS_Desktop.DataAccessLayer.DataMappers
{
    public class AkceDataMapper
    {
        private Database db;
        VedouciDataMapper vdm;
        HodnostiDataMapper hdm;

        public AkceDataMapper()
        {
            db = new Database();
            vdm = new VedouciDataMapper();
            hdm = new HodnostiDataMapper();
        }


        public List<Akce> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT a.aid, a.Nazev, a.datum_konani, a.Cena, a.max_pocet_deti,v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt, f.fid, f.nazev, f.povinnosti , h.hid, h.nazev, h.minimalni_vek FROM Akce a JOIN hodnosti h ON h.hid = a.hodnosti_hid JOIN vedouci v ON v.vid = a.vedouci_vid JOIN funkce f ON f.fid = v.funkce_fid");

                List<Akce> data = new List<Akce>();
                
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);

                    int? cena;
                    int? max_pocet_deti;

                    if (!reader.IsDBNull(3))
                    {
                        cena = reader.GetInt32(3);
                    }
                    else
                    {
                        cena = null;
                    }
                    if (!reader.IsDBNull(4))
                    {
                        max_pocet_deti = reader.GetInt32(4);
                    }
                    else
                    {
                        max_pocet_deti = 300;
                    }
                    Hodnosti h = new Hodnosti(reader.GetInt32(13), reader.GetString(14), reader.GetInt32(15));
                    Vedouci v = new Vedouci(reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetDateTime(8), reader.GetString(9), new Funkce(reader.GetInt32(10), reader.GetString(11), reader.GetString(12)));
                    data.Add(new Akce(id, reader.GetString(1), reader.GetDateTime(2), cena, v, h, max_pocet_deti));

                }


                reader.Close();
                return data;;
            }
        }

        public Akce SelectById(int aid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT a.aid, a.Nazev, a.datum_konani, a.Cena, a.max_pocet_deti,v.vid, v.jmeno, v.heslo, v.datum_narozeni, v.kontakt, f.fid, f.nazev, f.povinnosti , h.hid, h.nazev, h.minimalni_vek FROM Akce a JOIN hodnosti h ON h.hid = a.hodnosti_hid JOIN vedouci v ON v.vid = a.vedouci_vid JOIN funkce f ON f.fid = v.funkce_fid WHERE aid = :aid");

                command.Parameters.AddWithValue(":aid", aid);

                Akce data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);

                    int? cena;
                    int? max_pocet_deti;

                    if (!reader.IsDBNull(3))
                    {
                        cena = reader.GetInt32(3);
                    }
                    else
                    {
                        cena = null;
                    }
                    if (!reader.IsDBNull(4))
                    {
                        max_pocet_deti = reader.GetInt32(4);
                    }
                    else
                    {
                        max_pocet_deti = 300;
                    }
                    Hodnosti h = new Hodnosti(reader.GetInt32(13), reader.GetString(14), reader.GetInt32(15));
                    Vedouci v = new Vedouci(reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetDateTime(8), reader.GetString(9), new Funkce(reader.GetInt32(10), reader.GetString(11), reader.GetString(12)));
                    data = new Akce(id, reader.GetString(1), reader.GetDateTime(2), cena, v, h, max_pocet_deti);
                }
                reader.Close();
                return data;;
            }
        }

        //INSERT OR UPDATE
        //přepracovat na insert update
        public void Insert(Akce akce)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand commandInsert = db.CreateCommand("INSERT INTO Akce (aid, nazev, datum_konani, cena, vedouci_vid, hodnosti_hid, max_pocet_deti) VALUES ( :aid , :Nazev , :datum_konani , :Cena , :vedouci_vid , :hodnosti_hid , :max_pocet_deti )");
                commandInsert.Parameters.AddWithValue(":aid", akce.Aid);
                commandInsert.Parameters.AddWithValue(":Nazev", akce.Nazev);
                commandInsert.Parameters.AddWithValue(":datum_konani", akce.Datum_konani);
                commandInsert.Parameters.AddWithValue(":Cena", akce.Cena);
                commandInsert.Parameters.AddWithValue(":vedouci_vid", akce.Vedouci_vid.Vid);
                commandInsert.Parameters.AddWithValue(":hodnosti_hid", akce.Hodnosti_hid.Hid);
                commandInsert.Parameters.AddWithValue(":max_pocet_deti", akce.Max_pocet_deti);

                commandInsert.ExecuteNonQuery();
            }
        }

        public void Update(Akce akce)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand commandUpdate = db.CreateCommand("UPDATE Akce SET Nazev = :Nazev , datum_konani = :datum_konani , Cena = :Cena , vedouci_vid = :vedouci_vid , hodnosti_hid = :hodnosti_hid , max_pocet_deti = :max_pocet_deti WHERE aid = :aid");
                commandUpdate.Parameters.AddWithValue(":Nazev", akce.Nazev);
                commandUpdate.Parameters.AddWithValue(":datum_konani", akce.Datum_konani);
                commandUpdate.Parameters.AddWithValue(":Cena", akce.Cena);
                commandUpdate.Parameters.AddWithValue(":vedouci_vid", akce.Vedouci_vid.Vid);
                commandUpdate.Parameters.AddWithValue(":hodnosti_hid", akce.Hodnosti_hid.Hid);
                commandUpdate.Parameters.AddWithValue(":max_pocet_deti", akce.Max_pocet_deti);
                commandUpdate.Parameters.AddWithValue(":aid", akce.Aid);

                commandUpdate.ExecuteNonQuery();

            }
        }

        //NOT USED DELETE!

        public void ExportToCSV(string path)
        {
            using (db.GetConnection())
            {
                db.Connect();
                using (var w = new StreamWriter(path))
                {
                    List<Akce> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        Akce v = toCSV[i];
                        string line = v.Aid + ", " + v.Nazev + ", " + v.Datum_konani + ", " + v.Cena + ", " + v.Vedouci_vid.Vid + ", " + v.Hodnosti_hid.Hid;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
            }
        }
    }
}
