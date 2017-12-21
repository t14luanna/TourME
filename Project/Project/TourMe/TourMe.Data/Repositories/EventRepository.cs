using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Event GetById(int? eventId)
        {
            if(eventId != null)
            {
                Event e = this.DbContext.Events.Where(p => p.Id == eventId).FirstOrDefault();
                return e;
            }
            return null;
        }

        public Event GetEventByTitle(string EventTitle)
        {
            Event Event = this.DbContext.Events.Where(p => p.Title == EventTitle).FirstOrDefault();
            return Event;
        }

        public IEnumerable<Event> GetEventsByEventKindId(int eventKindId)
        {
            IEnumerable<Event> events = this.DbContext.Events.Where(p => p.EventKindId == eventKindId).ToList();
            return events;
        }
    }

    public interface IEventRepository : IRepository<Event>
    {
        Event GetEventByTitle(string title);
        IEnumerable<Event> GetEventsByEventKindId(int eventKindID);
        Event GetById(int? eventId);
    }
}
