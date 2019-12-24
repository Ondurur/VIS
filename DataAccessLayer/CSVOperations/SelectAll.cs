using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DataAccessLayer.DataMappers;
using VIS_Desktop.DTO;

namespace DataAccessLayer.CSVOperations
{
    public class Select
    {
        string DBname;
        string Path;

        public Select(string dbname, string path)
        {
            this.DBname = dbname;
            this.Path = path;
        }

        public IList<T> SelectAll<T>()
        {
            IList<T> ret = null;

            string fileName;
            using (var reader = new StreamReader(Path))
            {
                while (!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    if (typeof(T) == typeof(Akce))
                    {
                        string file = Path + "AkceCSV.csv";
                    }
                    else if (typeof(T) == typeof(AkceArchiv))
                    {
                        string file = Path + "AkceArchivCSV.csv";

                    }
                    else if (typeof(T) == typeof(Deti))
                    {
                        string file = Path + "DetiCSV.csv";

                    }
                    else if (typeof(T) == typeof(DetiArchiv))
                    {
                        string file = Path + "DetiArchivCSV.csv";

                    }
                    else if (typeof(T) == typeof(Vedouci))
                    {
                        string file = Path + "VedouciCSV.csv";

                    }
                    else if (typeof(T) == typeof(Schuzky))
                    {
                        string file = Path + "SchuzkyCSV.csv";

                    }
                    else
                    {
                        string file = Path + "HodnostiCSV.csv";

                    }
                }
            }
            return null;
        }

        static void Swap<T>(ref T input1, ref T input2)
        {
            T temp = default(T);

            temp = input2;
            input2 = input1;
            input1 = temp;
        }

    }
}
