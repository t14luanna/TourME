using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourMe.Model.Model;

namespace TourMe.Data.Infrastucture
{
    public class DbFactory : Disposable, IDbFactory
    {
        TMEntities dbContext;

        public TMEntities Init()
        {
            return dbContext ?? (dbContext = new TMEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }

    public interface IDbFactory : IDisposable
    {
        TMEntities Init();
    }
}
