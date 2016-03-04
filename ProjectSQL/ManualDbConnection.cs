using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSQL
{
    class ManualDbConnection
    {
        private static SqlConnection connection = new SqlConnection(Settings1.Default.DBConnection);

        public static DataTable Select(string command)
        {
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool Change(SqlCommand command)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
