using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TourMe.Model.Model;
using TourMe.Service;
using TourMe.ViewModel;

namespace TourMe.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IEventService _EventService;

        public EventsController(IEventService _EventService)
        {
            this._EventService = _EventService;
        }

        private TMEntities db = new TMEntities();

        // GET: api/Events
        public IQueryable<Event> GetEvents()
        {
            return db.Events;
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> GetEvent(int id)
        {
            Event @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        //GET: Event by PlaceId 
        public IHttpActionResult getEventByPlaceId(int id)
        {


            return Ok();
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Events
        public IHttpActionResult PostEvent(EventViewModel evm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Event e = new Event();
            e.PlaceId = evm.PlaceId;
            e.Title = evm.Title;
            e.Url = evm.Url;
            e.EventKindId = evm.EventKindId;
            e.DateStart = evm.DateStart;
            e.DateEnd = evm.DateEnd;
            e.DateCreate = DateTime.Today;
            e.Description = evm.Description;
            e.Priority = 0;

            db.Events.Add(e);

            return Ok();
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> DeleteEvent(int id)
        {
            Event @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            await db.SaveChangesAsync();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.Id == id) > 0;
        }
    }
}