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
                OracleCommand command = db.CreateCommand("SELECT aid, Nazev, DatumK,Cena, VedouciA, HodnostiA FROM Akce");

                List<Akce> data = new List<Akce>();
                
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);

                    int? cena;

                    if (!reader.IsDBNull(3))
                    {
                        cena = reader.GetInt32(3);
                    }
                    else
                    {
                        cena = null;
                    }

                    data.Add(new Akce(id, reader.GetString(1), reader.GetDateTime(2), cena, vdm.SelectById(id), hdm.SelectById(id)));
                }
                return data;
    }
        }

        public Akce SelectById(int aid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT aid, Nazev, DatumK,Cena, VedouciA, HodnostiA FROM Akce WHERE aid = :aid AND rownum = 1");

                command.Parameters.AddWithValue(":aid", aid);

                Akce data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data = new Akce(id, reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), vdm.SelectById(id), hdm.SelectById(id));
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

                OracleCommand command = db.CreateCommand("SELECT aid, Nazev, DatumK,Cena, VedouciA, HodnostiA FROM Akce WHERE aid = :aid AND rownum = 1");

                command.Parameters.AddWithValue(":aid", akce.aid);

                var reader = command.ExecuteReader();

                reader.Read();
                if (reader.HasRows)
                {
                    command.CommandText = "UPDATE Akce SET Nazev = :Nazev, Nickname = :Nickname, DatumK = :DatumK, Cena = :Cena, VedouciA = :VedouciA, HodnostiA = :HodnostiA WHERE aid = :aid";
                }
                else
                {
                    command.CommandText = "INSERT INTO Akce (aid, Nazev, DatumK,Cena, VedouciA, HodnostiA) VALUES (:aid, :Nazev, :DatumK, :Cena, :VedouciA, :HodnostiA)";
                }
                command.Parameters.AddWithValue(":aid", akce.aid);
                command.Parameters.AddWithValue(":Nazev", akce.Nazev);
                command.Parameters.AddWithValue(":DatumK", akce.DatumK);
                command.Parameters.AddWithValue(":Cena", akce.Cena);
                command.Parameters.AddWithValue(":VedouciA", akce.VedouciA.vid);
                command.Parameters.AddWithValue(":HodnostiA", akce.HodnostiA.hid);

                command.ExecuteNonQuery();

            }
        }

        //REMOVE FROM
        public void Delete(Akce akce)
        {
            using (db.GetConnection())
            {
                db.Connect();
                
                AkceArchivDataMapper aadm = new AkceArchivDataMapper();
                List<AkceArchiv> akceArchivList = aadm.SelectAll();
                AkceArchiv aa = new AkceArchiv(akceArchivList.Count, akce.Nazev, akce.DatumK, akce.Cena, akce);
                aadm.Save(aa);

                OracleCommand command = db.CreateCommand("DELETE FROM Akce WHERE ID = :ID");
                command.Parameters.AddWithValue(":ID", akce.aid);
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
                        string line = v.aid + ", " + v.Nazev + ", " + v.DatumK + ", " + v.Cena + ", " + v.VedouciA.vid + ", " + v.HodnostiA.hid;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
            }
        }
    }
}
