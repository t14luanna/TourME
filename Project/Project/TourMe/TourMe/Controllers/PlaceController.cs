using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using TourMe.Model.Model;
using TourMe.Service;
using TourMe.ViewModel;

namespace TourMe.Controllers
{
    public class PlaceController : ApiController
    {
        private readonly IPlaceService _PlaceService;
        private readonly IImageService _ImageService;
        private readonly IPlaceKindService _PlaceKindService;

        //Constructor
        public PlaceController(IPlaceService _PlaceService, IImageService _ImageService, IPlaceKindService _PlaceKindService)
        {
            this._PlaceService = _PlaceService;
            this._ImageService = _ImageService;
            this._PlaceKindService = _PlaceKindService;
        }

        // api/Place/GetPlacesForSearch
        public IHttpActionResult GetPlacesForSearch()
        {
            var places = _PlaceService.GetPlaces().Where(p => p.isEnable == true);
            List<PlaceViewModel> li = new List<PlaceViewModel>();
            foreach (Place p in places)
            {
                PlaceViewModel pvm = new PlaceViewModel();
                pvm.Id = p.Id;
                pvm.Name = p.Name;
                pvm.Description = p.Description;
                pvm.Longitude = p.Longitude;
                pvm.Latitude = p.Latitude;
                pvm.ZoomSize = p.ZoomSize;
                pvm.Address = p.Address;
                li.Add(pvm);
            }
            return Ok(li);
        }

        // api/Place/GetNearBy
        public IHttpActionResult GetNearBy(float objlng, float objlat, float distance, int scope)//scope: 0_Nation, 1_City, 2_Street, Kinds
        {
            var places = _PlaceService.GetPlacesNearBy(objlng, objlat, distance, scope);
            List<PlaceViewModel> li = new List<PlaceViewModel>();
            foreach (Place p in places)
            {
                PlaceViewModel pvm = new PlaceViewModel();
                pvm.Id = p.Id;
                pvm.Name = p.Name;
                pvm.Description = p.Description;
                pvm.Longitude = p.Longitude;
                pvm.Latitude = p.Latitude;
                pvm.ZoomSize = p.ZoomSize;
                pvm.Address = p.Address;
                pvm.ServeStatus = p.ServeStatus;
                pvm.PlaceKindId = p.PlaceKindId;
                pvm.DateCreate = p.DateCreate;
                pvm.RootPlaceId = p.RootPlaceId;
                pvm.RatingStar = p.RatingStar;
                pvm.NofSearch = p.NofSearch;
                pvm.Poppular = p.Poppular;
                pvm.TimeOpen = p.TimeOpen;
                pvm.TimeClose = p.TimeClose;
                pvm.LastConfirm = p.LastConfirm;
                pvm.Facebook = p.Facebook;
                pvm.Instagram = p.Instagram;
                pvm.PageUrl = p.PageUrl;
                pvm.UserId = p.UserId;
                pvm.PhoneNumber = p.PhoneNumber;
                pvm.isEnable = p.isEnable;
                li.Add(pvm);
            }
            return Ok(li);
        }

        //api/Place/GetPlacesByPopular
        public IHttpActionResult GetPlacesByPopular(string search)
        {
            List<Place> places = _PlaceService.SearchPlacesByPopular(convertToUnSign3(search));
            List<PlaceViewModel> li = new List<PlaceViewModel>();
            foreach (Place p in places)
            {
                PlaceViewModel pvm = new PlaceViewModel();
                pvm.Id = p.Id;
                pvm.Name = p.Name;
                pvm.Description = p.Description;
                pvm.Longitude = p.Longitude;
                pvm.Latitude = p.Latitude;
                pvm.ZoomSize = p.ZoomSize;
                pvm.Address = p.Address;
                pvm.ServeStatus = p.ServeStatus;
                pvm.PlaceKindId = p.PlaceKindId;
                pvm.DateCreate = p.DateCreate;
                pvm.RootPlaceId = p.RootPlaceId;
                pvm.RatingStar = p.RatingStar;
                pvm.NofSearch = p.NofSearch;
                pvm.Poppular = p.Poppular;
                pvm.TimeOpen = p.TimeOpen;
                pvm.TimeClose = p.TimeClose;
                pvm.LastConfirm = p.LastConfirm;
                pvm.Facebook = p.Facebook;
                pvm.Instagram = p.Instagram;
                pvm.PageUrl = p.PageUrl;
                pvm.UserId = p.UserId;
                pvm.PhoneNumber = p.PhoneNumber;
                pvm.isEnable = p.isEnable;
                li.Add(pvm);
            }
            return Ok(li);
        }

