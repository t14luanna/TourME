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
    public interface ITripBookHasPlaceService
    {
        IEnumerable<TripBookHasPlace> GetTripBookHasPlaces(string name = null);
        IEnumerable<TripBookHasPlace> GetTripBookHasPlacesTravled();
        IEnumerable<TripBookHasPlace> GetTripBookHasPlacesRemoved();
        IEnumerable<TripBookHasPlace> GetTripBookHasPlacesByTripBookId(int TripBookId);
        IEnumerable<TripBookHasPlace> GetTripBookHasPlacesByPlaceId(int PlaceId);
        TripBookHasPlace GetTripBookHasPlace(int Id);
        void CreateTripBookHasPlace(TripBookHasPlace TripBookHasPlace);
        void EditTripBookHasPlace(TripBookHasPlace TripBookHasPlace);
        void RemoveTripBookHasPlace(int id);
        void SaveTripBookHasPlace();
        void UnRemoveTripBookHasPlace(int id);
    }

    public class TripBookHasPlaceService : ITripBookHasPlaceService
    {
        private readonly ITripBookHasPlaceRepository TripBookHasPlaceRepository;
        private readonly IUnitOfWork unitOfWork;

        public TripBookHasPlaceService(ITripBookHasPlaceRepository TripBookHasPlaceRepository, IUnitOfWork unitOfWork)
        {
            this.TripBookHasPlaceRepository = TripBookHasPlaceRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTripBookHasPlace(TripBookHasPlace TripBookHasPlace)
        {
            throw new NotImplementedException();
        }

        public void EditTripBookHasPlace(TripBookHasPlace TripBookHasPlace)
        {
            throw new NotImplementedException();
        }

        public TripBookHasPlace GetTripBookHasPlace(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TripBookHasPlace> GetTripBookHasPlaces(string name = null)
        {
            return TripBookHasPlaceRepository.GetAll();
        }

        public IEnumerable<TripBookHasPlace> GetTripBookHasPlacesByPlaceId(int PlaceId)
        {
            return TripBookHasPlaceRepository.GetAll().Where(t => t.PlaceId == PlaceId);
        }

        public IEnumerable<TripBookHasPlace> GetTripBookHasPlacesByTripBookId(int TripBookId)
        {
            return TripBookHasPlaceRepository.GetAll().Where(t => t.TripBookId == TripBookId);
        }

        public IEnumerable<TripBookHasPlace> GetTripBookHasPlacesRemoved()
        {
            return TripBookHasPlaceRepository.GetAll().Where(t => t.isRemoved == true);
        }

        public IEnumerable<TripBookHasPlace> GetTripBookHasPlacesTravled()
        {
            return TripBookHasPlaceRepository.GetAll().Where(t => t.isTraveled == true);
        }

        public void RemoveTripBookHasPlace(int Id)
        {
            TripBookHasPlace tbhp = TripBookHasPlaceRepository.GetById(Id);
            if(tbhp != null)
            {
                tbhp.isRemoved = true;
            }
        }

        public void SaveTripBookHasPlace()
        {
            unitOfWork.Commit();
        }

        public void UnRemoveTripBookHasPlace(int Id)
        {
            TripBookHasPlace tbhp = TripBookHasPlaceRepository.GetById(Id);
            if (tbhp != null)
            {
                tbhp.isRemoved = false;
            }
        }
    }
}
