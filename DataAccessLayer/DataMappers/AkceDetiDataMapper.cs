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
    public class AkceDetiDataMapper
    {
        private Database db;
        AkceDataMapper adm;

        public AkceDetiDataMapper()
        {
            db = new Database();
            adm = new AkceDataMapper();
        }


        public List<AkceDeti> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT akce_aid, deti_did FROM AkceDeti aa");

                List<AkceDeti> data = new List<AkceDeti>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data.Add(new AkceDeti(id, reader.GetInt32(1)));
                }
                return data;
            }
        }

        public AkceDeti SelectByAkceId(int akce_aid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT akce_aid, deti_did FROM AkceDeti aa WHERE aa.akce_aid = :akce_aid AND rownum = 1");

                command.Parameters.AddWithValue(":akce_aid", akce_aid);

                AkceDeti data = null;
                
                var reader = command.ExecuteReader();

                int id = reader.GetInt32(0);
                data = new AkceDeti(id, reader.GetInt32(1));

                return data;
            }
        }

        public AkceDeti SelectByDetiId(int deti_did)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT akce_aid, deti_did FROM AkceDeti aa WHERE aa.deti_did = :deti_did AND rownum = 1");

                command.Parameters.AddWithValue(":deti_did", deti_did);

                AkceDeti data = null;

                var reader = command.ExecuteReader();

                int id = reader.GetInt32(0);
                data = new AkceDeti(id, reader.GetInt32(1));

                return data;
            }
        }

        //INSERT OR UPDATE
        /*public void Save(AkceDeti AkceDeti)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand select = db.CreateCommand("SELECT akce_aid, deti_did FROM AkceDeti WHERE akce_aid = :akce_aid AND rownum = 1");

                select.Parameters.AddWithValue(":akce_aid", AkceDeti.Akce_aid);

                var reader = select.ExecuteReader();

                if (reader.HasRows)
                {
                    OracleCommand command = db.CreateCommand("UPDATE AkceDeti SET deti_did = :deti_did, Nickname = :Nickname, DatumK = :DatumK, Cena = :Cena, archivA = :archivA WHERE akce_aid = :akce_aid");
                    command.Parameters.AddWithValue(":akce_aid", AkceDeti.Akce_aid);
                    command.Parameters.AddWithValue(":deti_did", AkceDeti.Deti_did);

                    command.ExecuteNonQuery();
                }
                else
                {
                    OracleCommand command = db.CreateCommand("INSERT INTO AkceDeti (akce_aid, deti_did) VALUES (:akce_aid, :deti_did)");
                    command.Parameters.AddWithValue(":akce_aid", AkceDeti.Akce_aid);
                    command.Parameters.AddWithValue(":deti_did", AkceDeti.Deti_did);

                    command.ExecuteNonQuery();
                }

            }
        }*/

        public void AddAkceToDite(int p_dID, int p_aID)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand execProcedure = db.CreateCommand("ADDAKCETODITE");
                execProcedure.CommandType = System.Data.CommandType.StoredProcedure;
                execProcedure.Parameters.Add("p_dID", OracleDbType.Varchar2).Value = p_dID;
                execProcedure.Parameters.Add("p_aID", OracleDbType.Varchar2).Value = p_aID;

                execProcedure.ExecuteNonQuery();
            }
        }


        //REMOVE FROM
        public void Delete(AkceDeti AkceDeti)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("DELETE FROM AkceDeti WHERE akce_aid = :aID AND deti_did = :dID");
                command.Parameters.AddWithValue(":aID", AkceDeti.Akce_aid);
                command.Parameters.AddWithValue(":dID", AkceDeti.Deti_did);

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
                    List<AkceDeti> toCSV = SelectAll();
                    for (int i = 0; i < toCSV.Count; i++)
                    {
                        AkceDeti v = toCSV[i];
                        string line = v.Akce_aid + ", " + v.Deti_did;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
            }
        }
    }
}