using ActividadPractica01.Data.Interfaces;
using ActividadPractica01.Data.Utils;
using ActividadPractica01.Domain;
using ActividadPractica01.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Data.Repository
{
    public class DetailReceipRepository : IDetailReceipRepository
    {
        private string spName;
        private List<DetailReceip> detailsReceip;
        private List<Parameter> parameters;
        private DataHelper helper;
        private DataTable dt;
        private ArticleManager articleManager;

        public List<DetailReceip> GetAll()
        {
            helper = DataHelper.GetInstance();
            spName = "SP_Obtener_Detalles_Factura";
            dt = new DataTable();

            dt = helper.ExecuteSP(spName, null);

            if(dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    int idDetalle = (int)dr[0];
                    int idArticulo = (int)dr[1];
                    int cantidad = (int)dr[2];

                    DetailReceip detailReceip = new DetailReceip()
                    {
                        Id = idDetalle,
                        Article = articleManager.GetArticleById(idArticulo),
                        Amount = cantidad
                    };

                    detailsReceip.Add(detailReceip);
                }
                return detailsReceip;
            }
            return null;
        }

        public DetailReceip GetById(int id)
        {
            helper = DataHelper.GetInstance();
            spName = "SP_Obtener_Detalle_Factura";
            dt = new DataTable();
            parameters = [new Parameter("@id", id)];

            dt = helper.ExecuteSP(spName, parameters);

            if(dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                int idDetalle = (int)dr[0];
                int idArticulo = (int)dr[1];
                int cantidad = (int)dr[2];

                return new DetailReceip()
                {
                    Id = idDetalle,
                    Article = articleManager.GetArticleById (idArticulo),
                    Amount = cantidad
                };
            }
            return null;
        }
    }
}
