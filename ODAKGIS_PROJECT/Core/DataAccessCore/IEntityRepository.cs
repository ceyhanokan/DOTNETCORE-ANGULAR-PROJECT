using Core.Entities;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessCore
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        SelectResult<T> GetSingle(Expression<Func<T,bool>> filter);
        Task<SelectResult<T>> GetSingleAsync(Expression<Func<T,bool>> filter);
        SelectResult<T> GetList(Expression<Func<T,bool>> filter = null, int skip=0, int take=100);
        Task<SelectResult<T>> GetListAsync(int skip, int take, Expression<Func<T, bool>> filter = null);
        InsertResult<T> Add(T Entity);
        InsertResult<T> AddMultiple(IList<T> Entity);
        UpdateResult<T> Update(T Entity);
        DeleteResult<T> Detele(T Entity);
    }
}
