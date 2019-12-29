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
        SchuzkyDataMapper sdm;
        HodnostiDataMapper hdm;

        public DetiDataMapper()
        {
            db = new Database();
            sdm = new SchuzkyDataMapper();
            hdm = new HodnostiDataMapper();
        }


        public List<Deti> SelectAll()
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM Deti");

                List<Deti> data = new List<Deti>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data.Add(new Deti(id, reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), hdm.SelectById(id), sdm.SelectById(id)));
                }
                return data;
            }
        }

        public Deti TryLoginCSV(string username, string pw)
        {
            return null;
        }

        public Deti SelectById(int did)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT * FROM Deti WHERE did = :did AND rownum = 1");

                command.Parameters.AddWithValue(":did", did);

                Deti data = null;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data = new Deti(id, reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), hdm.SelectById(id), sdm.SelectById(id));
                }

                return data;
            }
        }

        public Deti TryLogin(string nick, string pw)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT did, Jmeno, Nickname,Pw,DatumN,KontaktNR, HodnostD,SchuzkyD FROM Deti WHERE (Nickname = :nick OR Jmeno = :jmeno) AND Pw = :pw AND rownum = 1");

                command.Parameters.AddWithValue(":nick", nick);
                command.Parameters.AddWithValue(":jmeno", nick);
                command.Parameters.AddWithValue(":pw", pw);

                var reader = command.ExecuteReader();

                Deti ret = null; ;

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    ret = new Deti(id, reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), hdm.SelectById(id), sdm.SelectById(id));
                }
                return ret ;
            }
        }

        //INSERT OR UPDATE
        public void Save(Deti deti)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("SELECT * FROM Deti WHERE did = :did AND rownum = 1");

                command.Parameters.AddWithValue(":did", deti.did);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    command.CommandText = "UPDATE Deti SET Jmeno = :Jmeno, Nickname = :Nickname, Pw = :Pw, DatumN = :DatumN, KontaktNR = :KontaktNR, HodnostD = :HodnostD, SchuzkyD = :SchuzkyD WHERE did = :did";
                }
                else
                {
                    command.CommandText = "INSERT INTO Deti (did, Jmeno, Nickname,Pw,DatumN,KontaktNR, HodnostD,SchuzkyD) VALUES (:did, :Jmeno, :Nickname,:Pw,:DatumN,:KontaktNR, :HodnostD,:SchuzkyD)";
                }
                command.Parameters.AddWithValue(":did", deti.did);
                command.Parameters.AddWithValue(":Jmeno", deti.Jmeno);
                command.Parameters.AddWithValue(":Nickname", deti.Nickname);
                command.Parameters.AddWithValue(":Pw", deti.Pw);
                command.Parameters.AddWithValue(":DatumN", deti.DatumN);
                command.Parameters.AddWithValue(":KontaktNR", deti.KontaktNR);
                command.Parameters.AddWithValue(":HodnostD", deti.HodnostD.hid);
                command.Parameters.AddWithValue(":SchuzkyD", deti.SchuzkyD.sid);

                command.ExecuteNonQuery();

            }
        }

        //REMOVE FROM
        public void Delete(Deti deti)
        {
            using (db.GetConnection())
            {
                DetiArchivDataMapper dadm = new DetiArchivDataMapper();
                List<DetiArchiv> detiArchivList = dadm.SelectAll();
                DetiArchiv aa = new DetiArchiv(detiArchivList.Count, deti.Jmeno, deti.DatumN, deti.KontaktNR, deti);
                dadm.Save(aa);
                
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Deti WHERE ID = :ID");
                command.Parameters.AddWithValue(":ID", deti.did);
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
                        string line = v.did + ", " + v.Jmeno + ", " + v.Nickname + ", " + v.Pw + ", " + v.DatumN + ", " + v.KontaktNR + ", " + v.HodnostD.hid + ", " + v.SchuzkyD.sid;
                        w.WriteLine(line);
                        w.Flush();
                    }
                }
            }
        }
    }
}
