using TourMe.Data.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Model.Model;
using System.Globalization;

namespace TourMe.Data.Repositories
{
    public class PlaceRepository : RepositoryBase<Place>, IPlaceRepository
    {
        public PlaceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Place GetById(int? placeId)
        {
            if(placeId != null)
            {
                Place place = this.DbContext.Places.Where(p => p.Id == placeId).FirstOrDefault();
                return place;
            }
            return null;
        }

        public Place GetPlaceByAddress(string address)
        {
            Place place = this.DbContext.Places.Where(p => p.Address == address).FirstOrDefault();
            return place;
        }

        public Place GetPlaceByName(string placeName)
        {
            Place place = this.DbContext.Places.Where(p => p.Name == placeName).FirstOrDefault();
            return place;
        }

        public List<Place> GetPlaceNearBy(float longitude, float latitude, float distance, int scope)
        {
            List<Place> places = this.DbContext.Places.Where(p => ((Math.Abs((p.Longitude - longitude)) < distance) && (Math.Abs((p.Latitude - latitude)) < distance)) && (p.PlaceKindId == scope)).Take(20).ToList();
            return places;
        }

        public List<Place> SearchPlacesByPopular(string search)
        {
            //List<Place> places = this.DbContext.Places.Where(p => (p.Name.Contains(search)) || (p.Address.Contains(search))).OrderBy(p => p.Poppular).Take(10).ToList();
            //List<Place> places = this.DbContext.Places.Where(p => (p.Name.StartsWith(search) || (p.Name.Contains(" " + search)))).OrderBy(p => p.Poppular).Take(10).ToList();
            List<Place> places = this.DbContext.Places.Where(p => (p.Definition.StartsWith(search) || (p.Definition.Contains(" " + search)))).OrderByDescending(p => p.Poppular).Take(10).ToList();

            return places;
        }
    }

    public interface IPlaceRepository : IRepository<Place>
    {
        Place GetPlaceByAddress(string address);
        Place GetPlaceByName(string placeName);
        List<Place> SearchPlacesByPopular(string search);
        List<Place> GetPlaceNearBy(float longitude, float latitude, float distance, int scope);
        Place GetById(int? placeId);
    }
}
