using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DataAccessLayer
{
    public class Database
    {
        private const string ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=dbsys.cs.vsb.cz)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=oracle.dbsys.cs.vsb.cz)));User Id=hor0404;Password=oq7UusDh4P;Connection Timeout=45";

        private OracleConnection Connection { get; set; }
        private OracleTransaction SqlTransaction { get; set; }
        public string Language { get; set; }

        public static Database instance;

        //private const string KEY = "SessionDatabase";

        public Database()
        {
            Connection = new OracleConnection();
            Language = "en";
        }


        public static Database getInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }



        public bool Connect(String conString)
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = conString;
                try
                {
                    Connection.Open();
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return true;
        }


        public bool Connect()
        {
            bool ret = true;

            if (Connection.State != System.Data.ConnectionState.Open)
            {
                ret = Connect(ConnectionString);
                //ret = Connect(ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString);
            }

            return ret;
        }

        public void Close()
        {
            Connection.Close();
        }

        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        public void EndTransaction()
        {
            // command.Dispose()
            SqlTransaction.Commit();
            Close();
        }

        public OracleConnection GetConnection()
        {
            return new OracleConnection();
        }

        public void Rollback()
        {
            SqlTransaction.Rollback();
        }


        public int ExecuteNonQuery(OracleCommand command)
        {
            int rowNumber = 0;
            try
            {
                rowNumber = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Close();
            }
            return rowNumber;
        }

        public OracleCommand CreateCommand(string strCommand)
        {
            OracleCommand command = new OracleCommand(strCommand, Connection);

            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        public OracleDataReader Select(OracleCommand command)
        {
            //command.Prepare();
            OracleDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }
    }
}
