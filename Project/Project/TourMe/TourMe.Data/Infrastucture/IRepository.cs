using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TourMe.Data.Infrastucture
{
    public interface IRepository<T> where T : class
    {
        //Add new entity
        void Add(T entity);
        //Modified entity
        void Update(T entity);
        //Remove entity
        void Delete(T entity);
        //Remove entity by Expression (id, name)
        void Delete(Expression<Func<T, bool>> where);
        //Get an entity by int id
        T GetById(int id);
        //Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);
        //Gets all entities of type T
        IEnumerable<T> GetAll();
        //Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
