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
    public class DistrictManager : IBaseBusinessService<District>, IDistrictBusService
    {
        private IDistrictDAL _DistrictDal;
        public DistrictManager(IDistrictDAL DistrictDal)
        {
            _DistrictDal = DistrictDal;
        }
        public InsertResult<District> Add(District District)
        {
         return _DistrictDal.Add(District);
        }

        public DeleteResult<District> Delete(District District)
        {
            return _DistrictDal.Detele(District);
        }

        public SelectResult<District> GetByID(int DistrictID)
        {
            return _DistrictDal.GetSingle(p=> p.DistrictID == DistrictID);
        }

        public SelectResult<District> GetList()
        {
            var result = _DistrictDal.GetList();
            return result;
        }

        public SelectResult<District> GetSingle(District District)
        {
            var result = _DistrictDal.GetSingle(p=> p.DistrictID == District.DistrictID);
            return result;
        }

        public UpdateResult<District> Update(District District)
        {
            var result = _DistrictDal.Update(District);
            return result;
        }
    }
}
