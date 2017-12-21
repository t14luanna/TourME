using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class PlaceKindRepository : RepositoryBase<PlaceKind>, IPlaceKindRepository
    {
        public PlaceKindRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public PlaceKind GetPlaceKindByDescription(string description)
        {
            PlaceKind PlaceKind = this.DbContext.PlaceKinds.Where(p => p.Description == description).FirstOrDefault();
            return PlaceKind;
        }
    }

    public interface IPlaceKindRepository : IRepository<PlaceKind>
    {
        PlaceKind GetPlaceKindByDescription(string description);
    }
}
