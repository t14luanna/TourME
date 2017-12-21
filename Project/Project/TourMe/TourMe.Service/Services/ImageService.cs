using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Model.Model;
using TourMe.Data;
using TourMe.Data.Repositories;
using TourMe.Data.Infrastucture;

namespace TourMe.Service
{
    public interface IImageService
    {
        IEnumerable<Image> GetImages(string name = null);
        IEnumerable<Image> GetImagesByOwnAndImageKind(int ownId, int ImageKindId);
        Image GetImage(int id);
        Image GetImage(string url);
        void CreateImage(Image Image);
        void EditImage(Image Image);
        void RemoveImage(int id);
        void SaveImage();
        void UnRemoveImage(int id);
    }

    public class ImageService : IImageService
    {
        private readonly IImageRepository ImageRepository;
        private readonly IUnitOfWork unitOfWork;

        //Constructor
        public ImageService(IImageRepository ImageRepository, IUnitOfWork unitOfWork)
        {
            this.ImageRepository = ImageRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateImage(Image Image)
        {
            ImageRepository.Add(Image);
            SaveImage();
        }

        public void EditImage(Image Image)
        {
            Image img = ImageRepository.GetById(Image.Id);
            if (img != null)
            {
                img.Url = Image.Url;
                img.Description = Image.Description;
                img.ImageKindId = Image.ImageKindId;
                img.OwnId = Image.OwnId;
                SaveImage();
            }
        }

        public Image GetImage(int id)
        {
            Image img = ImageRepository.GetById(id);
            if (img != null)
            {
                return img;
            }
            return null;
        }

        public Image GetImage(string url)
        {
            Image img = ImageRepository.GetImageByUrl(url);
            return img;
        }

        public IEnumerable<Image> GetImages(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return ImageRepository.GetAll();
            else
                return ImageRepository.GetAll().Where(c => c.Description.Equals(name));
        }

        public IEnumerable<Image> GetImagesByOwnAndImageKind(int ownId, int imageKindId)
        {
            var imgs = ImageRepository.GetAll();
            List<Image> res = new List<Image>();
            foreach(Image img in imgs)
            {
                if(img.OwnId == ownId && img.ImageKindId == imageKindId)
                {
                    res.Add(img);
                }
            }
            if(res.Count == 0)
            {
                res.Add(ImageRepository.GetById(0));
            }
            return res;
        }

        public void RemoveImage(int id)
        {
            Image img = ImageRepository.GetById(id);
            ImageRepository.Delete(img);
            SaveImage();
        }

        public void SaveImage()
        {
            unitOfWork.Commit();
        }

        public void UnRemoveImage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
