using ActividadPractica01.Data.Interfaces;
using ActividadPractica01.Data.Repository;
using ActividadPractica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadPractica01.Services
{
    public class ArticleManager
    {
        private IArticleRepository _repository;

        public ArticleManager()
        {
            _repository = new ArticleRepository();
        }

        public List<Article> GetAllArticles()
        {
            return _repository.GetAll();
        }

        public Article GetArticleById(int id)
        {
            return _repository.GetById(id);
        }

        public bool SaveArticle(Article oArticle)
        {
            return _repository.Save(oArticle);
        }

        public bool DeleteArticle(int id)
        {
            return _repository.Delete(id);
        }
    }
}
