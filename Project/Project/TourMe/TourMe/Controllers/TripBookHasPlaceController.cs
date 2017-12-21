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
    public class TripBookHasPlaceController : ApiController
    {
        private readonly ITripBookHasPlaceService _TripBookHasPlaceService;

        //Constructor
        public TripBookHasPlaceController(ITripBookHasPlaceService _TripBookHasPlaceService)
        {
            this._TripBookHasPlaceService = _TripBookHasPlaceService;
        }

        //Get all TripBookHasPlace
        public IHttpActionResult Get()
        {
            var TripBookHasPlaces = _TripBookHasPlaceService.GetTripBookHasPlaces();
            List<TripBookHasPlaceViewModel> tbhpvms = new List<TripBookHasPlaceViewModel>();
            foreach (var tbhp in TripBookHasPlaces)
            {
                TripBookHasPlaceViewModel tbhpvm = new TripBookHasPlaceViewModel();
                tbhpvm.Id = tbhp.Id;
                tbhpvm.DateCreate = tbhp.DateCreate;
                tbhpvm.isRemoved = tbhp.isRemoved;
                tbhpvm.isTraveled = tbhp.isTraveled;
                tbhpvm.PlaceId = tbhp.PlaceId;
                tbhpvm.TripBookId = tbhp.TripBookId;
                tbhpvm.Vendor = tbhp.Vendor;
                tbhpvms.Add(tbhpvm);
            }
            return Ok(tbhpvms);
        }

        //Update TripBookHasPlace
        public IHttpActionResult Update(TripBookHasPlaceViewModel tbhpvm)
        {
            var tbhp = _TripBookHasPlaceService.GetTripBookHasPlace(tbhpvm.Id);
            if(tbhp != null)
            {
                tbhpvm.Id = tbhp.Id;
                tbhpvm.DateCreate = tbhp.DateCreate;
                tbhpvm.isRemoved = tbhp.isRemoved;
                tbhpvm.isTraveled = tbhp.isTraveled;
                tbhpvm.PlaceId = tbhp.PlaceId;
                tbhpvm.TripBookId = tbhp.TripBookId;
                tbhpvm.Vendor = tbhp.Vendor;
                _TripBookHasPlaceService.EditTripBookHasPlace(tbhp);
            }
            return Ok();
        }

        //Destroy TripBookHasPlace By Id
        public IHttpActionResult Destroy(int id)
        {
            var tbhp = _TripBookHasPlaceService.GetTripBookHasPlace(id);
            if (tbhp != null)
            {
                tbhp.isRemoved = true;
            }
            return Ok();
        }

        //Destroy TripBookHasPlace by ViewModel
        public IHttpActionResult Destroy(TripBookHasPlaceViewModel TripBookHasPlaceViewModel)
        {
            var tbhp = _TripBookHasPlaceService.GetTripBookHasPlace(TripBookHasPlaceViewModel.Id);
            if (tbhp != null)
            {
                tbhp.isRemoved = true;
            }
            return Ok();
        }

        //Create all TripBookHasPlace
        [HttpPost]
        public IHttpActionResult Create(TripBookHasPlaceViewModel tbhpvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TripBookHasPlace tbhp = new TripBookHasPlace();
            tbhp.Id = tbhp.Id;
            tbhp.DateCreate = tbhpvm.DateCreate;
            tbhp.isRemoved = tbhpvm.isRemoved;
            tbhp.isTraveled = tbhpvm.isTraveled;
            tbhp.PlaceId = tbhpvm.PlaceId;
            tbhp.TripBookId = tbhpvm.TripBookId;
            tbhp.Vendor = tbhpvm.Vendor;
            _TripBookHasPlaceService.CreateTripBookHasPlace(tbhp);
            return Ok();
        }
    }
}
