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
    public class ImageController : ApiController
    {
        private readonly IImageService _ImageService;
        private readonly ImageKindController ImageKindController;

        //Constructor
        public ImageController(IImageService _ImageService, ImageKindController ImageKindController)
        {
            this._ImageService = _ImageService;
            this.ImageKindController = ImageKindController;
        }

        //Get all Image
        public IHttpActionResult Get()
        {
            var images = _ImageService.GetImages();
            List<ImageViewModel> ivms = new List<ImageViewModel>();
            foreach (var img in images)
            {
                ImageViewModel ivm = new ImageViewModel();
                ivm.Id = img.Id;
                ivm.Url = img.Url;
                ivm.Description = img.Description;
                ivm.ImageKindId = img.ImageKindId;
                ivm.OwnId = img.OwnId;
                ivm.DateCreate = img.DateCreate;
                ivms.Add(ivm);
            }
            return Ok(ivms);
        }

        //Get Images
        public IHttpActionResult GetImage(string ObjectKind, int ownId)
        {
            int kindId = ImageKindController.GetImageKindIdByKind(ObjectKind);
            if(kindId >= 0)
            {
                List<Image> images = _ImageService.GetImages().Where(img => ((img.ImageKindId == kindId) && (img.OwnId == ownId))).ToList();
                List<ImageViewModel> ivms = new List<ImageViewModel>();
                foreach (var img in images)
                {
                    ImageViewModel ivm = new ImageViewModel();
                    ivm.Id = img.Id;
                    ivm.Url = img.Url;
                    ivm.Description = img.Description;
                    ivm.ImageKindId = img.ImageKindId;
                    ivm.OwnId = img.OwnId;
                    ivm.DateCreate = img.DateCreate;
                    ivms.Add(ivm);
                }
                return Ok(ivms);
            }
            
            return null;
        }

        //Update Image
        public IHttpActionResult Update(ImageViewModel imageViewModel)
        {
            var Image = _ImageService.GetImage(imageViewModel.Id);
            Image.Url = imageViewModel.Url;
            Image.Description = imageViewModel.Description;
            Image.ImageKindId = imageViewModel.ImageKindId;
            _ImageService.EditImage(Image);
            return Ok();
        }

        //Destroy Image By Id
        public IHttpActionResult Destroy(int id)
        {
            _ImageService.RemoveImage(id);
            return Ok();
        }

        //Destroy Image by ViewModel
        public IHttpActionResult Destroy(ImageViewModel imageViewModel)
        {
            _ImageService.RemoveImage(imageViewModel.Id);
            return Ok();
        }

        //Create all Image
        [HttpPost]
        public IHttpActionResult Create(ImageViewModel image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Image img = new Image();
            img.Url = image.Url;
            img.Description = image.Description;
            img.ImageKindId = image.ImageKindId;
            img.OwnId = image.OwnId;
            img.DateCreate = image.DateCreate;
            _ImageService.CreateImage(img);
            return Ok();
        }
    }
}