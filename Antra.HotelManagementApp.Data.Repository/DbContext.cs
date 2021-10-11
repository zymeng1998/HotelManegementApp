using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace Antra.HotelManagementApp.Data.Repository
{
    class DbContext
    {
        string conn;
        public DbContext()
        {
            conn = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build().GetConnectionString("CompanyDb");
        }

        public int Execute(string cmdText, Dictionary<string, object> parameters, CommandType cmdType= CommandType.Text)
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
                int r = cmd.ExecuteNonQuery(); //call this method to insert, update, delete

                return r;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return 0;
        }

        public DataTable Query(string cmdText, Dictionary<string, object> parameters, CommandType cmdType=CommandType.Text)
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

                /*
                 * DataReader is readonly
                 * datareader is forward only
                 * reader can be used in connected approach which mean a connection must be opened while using it
                 */
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {

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
