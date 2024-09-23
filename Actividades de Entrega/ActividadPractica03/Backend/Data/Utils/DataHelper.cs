using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Data.Utils
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        public DataHelper()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-CJ11SSC;Initial Catalog=db_facturacion;Integrated Security=True");
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

                if(parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }

                dt.Load(cmd.ExecuteReader());

                _connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                dt = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                dt = null;
            }
            finally
            {
                if(dt != null && _connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return dt;
        }

        public int ExecuteSPDML(string spName, List<Parameter> parameters)
        {
            int rows = 0;

            try
            {
                _connection.Open();

                var cmd = new SqlCommand(spName, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if(parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }

                rows = cmd.ExecuteNonQuery();

                _connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                rows = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
                rows = 0;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return rows;
        }
    }
}
