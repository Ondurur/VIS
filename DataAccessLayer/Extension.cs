using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DataAccessLayer
{
    public static class Extension
    {
        public static void AddWithValue(this OracleParameterCollection cmd, string parameterName, object value)
        {
            //Console.Write("Addwithvalue: " + parameterName + " " + value);
            cmd.Add(parameterName, value);
        }
    }
}