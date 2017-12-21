using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Data.Infrastucture;
using TourMe.Model.Model;

namespace TourMe.Data.Repositories
{
    public class ImageKindRepository : RepositoryBase<ImageKind>, IImageKindRepository
    {
        public ImageKindRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public ImageKind GetImageKindByKind(string KindName)
        {
            ImageKind ImageKind = this.DbContext.ImageKinds.Where(p => p.Kind == KindName).FirstOrDefault();
            return ImageKind;
        }
    }

    public interface IImageKindRepository : IRepository<ImageKind>
    {
        ImageKind GetImageKindByKind(string Kind);
    }
}
