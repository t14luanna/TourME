using TourMe.Data.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Image GetImageByUrl(string imageUrl)
        {
            Image Image = this.DbContext.Images.Where(p => p.Url == imageUrl).FirstOrDefault();
            return Image;
        }
    }

    public interface IImageRepository : IRepository<Image>
    {
        Image GetImageByUrl(string imageUrl);
    }
}
