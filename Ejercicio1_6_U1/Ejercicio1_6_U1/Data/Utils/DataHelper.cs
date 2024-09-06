using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_6_U1.Data.Utils
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        public DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }

        public static DataHelper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public DataTable ExecuteSP(string spName, List<Parameter> parameters)
        {
            DataTable? dt = new DataTable();

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(spName, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                }

                dt.Load(cmd.ExecuteReader());

                _connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                dt = null;
                _connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                dt = null;
                _connection.Close();
            }
            finally
            {
                if (dt != null && _connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return dt;
        }

        public int ExecuteSPDML(string spName, List<Parameter> parameters)
        {
            int rowsAfected;

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(spName, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                }

                rowsAfected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                rowsAfected = 0;
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                rowsAfected = 0;
                _connection.Close();
            }

            return rowsAfected;
        }
    }
}