        //api/Place/
        public IHttpActionResult GetPlaceById(int id)
        {
            Place p = _PlaceService.GetPlace(id);
            PlaceViewModel pvm = new PlaceViewModel();
            pvm.Id = p.Id;
            pvm.Name = p.Name;
            pvm.Description = p.Description;
            pvm.Longitude = p.Longitude;
            pvm.Latitude = p.Latitude;
            pvm.ZoomSize = p.ZoomSize;
            pvm.Address = p.Address;
            pvm.ServeStatus = p.ServeStatus;
            pvm.PlaceKindId = p.PlaceKindId;
            pvm.DateCreate = p.DateCreate;
            pvm.RootPlaceId = p.RootPlaceId;
            pvm.RatingStar = p.RatingStar;
            pvm.NofSearch = p.NofSearch;
            pvm.Poppular = p.Poppular;
            pvm.TimeOpen = p.TimeOpen;
            pvm.TimeClose = p.TimeClose;
            pvm.LastConfirm = p.LastConfirm;
            pvm.Facebook = p.Facebook;
            pvm.Instagram = p.Instagram;
            pvm.PageUrl = p.PageUrl;
            pvm.UserId = p.UserId;
            pvm.PhoneNumber = p.PhoneNumber;
            pvm.isEnable = p.isEnable;
            return Ok(pvm);
        }

        // api/Place/Get
        public IHttpActionResult Get()
        {
            var places = _PlaceService.GetPlaces();
            List<PlaceViewModel> li = new List<PlaceViewModel>();
            foreach(Place p in places)
            {
                PlaceViewModel pvm = new PlaceViewModel();
                pvm.Id = p.Id;
                pvm.Name = p.Name;
                pvm.Description = p.Description;
                pvm.Longitude = p.Longitude;
                pvm.Latitude = p.Latitude;
                pvm.ZoomSize = p.ZoomSize;
                pvm.Address = p.Address;
                pvm.ServeStatus = p.ServeStatus;
                pvm.PlaceKindId = p.PlaceKindId;
                pvm.DateCreate = p.DateCreate;
                pvm.RootPlaceId = p.RootPlaceId;
                pvm.RatingStar = p.RatingStar;
                pvm.NofSearch = p.NofSearch;
                pvm.Poppular = p.Poppular;
                pvm.TimeOpen = p.TimeOpen;
                pvm.TimeClose = p.TimeClose;
                pvm.LastConfirm = p.LastConfirm;
                pvm.Facebook = p.Facebook;
                pvm.Instagram = p.Instagram;
                pvm.PageUrl = p.PageUrl;
                pvm.UserId = p.UserId;
                pvm.PhoneNumber = p.PhoneNumber;
                pvm.isEnable = p.isEnable;
                //var tmpImgs = _ImageService.GetImagesByOwnAndImageKind(p.Id, 3);
                //List<ImageViewModel> ivms = new List<ImageViewModel>();
                //foreach(Image img in tmpImgs)
                //{
                //    ImageViewModel ivm = new ImageViewModel();
                //    ivm.Id = img.Id;
                //    ivm.Url = img.Url;
                //    ivm.Description = img.Description;
                //    ivm.OwnId = img.OwnId;
                //    ivm.DateCreate = img.DateCreate;

                //    ivms.Add(ivm);
                //}
                //pvm.Imgs = ivms;
                li.Add(pvm);
            }
            return Ok(li);
        }

        // api/Place/Places
        [HttpGet]
        public IHttpActionResult Places()
        {
            var places = _PlaceService.GetPlaces();
            List<PlaceViewModel> li = new List<PlaceViewModel>();
            foreach (Place p in places)
            {
                PlaceViewModel pvm = new PlaceViewModel();
                pvm.Id = p.Id;
                pvm.Name = p.Name;
                pvm.Description = p.Description;
                pvm.Longitude = p.Longitude;
                pvm.Latitude = p.Latitude;
                pvm.ZoomSize = p.ZoomSize;
                pvm.Address = p.Address;
                pvm.ServeStatus = p.ServeStatus;
                pvm.PlaceKindId = p.PlaceKindId;
                pvm.DateCreate = p.DateCreate;
                pvm.RootPlaceId = p.RootPlaceId;
                pvm.RatingStar = p.RatingStar;
                pvm.NofSearch = p.NofSearch;
                pvm.Poppular = p.Poppular;
                pvm.TimeOpen = p.TimeOpen;
                pvm.TimeClose = p.TimeClose;
                pvm.LastConfirm = p.LastConfirm;
                pvm.Facebook = p.Facebook;
                pvm.Instagram = p.Instagram;
                pvm.PageUrl = p.PageUrl;
                pvm.UserId = p.UserId;
                pvm.PhoneNumber = p.PhoneNumber;
                pvm.isEnable = p.isEnable;
                //var tmpImgs = _ImageService.GetImagesByOwnAndImageKind(p.Id, 3);
                //List<ImageViewModel> ivms = new List<ImageViewModel>();
                //foreach(Image img in tmpImgs)
                //{
                //    ImageViewModel ivm = new ImageViewModel();
                //    ivm.Id = img.Id;
                //    ivm.Url = img.Url;
                //    ivm.Description = img.Description;
                //    ivm.OwnId = img.OwnId;
                //    ivm.DateCreate = img.DateCreate;

                //    ivms.Add(ivm);
                //}
                //pvm.Imgs = ivms;
                li.Add(pvm);
            }
            return Ok(li);
        }

