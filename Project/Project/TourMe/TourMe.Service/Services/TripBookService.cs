using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data;
using TourMe.Data.Infrastucture;
using TourMe.Model.Model;

namespace TourMe.Service
{
    public interface ITripBookService
    {
        IEnumerable<TripBook> GetTripBooks(string name = null);
        IEnumerable<TripBook> GetTripBooksByUserId(int userId);
        TripBook GetTripBook(int Id);
        void CreateTripBook(TripBook TripBook);
        void EditTripBook(TripBook TripBook);
        void RemoveTripBook(int id);
        void SaveTripBook();
        void UnRemoveTripBook(int id);
    }

    public class TripBookService : ITripBookService
    {
        private readonly ITripBookRepository TripBookRepository;
        private readonly IUnitOfWork unitOfWork;

        //Constructor
        public TripBookService(ITripBookRepository TripBookRepository, IUnitOfWork unitOfWork)
        {
            this.TripBookRepository = TripBookRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTripBook(TripBook TripBook)
        {
            TripBookRepository.Add(TripBook);
            SaveTripBook();
        }

        public void EditTripBook(TripBook TripBook)
        {
            TripBook tb = TripBookRepository.GetById(TripBook.Id);
            if(tb != null)
            {
                tb.FeedBackId = TripBook.FeedBackId;
                tb.isRemoved = TripBook.isRemoved;
                tb.isTraveled = TripBook.isTraveled;
                tb.UserId = TripBook.UserId;
            }
        }

        public TripBook GetTripBook(int Id)
        {
            TripBook tb = TripBookRepository.GetById(Id);
            if(tb != null)
            {
                return tb;
            }
            return null;
        }

        public IEnumerable<TripBook> GetTripBooks(string name = null)
        {
            IEnumerable<TripBook> tbs = TripBookRepository.GetAll();
            return tbs;
        }

        public IEnumerable<TripBook> GetTripBooksByUserId(int userId)
        {
            IEnumerable<TripBook> tbs = TripBookRepository.GetAll().Where(t => t.UserId == userId);
            return tbs;
        }

        public void RemoveTripBook(int id)
        {
            TripBook tb = TripBookRepository.GetById(id);
            if(tb != null)
            {
                tb.isRemoved = true;
            }
        }

        public void SaveTripBook()
        {
            unitOfWork.Commit();
        }

        public void UnRemoveTripBook(int id)
        {
            TripBook tb = TripBookRepository.GetById(id);
            if (tb != null)
            {
                tb.isRemoved = false;
            }
        }
    }
}
