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
    public class PlaceKindController : ApiController
    {
        private readonly IPlaceKindService _PlaceKindService;

        //Constructor
        public PlaceKindController(IPlaceKindService _PlaceKindService)
        {
            this._PlaceKindService = _PlaceKindService;
        }

        //Get all PlaceKind
        public IHttpActionResult Get()
        {
            var PlaceKinds = _PlaceKindService.GetPlaceKinds();
            List<PlaceKindViewModel> pkvms = new List<PlaceKindViewModel>();
            foreach (var pk in PlaceKinds)
            {
                PlaceKindViewModel pkvm = new PlaceKindViewModel();
                pkvm.Id = pk.Id;
                pkvm.Kind = pk.Kind;
                pkvm.Description = pk.Description;
                pkvm.DateCreate = pk.DateCreate;
                pkvms.Add(pkvm);
            }
            return Ok(pkvms);
        }

        //Update PlaceKind
        public IHttpActionResult Update(PlaceKindViewModel PlaceKindViewModel)
        {
            var pk = _PlaceKindService.GetPlaceKind(PlaceKindViewModel.Id);
            pk.Kind = PlaceKindViewModel.Kind;
            pk.Description = PlaceKindViewModel.Description;
            pk.DateCreate = DateTime.Now;
            _PlaceKindService.EditPlaceKind(pk);
            return Ok();
        }

        //Destroy PlaceKind By Id
        public IHttpActionResult Destroy(int id)
        {
            _PlaceKindService.RemovePlaceKind(id);
            return Ok();
        }

        //Destroy PlaceKind by ViewModel
        public IHttpActionResult Destroy(PlaceKindViewModel PlaceKindViewModel)
        {
            _PlaceKindService.RemovePlaceKind(PlaceKindViewModel.Id);
            return Ok();
        }

        //Create all PlaceKind
        [HttpPost]
        public IHttpActionResult Create(PlaceKindViewModel placeKind)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PlaceKind pk = new PlaceKind();
            pk.Kind = placeKind.Kind;
            pk.Description = placeKind.Description;
            pk.Priority = placeKind.Priority;
            pk.DateCreate = DateTime.Now;
            _PlaceKindService.CreatePlaceKind(pk);
            return Ok();
        }
    }
}
