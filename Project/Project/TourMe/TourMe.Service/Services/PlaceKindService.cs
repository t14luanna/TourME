using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Data.Repositories;
using TourMe.Model.Model;

namespace TourMe.Service
{
    public interface IPlaceKindService
    {
        IEnumerable<PlaceKind> GetPlaceKinds(string name = null);
        PlaceKind GetPlaceKind(int id);
        PlaceKind GetPlaceKind(string description);
        void CreatePlaceKind(PlaceKind PlaceKind);
        void EditPlaceKind(PlaceKind PlaceKind);
        void RemovePlaceKind(int id);
        void SavePlaceKind();
        void UnRemovePlaceKind(int id);
    }

    public class PlaceKindService : IPlaceKindService
    {
        private readonly IPlaceKindRepository PlaceKindRepository;
        private readonly IPlaceRepository PlaceRepository;
        private readonly IUnitOfWork unitOfWork;

        //Constructor
        public PlaceKindService(IPlaceKindRepository PlaceKindRepository, IPlaceRepository PlaceRepository, IUnitOfWork unitOfWork)
        {
            this.PlaceKindRepository = PlaceKindRepository;
            this.PlaceRepository = PlaceRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreatePlaceKind(PlaceKind PlaceKind)
        {
            PlaceKindRepository.Add(PlaceKind);
            SavePlaceKind();
        }

        public void EditPlaceKind(PlaceKind PlaceKind)
        {
            PlaceKind pk = PlaceKindRepository.GetById(PlaceKind.Id);
            if(pk != null)
            {
                pk.Kind = PlaceKind.Kind;
                pk.Description = PlaceKind.Description;
                SavePlaceKind();
            }
        }

        public PlaceKind GetPlaceKind(int id)
        {
            PlaceKind pk = PlaceKindRepository.GetById(id);
            return pk;
        }

        public PlaceKind GetPlaceKind(string desscription)
        {
            PlaceKind pk = PlaceKindRepository.GetPlaceKindByDescription(desscription);
            return pk;
        }

        public IEnumerable<PlaceKind> GetPlaceKinds(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return PlaceKindRepository.GetAll();
            else
                return PlaceKindRepository.GetAll().Where(c => c.Description.Equals(name));
        }

        public void RemovePlaceKind(int id)
        {
            PlaceKind pk = PlaceKindRepository.GetById(id);
            if(pk != null)
            {
                PlaceKindRepository.Delete(pk);
            }
        }

        public void SavePlaceKind()
        {
            unitOfWork.Commit();
        }

        public void UnRemovePlaceKind(int id)
        {
            throw new NotImplementedException();
        }

        private void updatePlaces()
        {
            var places = PlaceRepository.GetAll();
            foreach(Place place in places)
            {

            }
        }
    }
}
