using Ejercicio1_6_U1.Data.Interfaces;
using Ejercicio1_6_U1.Data.Utils;
using Ejercicio1_6_U1.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_6_U1.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private bool result = false;
        private string spName;
        private DataTable dt;
        private List<Parameter> parameters;
        private List<Client> clients;
        private DataHelper helper = DataHelper.GetInstance();

        public List<Client> GetAll()
        {
            spName = "SP_Obtener_CLientes";
            dt = helper.ExecuteSP(spName, null);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int id = (int)dr[0];
                    string name = dr[1].ToString();
                    string surname = dr[2].ToString();
                    string dni = dr[3].ToString();

                    Client c = new Client()
                    {
                        Id = id,
                        Name = name,
                        Surname = surname,
                        Dni = dni
                    };

                    clients.Add(c);
                }

                return clients;
            }

            return null;
        }

        public Client GetById(int id)
        {
            spName = "SP_Obtener_Cliente";

            parameters.Add(new Parameter("@id", id));

            dt = helper.ExecuteSP(spName, parameters);

            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                int idClient = (int)row[0];
                string name = row[1].ToString();
                string surname = row[2].ToString();
                string dni = row[3].ToString();

                return new Client()
                {
                    Id = idClient,
                    Name = name,
                    Surname = surname,
                    Dni = dni
                };
            }

            return null;
        }

        public bool Save(Client oClient)
        {
            SqlConnection cnn = null;
            SqlTransaction transaction = null;
            spName = "SP_Insertar_Cliente";

            try
            {
                cnn = helper.GetConnection();
                cnn.Open();
                transaction = cnn.BeginTransaction();

                var cmd = new SqlCommand(spName, cnn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", oClient.Name);
                cmd.Parameters.AddWithValue("@apellido", oClient.Surname);
                cmd.Parameters.AddWithValue("@dni", oClient.Dni);

                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int clientId = (int)param.Value;

                foreach (var account in oClient.Accounts)
                {
                    var cmdAccount = new SqlCommand("SP_Insertar_Cuenta", cnn, transaction);
                    cmdAccount.CommandType = CommandType.StoredProcedure;

                    cmdAccount.Parameters.AddWithValue("@cbu", account.Cbu);
                    cmdAccount.Parameters.AddWithValue("@saldo", account.Balance);
                    cmdAccount.Parameters.AddWithValue("@tipo_cuenta", account.TypeAccount.Id);
                    cmdAccount.Parameters.AddWithValue("@cliente", clientId);
                    cmdAccount.Parameters.AddWithValue("@ult_movimiento", account.LastMovement);

                    cmdAccount.ExecuteNonQuery();
                }

                transaction.Commit();
                result = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
