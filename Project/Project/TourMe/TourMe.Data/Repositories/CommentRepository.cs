using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Comment> GetCommentsByKind(string Kind)
        {
            IEnumerable<Comment> comments = this.DbContext.Comments.Where(p => p.Kind == Kind).ToList();
            return comments;
        }

        public IEnumerable<Comment> GetCommentsByUserId(int userID)
        {
            IEnumerable<Comment> comments = this.DbContext.Comments.Where(p => p.UserId == userID).ToList();
            return comments;
        }
    }

    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetCommentsByKind(string Comment);
        IEnumerable<Comment> GetCommentsByUserId(int userID);
    }
}
