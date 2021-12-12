using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarsLinqAdoNet.DataAccesss.Abstract
{
    public interface IGenericRepositoryPattern<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Query(Expression<Func<T, bool>> exp);


        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SubmitChanges();
    }
}
