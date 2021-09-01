using Business.Abstract;
using Core.Model;
using DataAccess.Abstract;
using Entities.TABLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TypeTBLManager : IBaseBusinessService<TypeTBL>, ITypeTBLBusService
    {
        private ITypeTBLDAL _TypeTBLDal;
        public TypeTBLManager(ITypeTBLDAL TypeTBLDal)
        {
            _TypeTBLDal = TypeTBLDal;
        }
        public InsertResult<TypeTBL> Add(TypeTBL TypeTBL)
        {
         return _TypeTBLDal.Add(TypeTBL);
        }

        public DeleteResult<TypeTBL> Delete(TypeTBL TypeTBL)
        {
            return _TypeTBLDal.Detele(TypeTBL);
        }

        public SelectResult<TypeTBL> GetByID(int TypeID)
        {
            return _TypeTBLDal.GetSingle(p=> p.TypeID == TypeID);
        }

        public SelectResult<TypeTBL> GetList()
        {
            var result = _TypeTBLDal.GetList();
            return result;
        }

        public SelectResult<TypeTBL> GetSingle(TypeTBL TypeTBL)
        {
            var result = _TypeTBLDal.GetSingle(p=> p.TypeID == TypeTBL.TypeID);
            return result;
        }

        public UpdateResult<TypeTBL> Update(TypeTBL TypeTBL)
        {
            var result = _TypeTBLDal.Update(TypeTBL);
            return result;
        }
    }
}
