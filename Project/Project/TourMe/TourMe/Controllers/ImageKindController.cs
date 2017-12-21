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
    public class ImageKindController : ApiController
    {
        private readonly IImageKindService _ImageKindService;

        //Constructor
        public ImageKindController(IImageKindService _ImageKindService)
        {
            this._ImageKindService = _ImageKindService;
        }

        //Get all ImageKind
        public IHttpActionResult Get()
        {
            var ImageKinds = _ImageKindService.GetImageKinds();
            List<ImageKindViewModel> ikvms = new List<ImageKindViewModel>();
            foreach(var ImageKind in ImageKinds)
            {
                ImageKindViewModel ikvm = new ImageKindViewModel();
                ikvm.Id = ImageKind.Id;
                ikvm.Kind = ImageKind.Kind;
                ikvm.Description = ImageKind.Description;
                ikvm.DateCreate = ImageKind.DateCreate;
                ikvms.Add(ikvm);
            }
            return Ok(ikvms);
        }


        //Get ImageKind by Kind
        public int GetImageKindIdByKind(string kind)
        {
            var ImageKind = _ImageKindService.GetImageKind(kind);
            if(ImageKind != null)
            {
                return ImageKind.Id;
            }
            return -1;
        }

        //Update ImageKind
        public IHttpActionResult Update(ImageKindViewModel imageKindViewModel)
        {
            var ImageKind = _ImageKindService.GetImageKind(imageKindViewModel.Id);
            ImageKind.Description = imageKindViewModel.Description;
            ImageKind.Kind = imageKindViewModel.Kind;
            _ImageKindService.EditImageKind(ImageKind);
            return Ok();
        }

        //Destroy ImageKind By Id
        public IHttpActionResult Destroy(int id)
        {
            _ImageKindService.RemoveImageKind(id);
            return Ok();
        }

        //Destroy ImageKind by ViewModel
        public IHttpActionResult Destroy(ImageKindViewModel imageKindViewModel)
        {
            _ImageKindService.RemoveImageKind(imageKindViewModel.Id);
            return Ok();
        }

        //Create all ImageKind
        [HttpPost]
        public IHttpActionResult Create(ImageKindViewModel imageKind)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ImageKind ik = new ImageKind();
            ik.Description = imageKind.Description;
            ik.Kind = imageKind.Kind;
            _ImageKindService.CreateImageKind(ik);
            return Ok();
        }
    }
}
