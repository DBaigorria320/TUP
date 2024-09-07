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
    public class ArticleRepository : IArticleRepository
    {
        private string spName;
        private int rows;
        private bool result;
        private List<Article> articles;
        private List<Parameter> parameters;
        private DataTable dt;
        private DataHelper helper;

        public bool Delete(int id)
        {
            helper = DataHelper.GetInstance();
            spName = "SP_Eliminar_Articulo";
            rows = 0;

            parameters = [new Parameter("@id", id)];

            rows = helper.ExecuteSPDML(spName, parameters);

            if (rows != 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public List<Article> GetAll()
        {
            dt = new DataTable();
            spName = "SP_Obtener_Articulos";
            helper = DataHelper.GetInstance();
            articles = new List<Article>();

            dt = helper.ExecuteSP(spName, null);

            if(dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int id = (int)dr[0];
                    string nombre = dr[1].ToString();
                    double precio = Convert.ToDouble(dr[2]);

                    Article a = new Article()
                    {
                        Id = id,
                        Name = nombre,
                        Price = precio
                    };

                    articles.Add(a);
                }
                return articles;
            }
            return null;

        }

        public Article GetById(int id)
        {
            dt = new DataTable();
            spName = "SP_Obtener_Articulo";
            helper = DataHelper.GetInstance();
            parameters = [new Parameter("@id", id)];

            dt = helper.ExecuteSP(spName, parameters);

            if(dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];

                int idArticle = (int)row[0];
                string nombre = row[1].ToString();
                double precio = (double)row[2];

                return new Article()
                {
                    Id = idArticle,
                    Name = nombre,
                    Price = precio
                };
            }
            return null;
        }

        public bool Save(Article oArticle)
        {
            rows = 0;
            helper = DataHelper.GetInstance();
            spName = "SP_Guardar_Articulo";

            parameters =
            [
                new Parameter("@nombre", oArticle.Name),
                new Parameter("@precio", oArticle.Price),
            ];

            rows = helper.ExecuteSPDML(spName, parameters);

            if( rows != 0 )
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
