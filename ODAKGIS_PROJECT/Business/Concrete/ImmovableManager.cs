using Business.Abstract;
using Core.Handler;
using Core.Model;
using DataAccess.Abstract;
using Entities.TABLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImmovableManager : IBaseBusinessService<Immovable>, IimmovableBusService
    {
        private IimmovableDAL _ImmovableDal;
        public ImmovableManager(IimmovableDAL ImmovableDal)
        {
            _ImmovableDal = ImmovableDal;
        }
        public InsertResult<Immovable> Add(Immovable immovable)
        {
            return _ImmovableDal.Add(immovable);
        }


        public DeleteResult<Immovable> Delete(Immovable Immovable)
        {
            var result = _ImmovableDal.Detele(Immovable);
            result.IsSuccess = true;
            result.Message = "Silme işlemi başarılı";
            return result;
        }

        public SelectResult<Immovable> GetByID(int ImmovableID)
        {
            var result = _ImmovableDal.GetSingle(p => p.ImmovableID == ImmovableID);
            result.IsSuccess = true;
            result.Message = result.RecordSingle != null
                    ? "Sorgu Başarılı. Kayıt bulundu"
                    : "Sorgu başarılı. Kayıt Bulunamadı";
            return result;
        }

        public SelectResult<Immovable> GetList()
        {
            var result = _ImmovableDal.GetList();
            result.IsSuccess = true;
            result.Message = "Başarılı";
            return result;
        }
        public SelectResult<Immovable> GetListByFilter<T>(Immovable param=null)
        {
            var paramx = new User()
            {
                IsAdmin = 1,
                Status = 1
            };
        
            
            
            if (param != null)
            {

            }
            

            var result = _ImmovableDal.GetList();
            result.IsSuccess = true;
            result.Message = "Başarılı";
            return result;
        }
        public SelectResult<Immovable> GetSingle(Immovable Immovable)
        {
            var result = _ImmovableDal.GetSingle(p => p.ImmovableID == Immovable.ImmovableID);
            result.IsSuccess = true;
            return result;
        }

        public UpdateResult<Immovable> Update(Immovable Immovable)
        {
            var result = _ImmovableDal.Update(Immovable);
            result.IsSuccess = true;
            return result;
        }
    }
}
