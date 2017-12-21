using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class ArticleKindRepository : RepositoryBase<ArticleKind>, IArticleKindRepository
    {
        public ArticleKindRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public ArticleKind GetArticleKindByKind(string Kind)
        {
            ArticleKind ArticleKind = this.DbContext.ArticleKinds.Where(p => p.Kind == Kind).FirstOrDefault();
            return ArticleKind;
        }
    }

    public interface IArticleKindRepository : IRepository<ArticleKind>
    {
        ArticleKind GetArticleKindByKind(string ArticleKind);
    }

}
