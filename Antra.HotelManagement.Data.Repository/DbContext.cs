using System;
using System.Collections.Generic;
//using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
namespace Antra.CustomerApp.Data.Repository
{
    class DbContext
    {
        string conn;
        public DbContext()
        {
            conn = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build().GetConnectionString("demo");
        }
        public int Execute(string cmdText, Dictionary<string, object> parameters = null, CommandType cmdType = CommandType.Text)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                cmd.Connection = connection;
                int r = cmd.ExecuteNonQuery(); //insert update delete.

                return r;
            }
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return -1;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
        }
        public DataTable Query(string cmdText, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();

            try
            {
                connection.Open();
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                cmd.Connection = connection;

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return null;
        }

    }
}
