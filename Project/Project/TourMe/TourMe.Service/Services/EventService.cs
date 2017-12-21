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
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(string name = null);
        IEnumerable<Event> GetEventsByPlaceId(int placeId);
        Event GetEvent(int Id);
        void CreateEvent(Event Event);
        void EditEvent(Event Event);
        void RemoveEvent(int id);
        void SaveEvent();
        void UnRemoveEvent(int id);
        Event GetEvent(int? eventId);
    }

    public class EventService : IEventService
    {
        private readonly IEventRepository EventRepository;
        private readonly IUnitOfWork unitOfWork;

        //Constructor
        public EventService(IEventRepository EventRepository, IUnitOfWork unitOfWork)
        {
            this.EventRepository = EventRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateEvent(Event Event)
        {
            EventRepository.Add(Event);
            SaveEvent();
        }

        public void EditEvent(Event aevent)
        {
            Event e = EventRepository.GetById(aevent.Id);
            if (e != null)
            {
                e.PlaceId = aevent.PlaceId;
                e.Place = aevent.Place;
                e.Title = aevent.Title;
                e.Url = aevent.Url;
            }
            SaveEvent();
        }

        public Event GetEvent(int Id)
        {
            Event tb = EventRepository.GetById(Id);
            if (tb != null)
            {
                return tb;
            }
            return null;
        }

        public Event GetEvent(int? eventId)
        {
            if (eventId != null)
            {
                Event e = EventRepository.GetById(eventId);
                return null;
            }
            return null;
        }

        public IEnumerable<Event> GetEvents(string name = null)
        {
            IEnumerable<Event> tbs = EventRepository.GetAll();
            return tbs;
        }

        public IEnumerable<Event> GetEventsByPlaceId(int placeId)
        {
            IEnumerable<Event> tbs = EventRepository.GetAll().Where(t => t.PlaceId == placeId);
            return tbs;
        }

        public void RemoveEvent(int id)
        {
            
        }

        public void SaveEvent()
        {
            unitOfWork.Commit();
        }

        public void UnRemoveEvent(int id)
        {
            
        }
    }
}
