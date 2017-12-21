using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class TripBookHasPlaceRepository : RepositoryBase<TripBookHasPlace>, ITripBookHasPlaceRepository
    {
        public TripBookHasPlaceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<TripBookHasPlace> GetTripBookHasPlaceByPlaceId(int PlaceId)
        {
            IEnumerable<TripBookHasPlace> TripBookHasPlaces = this.DbContext.TripBookHasPlaces.Where(p => p.PlaceId == PlaceId);
            return TripBookHasPlaces;
        }

        public IEnumerable<TripBookHasPlace> GetTripBookHasPlaceByTripBookId(int TripBookId)
        {
            IEnumerable<TripBookHasPlace> TripBookHasPlaces = this.DbContext.TripBookHasPlaces.Where(p => p.TripBookId == TripBookId);
            return TripBookHasPlaces;
        }

        public IEnumerable<TripBookHasPlace> GetTripBookHasPlacesTraveled()
        {
            IEnumerable<TripBookHasPlace> TripBookHasPlaces = this.DbContext.TripBookHasPlaces.Where(p => p.isTraveled == true);
            return TripBookHasPlaces;
        }
    }

    public interface ITripBookHasPlaceRepository : IRepository<TripBookHasPlace>
    {
        IEnumerable<TripBookHasPlace> GetTripBookHasPlaceByPlaceId(int PlaceId);
        IEnumerable<TripBookHasPlace> GetTripBookHasPlaceByTripBookId(int TripBookId);
        IEnumerable<TripBookHasPlace> GetTripBookHasPlacesTraveled();
    }
}
