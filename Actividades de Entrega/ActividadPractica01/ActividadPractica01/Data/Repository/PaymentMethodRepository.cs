using ActividadPractica01.Data.Interfaces;
using ActividadPractica01.Data.Utils;
using ActividadPractica01.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Data.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private string spName;
        private int rows;
        private bool result;
        private List<PaymentMethod> paymentMethods;
        private List<Parameter> parameters;
        private DataHelper helper;
        private DataTable dt;

        public bool Delete(int id)
        {
            spName = "SP_Eliminar_Forma_Pago";
            helper = DataHelper.GetInstance();

            parameters = [new Parameter("@id", id)];

            rows = helper.ExecuteSPDML(spName, parameters);

            if(rows != 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public List<PaymentMethod> GetAll()
        {
            helper = DataHelper.GetInstance();
            paymentMethods = new List<PaymentMethod>();
            spName = "SP_Obtener_Formas_Pago";
            dt = new DataTable();

            dt = helper.ExecuteSP(spName, null);

            if(dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    int idMetodo = (int)dr[0];
                    string metodo = dr[1].ToString();

                    PaymentMethod oPM = new PaymentMethod()
                    {
                        Id = idMetodo,
                        Method = metodo
                    };
                    
                    paymentMethods.Add(oPM);
                }
                return paymentMethods;
            }
            return null;
        }

        public PaymentMethod GetById(int id)
        {
            helper = DataHelper.GetInstance();
            spName = "SP_Obtener_Forma_Pago";
            dt = new DataTable();
            parameters = [
                new Parameter("@id", id)
            ];

            dt = helper.ExecuteSP(spName, parameters);

            if(dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                int idMetodo = (int)row[0];
                string metodo = row[1].ToString();

                return new PaymentMethod()
                {
                    Id = idMetodo,
                    Method = metodo
                };
            }
            return null;
        }

        public bool Save(PaymentMethod oPaymentMethod)
        {
            helper = DataHelper.GetInstance();
            spName = "SP_Insertar_Forma_Pago";

            parameters = [
                new Parameter("@nombre", oPaymentMethod.Method)
            ];

            rows = helper.ExecuteSPDML(spName,parameters);

            if(rows != 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
