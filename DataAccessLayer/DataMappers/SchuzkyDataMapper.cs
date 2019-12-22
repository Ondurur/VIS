using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                OracleCommand command = db.CreateCommand("SELECT * FROM Schuzky");

                List<Schuzky> data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    data.Add(new Schuzky(id, reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), vdm.SelectById(id)));
                }
                return data;
            }
        }

        public Schuzky SelectById(int sid)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("SELECT TOP 1 * FROM Schuzky WHERE sid = :sid");

                command.Parameters.Add(":sid", sid);

                Schuzky data = null;

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    int id = reader.GetInt32(0);
                    data = new Schuzky(id, reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), vdm.SelectById(id));
                }
                return data;
            }
        }

        //INSERT OR UPDATE
        public void Save(Schuzky schuzky)
        {
            using (db.GetConnection())
            {
                db.Connect();

                OracleCommand command = db.CreateCommand("SELECT TOP 1 * FROM Schuzky WHERE sid = :sid");

                command.Parameters.Add(":ID", schuzky.sid);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    command.CommandText = "UPDATE Schuzky SET Nazev = :Nazev, pocetD = :pocetD, DatumK = :DatumK, vedouciS = :vedouciS WHERE sid = :sid";
                }
                else
                {
                    command.CommandText = "INSERT INTO Schuzky (sid, Nazev, pocetD, DatumK, vedouciS) VALUES (:sid, :Nazev, :pocetD, :DatumK, :vedouciS)";
                }
                command.Parameters.Add(":sid", schuzky.sid);
                command.Parameters.Add(":Nazev", schuzky.Nazev);
                command.Parameters.Add(":pocetD", schuzky.PocetD);
                command.Parameters.Add(":DatumK", schuzky.DatumK);
                command.Parameters.Add(":vedouciS", schuzky.VedouciS);

                command.ExecuteNonQuery();

            }
        }

        //REMOVE FROM
        public void Delete(Schuzky schuzky)
        {
            using (db.GetConnection())
            {
                db.Connect();
                OracleCommand command = db.CreateCommand("DELETE FROM Schuzky WHERE ID = :ID");
                command.Parameters.Add(":ID", schuzky.sid);


            }
        }
    }
}