        // api/Place/Update
        public IHttpActionResult Update(PlaceViewModel p)
        {
            var Place = _PlaceService.GetPlace(p.Id);
            if(Place != null)
            {
                Place.Address = p.Address;
                Place.Description = p.Description;
                Place.Facebook = p.Facebook;
                Place.Instagram = p.Instagram;
                Place.Longitude = p.Longitude;
                Place.Latitude = p.Latitude;
                Place.Name = p.Name;
                Place.NofSearch = p.NofSearch;
                Place.PageUrl = p.PageUrl;
                Place.PhoneNumber = p.PhoneNumber;
                Place.PlaceKindId = p.PlaceKindId;
                Place.Poppular = p.Poppular;
                Place.RootPlaceId = p.RootPlaceId;
                Place.RatingStar = p.RatingStar;
                Place.ServeStatus = p.ServeStatus;
                Place.TimeOpen = p.TimeOpen;
                Place.TimeClose = p.TimeClose;
                Place.LastConfirm = DateTime.Now;
                Place.isEnable = p.isEnable;
                _PlaceService.EditPlace(Place);
            }
            return Ok();
        }

        //Destroy Place By Id
        public IHttpActionResult Destroy(int id)
        {
            var p = _PlaceService.GetPlace(id);
            if(p != null)
            {
                p.isEnable = false;
                _PlaceService.EditPlace(p);
            }
            return Ok();
        }

        //Destroy Place by ViewModel
        public IHttpActionResult Destroy(PlaceViewModel p)
        {
            var place = _PlaceService.GetPlace(p.Id);
            place.isEnable = false;
            _PlaceService.EditPlace(place);
            return Ok();
        }

        //Create Place
        [HttpPost]
        public IHttpActionResult Create(PlaceViewModel place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Place p = new Place();
            p.Address = place.Address;
            p.Description = place.Description;
            p.Facebook = place.Facebook;
            p.Instagram = place.Instagram;
            p.Longitude = place.Longitude;
            p.Latitude = place.Latitude;
            p.Name = place.Name;
            p.NofSearch = place.NofSearch;
            p.PageUrl = place.PageUrl;
            p.PhoneNumber = place.PhoneNumber;
            p.PlaceKindId = place.PlaceKindId;
            p.Poppular = place.Poppular;
            p.RootPlaceId = place.RootPlaceId;
            p.RatingStar = place.RatingStar;
            p.ServeStatus = place.ServeStatus;
            p.TimeOpen = place.TimeOpen;
            p.TimeClose = place.TimeClose;
            p.UserId = place.UserId;
            p.ZoomSize = place.ZoomSize;
            p.DateCreate =  DateTime.Now;
            p.LastConfirm = DateTime.Now;
            p.isEnable = place.isEnable;
            _PlaceService.CreatePlace(p);
            return Ok();
        }

        //Create Place by normal pay user
        [HttpPost]
        public IHttpActionResult CreatePlaceByNormalUser(PlaceViewModel place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Place p = new Place();
            p.Address = place.Address;
            p.Description = place.Description;
            p.Facebook = place.Facebook;
            p.Instagram = place.Instagram;
            p.Longitude = place.Longitude;
            p.Latitude = place.Latitude;
            p.Name = place.Name;
            p.NofSearch = place.NofSearch;
            p.PageUrl = place.PageUrl;
            p.PhoneNumber = place.PhoneNumber;
            p.PlaceKindId = place.PlaceKindId;
            p.Poppular = place.Poppular;
            p.RootPlaceId = place.RootPlaceId;
            p.RatingStar = place.RatingStar;
            p.ServeStatus = place.ServeStatus;
            p.TimeOpen = place.TimeOpen;
            p.TimeClose = place.TimeClose;
            p.UserId = place.UserId;
            p.ZoomSize = place.ZoomSize;
            p.DateCreate = DateTime.Now;
            p.LastConfirm = DateTime.Now;
            p.ZoomSize = "16";
            p.NofSearch = 0;
            p.Promote = 0;

            PlaceKind pk = _PlaceKindService.GetPlaceKind(place.PlaceKindId);
            p.Poppular = (100 - pk.Priority) * 100 + (place.RatingStar * 10) + p.Promote;
            
            p.Definition = convertToUnSign3(place.Name + " " + place.Address);

            p.isEnable = false;
            _PlaceService.CreatePlace(p);
            return Ok();
        }

        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
