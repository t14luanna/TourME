using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Data.Repositories;
using TourMe.Model.Model;

namespace TourMe.Service
{
    public interface IImageKindService
    {
        IEnumerable<ImageKind> GetImageKinds(string name = null);
        ImageKind GetImageKind(int id);
        ImageKind GetImageKind(string name);
        void CreateImageKind(ImageKind ImageKind);
        void EditImageKind(ImageKind ImageKind);
        void RemoveImageKind(int id);
        void SaveImageKind();
    }

    public class ImageKindService : IImageKindService
    {
        private readonly IImageKindRepository ImageKindRepository;
        private readonly IUnitOfWork unitOfWork;

        //Constructor
        public ImageKindService(IImageKindRepository ImageKindRepository, IUnitOfWork unitOfWork)
        {
            this.ImageKindRepository = ImageKindRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateImageKind(ImageKind ImageKind)
        {
            ImageKindRepository.Add(ImageKind);
            SaveImageKind();
        }

        public void EditImageKind(ImageKind ImageKind)
        {
            ImageKind ik = ImageKindRepository.GetById(ImageKind.Id);
            if(ik != null)
            {
                ik.Kind = ImageKind.Kind;
                ik.Description = ImageKind.Description;
                SaveImageKind();
            }
        }

        public ImageKind GetImageKind(int id)
        {
            ImageKind ik = ImageKindRepository.GetById(id);
            if (ik != null)
            {
                return ik;
            }
            return null;
        }

        public ImageKind GetImageKind(string kind)
        {
            ImageKind ik = ImageKindRepository.GetImageKindByKind(kind);
            if(ik != null)
            {
                return ik;
            }
            return null;
        }

        public IEnumerable<ImageKind> GetImageKinds(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return ImageKindRepository.GetAll();
            else
                return ImageKindRepository.GetAll().Where(c => c.Description.Equals(name));
        }

        public void RemoveImageKind(int id)
        {
            ImageKind ik = ImageKindRepository.GetById(id);
            ImageKindRepository.Delete(ik);
            SaveImageKind();
        }

        public void SaveImageKind()
        {
            unitOfWork.Commit();
        }

    }
}
