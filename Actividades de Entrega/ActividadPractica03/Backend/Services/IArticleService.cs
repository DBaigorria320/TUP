using ActividadPractica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Services
{
    public interface IArticleService
    {
        List<Article> GetArticles();
        Article GetArticleById(int id);
        bool AddArticle(Article a);
        bool DeletedArticle(int id); 
    }
}
