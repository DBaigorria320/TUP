using Ejercicio1_6_U1.Data.Interfaces;
using Ejercicio1_6_U1.Data.Utils;
using Ejercicio1_6_U1.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_6_U1.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private string spName;
        private List<Parameter> parameters;
        private List<Account> accounts;
        private DataHelper helper = DataHelper.GetInstance();
        private DataTable dt;

        public List<Account> GetAll()
        {
            spName = "SP_Obtener_Cuentas";

            dt = helper.ExecuteSP(spName, null);

            if(dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    int id = (int)dr[0];
                    string cbu = dr[1].ToString();
                    double balance = (double)dr[2];
                    string lastMovement = dr[3].ToString();

                    Account a = new Account()
                    {
                        Id = id,
                        Cbu = cbu,
                        Balance = balance,
                        LastMovement = lastMovement
                    };

                    accounts.Add(a);
                }
                return accounts;
            }
            return null;
        }

        public Account GetById(int id)
        {
            spName = "SP_Obtener_Cuenta";

            parameters.Add(new Parameter("@id", id));

            dt = helper.ExecuteSP(spName, parameters);

            if(dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                int idAcc = (int)row[0];
                string cbu = row[1].ToString();
                double balance = (double)row[2];
                string lastMovement = row[3].ToString();

                Account a = new Account()
                {
                    Id = idAcc,
                    Cbu = cbu,
                    Balance = balance,
                    LastMovement = lastMovement
                };

                return a;
            }

            return null;
        }
    }
}
