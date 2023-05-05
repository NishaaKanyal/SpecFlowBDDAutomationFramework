using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowProjectDemo.Hooks;

namespace SpecFlowProjectDemo.Utility
{
    public class CommonOperationUtils
    {

        public static List<object> OpenSqlConnection(string sqlQuery)
        {
            SqlCommand command; // reading and writing into sql db
            SqlDataReader dataReader; //used to get all data from sql query
            SqlConnection connection;
            String connectionString = HookInitialization.startup.connectionString.ToString();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                List<object> sqlResponse = new List<object>();
                command = new SqlCommand(sqlQuery, connection);
                dataReader = command.ExecuteReader();
                sqlResponse = GetSqlOutput(sqlQuery, connection, dataReader);
                dataReader.Close();
                command.Dispose();
                connection.Close();
                return sqlResponse;
            }
            catch (SqlException ex)
            {
                Assert.IsFalse(false, $"Failed_To_Initialize_DBConnection={ex.Message}");
                return null;
            }
        }

        public static List<object> GetSqlOutput(string sqlQuery, SqlConnection connection, SqlDataReader dataReader)
        {
            Dictionary<string, string> Output;
            List<object> sqlResponseList = new List<object>();
            try
            {
                var table = dataReader.GetSchemaTable();
                while (dataReader.Read())
                {
                    Output = new Dictionary<string, string>();
                    for (int columnIterator = 0; columnIterator < dataReader.FieldCount; columnIterator++)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            Output.Add(row.Field<string>("ColumnName"), dataReader.GetValue(columnIterator).ToString());
                            columnIterator++;
                        }
                    }
                    sqlResponseList.Add(Output);
                }
                return sqlResponseList;
            }
            catch (SqlException ex)
            {
                Assert.IsFalse(false, $"Failed_To_Get_SQLResults={ex.Message}");
                return null;
            }
        }
    }
}
