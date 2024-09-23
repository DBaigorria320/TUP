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
    public class ArticleManager : IArticleService
    {
        private IArticleRepository _repository;

        public ArticleManager()
        {
            _repository = new ArticleRepository();
        }

        public bool AddArticle(Article a)
        {
            return _repository.Save(a);
        }

        public bool DeletedArticle(int id)
        {
            return _repository.Delete(id);
        }

        public Article GetArticleById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Article> GetArticles()
        {
            return _repository.GetAll();
        }
    }
}
