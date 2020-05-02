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
                reader.Close();
                return data;;
            }
        }

        public List<AkceDeti> SelectByAkceId(int akce_aid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT akce_aid, deti_did FROM AkceDeti aa WHERE aa.akce_aid = :akce_aid");

                command.Parameters.AddWithValue(":akce_aid", akce_aid);

                List<AkceDeti> data = new List<AkceDeti>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data.Add(new AkceDeti(id, reader.GetInt32(1)));
                }
                reader.Close();
                return data;;
            }
        }

        public List<AkceDeti> SelectByDetiId(int deti_did)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT akce_aid, deti_did FROM AkceDeti aa WHERE aa.deti_did = :deti_did");

                command.Parameters.AddWithValue(":deti_did", deti_did);

                List<AkceDeti> data = new List<AkceDeti>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data.Add(new AkceDeti(id, reader.GetInt32(1)));
                }
                reader.Close();
                return data;;
            }
        }

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

        //DELETE NOT USED!

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