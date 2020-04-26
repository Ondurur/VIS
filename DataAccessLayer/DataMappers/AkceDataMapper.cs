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
                OracleCommand command = db.CreateCommand("SELECT aid, Nazev, datum_konani,Cena, vedouci_vid, hodnosti_hid, max_pocet_deti FROM Akce");

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
                    if (!reader.IsDBNull(6))
                    {
                        max_pocet_deti = reader.GetInt32(6);
                    }
                    else
                    {
                        max_pocet_deti = 300;
                    }

                    data.Add(new Akce(id, reader.GetString(1), reader.GetDateTime(2), cena, vdm.SelectById(reader.GetInt32(4)), hdm.SelectById(reader.GetInt32(5)), max_pocet_deti));
                }
                return data;
    }
        }

        public Akce SelectById(int aid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT aid, Nazev, datum_konani,Cena, vedouci_vid, hodnosti_hid, max_pocet_deti FROM Akce WHERE aid = :aid AND rownum = 1");

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
                    if (!reader.IsDBNull(6))
                    {
                        max_pocet_deti = reader.GetInt32(6);
                    }
                    else
                    {
                        max_pocet_deti = 300;
                    }

                    data = new Akce(id, reader.GetString(1), reader.GetDateTime(2), cena, vdm.SelectById(reader.GetInt32(4)), hdm.SelectById(reader.GetInt32(5)), max_pocet_deti);
                }
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(Akce akce)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("SELECT aid, Nazev, datum_konani,Cena, vedouci_vid, hodnosti_hid FROM Akce WHERE aid = :aid AND rownum = 1"), commandUpdate, commandInsert;

                command.Parameters.AddWithValue(":aid", akce.Aid);

                var reader = command.ExecuteReader();

                reader.Read();
                if (reader.HasRows)
                {
                    commandUpdate = db.CreateCommand("UPDATE Akce SET Nazev = :Nazev , datum_konani = :datum_konani , Cena = :Cena , vedouci_vid = :vedouci_vid , hodnosti_hid = :hodnosti_hid , max_pocet_deti = :max_pocet_deti WHERE aid = :aid");
                    commandUpdate.Parameters.AddWithValue(":Nazev", akce.Nazev);
                    commandUpdate.Parameters.AddWithValue(":datum_konani", akce.Datum_konani);
                    commandUpdate.Parameters.AddWithValue(":Cena", akce.Cena);
                    commandUpdate.Parameters.AddWithValue(":vedouci_vid", akce.Vedouci_vid.Vid);
                    commandUpdate.Parameters.AddWithValue(":hodnosti_hid", akce.Hodnosti_hid.Hid);
                    commandUpdate.Parameters.AddWithValue(":max_pocet_deti", akce.Max_pocet_deti);
                    commandUpdate.Parameters.AddWithValue(":aid", akce.Aid);

                    commandUpdate.ExecuteNonQuery();
                }
                else
                {
                    commandInsert = db.CreateCommand("INSERT INTO Akce (aid, nazev, datum_konani, cena, vedouci_vid, hodnosti_hid, max_pocet_deti) VALUES ( :aid , :Nazev , :datum_konani , :Cena , :vedouci_vid , :hodnosti_hid , :max_pocet_deti )");
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
        }

        //REMOVE FROM
        public void Delete(Akce akce)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Akce WHERE aid = :aid");
                command.Parameters.AddWithValue(":aid", akce.Aid);

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
