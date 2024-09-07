using ActividadPractica01.Data.Interfaces;
using ActividadPractica01.Data.Utils;
using ActividadPractica01.Domain;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadPractica01.Services;

namespace ActividadPractica01.Data.Repository
{
    public class ReceipRepository : IReceipRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Receip> GetAll()
        {
            DataHelper helper = DataHelper.GetInstance();
            DataTable dt = new DataTable();
            List<Receip> receips = new List<Receip>();
            PaymentMethodManager paymentMethodManager = new PaymentMethodManager();
            string spName = "SP_Obtener_Facturas";

            dt = helper.ExecuteSP(spName, null);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int nroFactura = (int)dr[0];
                    DateTime fecha = (DateTime)dr[1];
                    int idFormaPago = (int)dr[2];
                    string cliente = (string)dr[3];

                    Receip receip = new Receip()
                    {
                        NroReceip = nroFactura,
                        Date = fecha,
                        PaymentMethod = paymentMethodManager.GetPaymentMethodById(idFormaPago),
                        Client = cliente
                    };

                    receips.Add(receip);
                }
                return receips;
            }
            return null;
        }

        public Receip GetById(int id)
        {
            DataHelper helper = DataHelper.GetInstance();
            DataTable dt = new DataTable();
            List<Parameter> parameters = new List<Parameter>();
            PaymentMethodManager paymentMethodManager = new PaymentMethodManager();
            string spName = "SP_Obtener_Factura";

            parameters.Add(new Parameter("@id", id));

            dt = helper.ExecuteSP(spName, parameters);

            if(dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                int nroFactura = (int)dr[0];
                DateTime fecha = (DateTime)dr[1];
                int idFormaPago = (int)dr[2];
                string cliente = (string)dr[3];

                return new Receip()
                {
                    NroReceip = nroFactura,
                    Date = fecha,
                    PaymentMethod = paymentMethodManager.GetPaymentMethodById(idFormaPago),
                    Client = cliente
                };
            }
            return null;
        }

        public bool Save(Receip receip)
        {
            SqlConnection sqlConn = null;
            SqlTransaction sqlTransaction = null;
            DataHelper helper = DataHelper.GetInstance();
            string spName = "SP_Insertar_Maestro";
            bool result = false;

            try
            {
                sqlConn = helper.GetConnection();
                sqlConn.Open();
                sqlTransaction = sqlConn.BeginTransaction();

                var cmd = new SqlCommand(spName, sqlConn, sqlTransaction);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_forma_pago", receip.PaymentMethod.Id);
                cmd.Parameters.AddWithValue("@cliente", receip.Client);

                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int idFactura = (int)param.Value;

                foreach (var dr in receip.DetailsReceip)
                {
                    var cmdDetalle = new SqlCommand("SP_Insertar_Detalle", sqlConn, sqlTransaction);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@id_articulo", dr.Article.Id);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dr.Amount);
                    cmdDetalle.Parameters.AddWithValue("@id_factura", idFactura);

                    cmdDetalle.ExecuteNonQuery();
                }

                sqlTransaction.Commit();
                result = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
                if (sqlTransaction != null)
                {
                    sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
                if (sqlTransaction != null)
                {
                    sqlTransaction.Rollback();
                }
            }
            finally
            {
                if(sqlConn != null && sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return result;
        }
    }
}
