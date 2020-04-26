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
                OracleCommand command = db.CreateCommand("SELECT sid,nazev_druziny, pocet_deti, datum_konani, vedouci_vid FROM Schuzky");

                List<Schuzky> data = new List<Schuzky>();

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
                OracleCommand command = db.CreateCommand("SELECT sid,nazev_druziny, pocet_deti, datum_konani, vedouci_vid FROM Schuzky WHERE sid = :sid AND rownum = 1");

                command.Parameters.AddWithValue(":sid", sid);

                Schuzky data = null;

                var reader = command.ExecuteReader();

                while (reader.Read())
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
