using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Article GetArticleByTitle(string ArticleTitle)
        {
            Article Article = this.DbContext.Articles.Where(p => p.Title == ArticleTitle).FirstOrDefault();
            return Article;
        }
    }

    public interface IArticleRepository : IRepository<Article>
    {
        Article GetArticleByTitle(string ArticleTitle);
    }
}
