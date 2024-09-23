using ActividadPractica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Data.Interfaces
{
    public interface IArticleRepository
    {
        List<Article> GetAll();
        Article GetById(int id);
        bool Save(Article oArticle);
        bool Delete(int id);
    }
}
