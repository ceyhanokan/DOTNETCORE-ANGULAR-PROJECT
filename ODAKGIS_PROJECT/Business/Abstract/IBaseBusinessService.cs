using Core.Model;
using Entities.TABLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseBusinessService<T>
    {
        SelectResult<T> GetList();
        SelectResult<T> GetSingle(T user);
        SelectResult<T> GetByID(int userID);
        InsertResult<T> Add(T user);
        UpdateResult<T> Update(T user);
        DeleteResult<T> Delete(T user);
    }
}
