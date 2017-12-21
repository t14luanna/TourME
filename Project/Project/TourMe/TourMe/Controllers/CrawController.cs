using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TourMe.ViewModel;
using Newtonsoft;
using TourMe.Service;
using TourMe.Model.Model;
using System.Text.RegularExpressions;
using System.Text;

namespace TourMe.Controllers
{
    public class CrawController : ApiController
    {
        private readonly IPlaceService _PlaceService;
        private readonly IPlaceKindService _PlaceKindService;
        private readonly IImageService _ImageService;
        private readonly IImageKindService _ImageKindService;


        private PlaceKind placeKind;
        private Place place;
        private Image image;//kind:2 potrait
        

        //Constructor
        public CrawController(IPlaceService _PlaceService, IImageService _ImageService, IPlaceKindService _PlaceKindService, IImageKindService _ImageKindService)
        {
            this._PlaceService = _PlaceService;
            this._PlaceKindService = _PlaceKindService;
            this._ImageService = _ImageService;
            this._ImageKindService = _ImageKindService;
        }

        public IHttpActionResult Insert([FromBody]CrawPlaceViewModel[] cvmds)
        {
            try
            {
                foreach (CrawPlaceViewModel cvmd in cvmds)
                {
                    var pAddress = _PlaceService.GetPlaceByAddress(cvmd.address);
                    var upAddress = _PlaceService.GetPlaceByAddress(convertToUnSign3(cvmd.address));//unsigned UTF-8
                    var pName = _PlaceService.GetPlace(cvmd.title);
                    var upName = _PlaceService.GetPlace(convertToUnSign3(cvmd.title));//unsigned UTF8

                    //if not exist add place with (sign/usigned) name/address tag  OR new address
                    if ((pName == null && upName == null && upAddress == null && pAddress == null) || (pAddress == null && upAddress == null))
                    {
                        PlaceKind pk = _PlaceKindService.GetPlaceKind(cvmd.category);
                        if (pk == null)
                        {
                            placeKind = new PlaceKind();
                            placeKind.DateCreate = DateTime.Today;
                            string pkind = "";
                            switch (cvmd.category)
                            {
                                case "Nhà hàng": pkind = "Restaurant"; break;
                                case "Café": pkind = "Cafe"; break;
                                case "Khách sạn và chỗ ở": pkind = "Hotel"; break;
                                case "Mua sắm": pkind = "Market"; break;
                                case "Giáo dục": pkind = "Education"; break;
                                case "Du lịch": pkind = "Point_of_interested"; break;
                                case "Sức khỏe": pkind = "Health"; break;
                                case "Làm đẹp": pkind = "Spa"; break;
                                case "Giải trí": pkind = "Entertaiment"; break;
                                case "Cây xăng": pkind = "Gas"; break;
                                case "Các cây ATM": pkind = "ATM"; break;
                                case "Cuộc sống về đêm": pkind = "NightLife"; break;
                                case "Dịch vụ": pkind = "Service"; break;
                            }
                            placeKind.Kind = pkind;
                            placeKind.Description = cvmd.category;
                            _PlaceKindService.CreatePlaceKind(placeKind);
                        }
                        place = new Place();
                        place.Address = cvmd.address;
                        place.Description = cvmd.description;
                        place.Facebook = cvmd.facebook;
                        place.DateCreate = DateTime.Today;
                        place.LastConfirm = DateTime.Today;
                        place.isEnable = true;
                        place.Latitude = cvmd.gps.latitude;
                        place.Longitude = cvmd.gps.longitude;
                        place.Name = cvmd.title;
                        place.PageUrl = cvmd.url;
                        place.PhoneNumber = cvmd.phone;
                        place.RatingStar = cvmd.rating;
                        place.ServeStatus = 1;//active
                        place.UserId = 0;//admin
                        place.RootPlaceId = 0;//VietNam
                        place.TimeOpen = 0000;
                        place.PlaceKindId = _PlaceKindService.GetPlaceKind(cvmd.category).Id;
                        place.PlaceKind = pk;
                        place.TimeClose = 0000;
                        place.ZoomSize = "16";
                        place.NofSearch = 0;
                        place.Promote = 0;

                        place.Poppular = (100 - pk.Priority) * 100 + (place.RatingStar * 10) + place.Promote;

                        place.Definition = convertToUnSign3(cvmd.title + " " + cvmd.address);
                        _PlaceService.CreatePlace(place);


                        Image img = _ImageService.GetImage(cvmd.img_big);
                        if (img == null)
                        {
                            image = new Image();
                            image.ImageKindId = _ImageKindService.GetImageKind("Place").Id;
                            image.DateCreate = DateTime.Today;
                            image.ImageKind = _ImageKindService.GetImageKind(2);
                            image.OwnId = _PlaceService.GetPlace(cvmd.title).Id;
                            image.Description = cvmd.title + " : " + cvmd.address;
                            image.Url = cvmd.img_big;
                            _ImageService.CreateImage(image);
                        }                       
                        //break;//test: add only one none exist place in db
                    }
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message + " : " + e.InnerException + " : " + e.StackTrace + " : " + e.Data);
            }
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
