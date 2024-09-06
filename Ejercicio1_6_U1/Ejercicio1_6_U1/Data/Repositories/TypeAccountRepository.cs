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
    public class TypeAccountRepository : ITypeAccountRepository
    {
        private bool result = false;
        private string spName;
        private int rows;
        private List<TypeAccount> typeAccounts = new List<TypeAccount>();
        private List<Parameter> parameters = new List<Parameter>();
        private DataTable dt;
        private DataHelper helper = DataHelper.GetInstance();

        public bool Delete(int id)
        {
            parameters.Clear();
            parameters.Add(new Parameter("@id", id));

            spName = "SP_Eliminar_Tipo_Cuenta";

            rows = helper.ExecuteSPDML(spName, parameters);

            if (rows != 0)
            {
                result = true;
            }

            return result;
        }

        public List<TypeAccount> GetAll()
        {
            spName = "SP_Obtener_Tipos_Cuenta";
            dt = helper.ExecuteSP(spName, null);
            foreach (DataRow dr in dt.Rows)
            {
                int id = (int)dr[0];
                string name = (string)dr[1];

                TypeAccount ta = new TypeAccount()
                {
                    Id = id,
                    Name = name,
                };

                typeAccounts.Add(ta);
            }

            return typeAccounts;
        }

        public TypeAccount GetById(int id)
        {
            spName = "SP_Obtener_Tipo_Cuenta";

            parameters.Clear();
            parameters.Add(new Parameter("@id", id));

            dt = helper.ExecuteSP(spName, parameters);

            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];

                int idType = (int)row[0];
                string name = (string)row[1];

                TypeAccount ta = new TypeAccount()
                {
                    Id = idType,
                    Name = name,
                };

                return ta;
            }

            return null;
        }

        public bool Save(TypeAccount oTypeAccount)
        {
            spName = "SP_Guardar_Tipo_Cuenta";
            parameters.Clear();
            
            if (oTypeAccount != null)
            {
                parameters.Add(new Parameter("@nombre", oTypeAccount.Name));
                
                rows = helper.ExecuteSPDML(spName, parameters);
            }

            if(rows != 0)
            {
                result = true;
            }

            return result;
        }
    }
}
