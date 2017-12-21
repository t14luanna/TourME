using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class TripBookRepository : RepositoryBase<TripBook>, ITripBookRepository
    {
        public TripBookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<TripBook> GetTripBooksByUserId(int userId)
        {
            IEnumerable<TripBook> tripBooks = this.DbContext.TripBooks.Where(p => p.UserId == userId);
            return tripBooks;
        }
    }

    public interface ITripBookRepository : IRepository<TripBook>
    {
        IEnumerable<TripBook> GetTripBooksByUserId(int userId);
    }
}
