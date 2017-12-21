using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TourMe.Model.Model;
using TourMe.Service;
using TourMe.ViewModel;

namespace TourMe.Controllers
{
    public class TripBookController : ApiController
    {
        private readonly ITripBookService _TripBookService;

        //Constructor
        public TripBookController(ITripBookService _TripBookService)
        {
            this._TripBookService = _TripBookService;
        }

        //Get all TripBook
        public IHttpActionResult Get()
        {
            var TripBooks = _TripBookService.GetTripBooks();
            List<TripBookViewModel> tbvms = new List<TripBookViewModel>();
            foreach (var tb in TripBooks)
            {
                TripBookViewModel tbvm = new TripBookViewModel();
                tbvm.Id = tb.Id;
                tbvm.DateCreate = tb.DateCreate;
                tbvm.FeedBackId = tb.FeedBackId;
                tbvm.isRemoved = tb.isRemoved;
                tbvm.isTraveled = tb.isTraveled;
                tbvm.UserId = tb.UserId;
                tbvms.Add(tbvm);
            }
            return Ok(tbvms);
        }

        //Update TripBook
        public IHttpActionResult Update(TripBookViewModel TripBookViewModel)
        {
            var TripBook = _TripBookService.GetTripBook(TripBookViewModel.Id);
            TripBook.Id = TripBookViewModel.Id;
            TripBook.DateCreate = TripBookViewModel.DateCreate;
            TripBook.FeedBackId = TripBookViewModel.FeedBackId;
            TripBook.isRemoved = TripBookViewModel.isRemoved;
            TripBook.isTraveled = TripBookViewModel.isTraveled;
            TripBook.UserId = TripBookViewModel.UserId;
            _TripBookService.EditTripBook(TripBook);
            return Ok();
        }

        //Destroy TripBook By Id
        public IHttpActionResult Destroy(int id)
        {
            var TripBook = _TripBookService.GetTripBook(id);
            TripBook.isRemoved = true;
            _TripBookService.EditTripBook(TripBook);
            return Ok();
        }

        //Destroy TripBook by ViewModel
        public IHttpActionResult Destroy(TripBookViewModel TripBookViewModel)
        {
            var TripBook = _TripBookService.GetTripBook(TripBookViewModel.Id);
            TripBook.isRemoved = true;
            _TripBookService.EditTripBook(TripBook);
            return Ok();
        }

        //Create TripBook
        [HttpPost]
        public IHttpActionResult Create(TripBookViewModel tripBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TripBook tb = new TripBook();
            tb.Id = tripBookViewModel.Id;
            tb.DateCreate = tripBookViewModel.DateCreate;
            tb.FeedBackId = tripBookViewModel.FeedBackId;
            tb.isRemoved = tripBookViewModel.isRemoved;
            tb.isTraveled = tripBookViewModel.isTraveled;
            tb.UserId = tripBookViewModel.UserId;
            _TripBookService.CreateTripBook(tb);
            return Ok();
        }
    }
}
