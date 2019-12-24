using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DataAccessLayer;
using VIS_Desktop.DataAccessLayer.ForeignMappers;
using VIS_Desktop.DTO;

namespace VIS_Desktop.DataAccessLayer.DataMappers
{
    public class AkceArchivDataMapper
    {
        private Database db;
        AkceDataMapper adm;

        public AkceArchivDataMapper()
        {
            db = new Database();
            adm = new AkceDataMapper();
        }


        public List<AkceArchiv> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM AkceArchiv aa");

                List<AkceArchiv> data = null;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    int id = reader.GetInt32(0);
                    data.Add(new AkceArchiv(id, reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), adm.SelectById(id)));
                }
                return data;
            }
        }

        public AkceArchiv SelectById(int aid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT MIN(aid) FROM AkceArchiv aa WHERE aa.aid = :aid");

                command.Parameters.Add(":aid", aid);

                AkceArchiv data = null;
                
                var reader = command.ExecuteReader();

                int id = reader.GetInt32(0);
                data = new AkceArchiv(id, reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), adm.SelectById(id));

                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(AkceArchiv akceArchiv)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("SELECT MIN(aid) FROM AkceArchiv WHERE aid = :aid");

                command.Parameters.Add(":aid", akceArchiv.aid);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    command.CommandText = "UPDATE AkceArchiv SET Nazev = :Nazev, Nickname = :Nickname, DatumK = :DatumK, Cena = :Cena, archivA = :archivA WHERE aid = :aid";
                }
                else
                {
                    command.CommandText = "INSERT INTO AkceArchiv (aid, Nazev, DatumK,Cena, archivA) VALUES (:aid, :Nazev, :DatumK, :Cena, :archivA)";
                }
                command.Parameters.Add(":aid", akceArchiv.aid);
                command.Parameters.Add(":Nazev", akceArchiv.Nazev);
                command.Parameters.Add(":DatumK", akceArchiv.DatumK);
                command.Parameters.Add(":Cena", akceArchiv.Cena);
                command.Parameters.Add(":archivA", akceArchiv.archivA.aid);

                command.ExecuteNonQuery();

            }
        }


        //REMOVE FROM
        public void Delete(AkceArchiv akceArchiv)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("DELETE FROM AkceArchiv WHERE ID = :ID");
                command.Parameters.Add(":ID", akceArchiv.aid);

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
                    List<AkceArchiv> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        AkceArchiv v = toCSV[i];
                        string line = v.aid + ", " + v.Nazev + ", " + v.DatumK + ", " + v.Cena + ", " + v.archivA.aid;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
            }
        }
    }
}