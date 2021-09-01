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
    public class CityManager : IBaseBusinessService<City>, ICityBusService
    {
        private ICityDAL _CityDal;
        public CityManager(ICityDAL CityDal)
        {
            _CityDal = CityDal;
        }
        public InsertResult<City> Add(City City)
        {
         return _CityDal.Add(City);
        }

        public DeleteResult<City> Delete(City City)
        {
            return _CityDal.Detele(City);
        }

        public SelectResult<City> GetByID(int CityID)
        {
            return _CityDal.GetSingle(p=> p.CityID == CityID);
        }

        public SelectResult<City> GetList()
        {
            var result = _CityDal.GetList();
            return result;
        }

        public SelectResult<City> GetSingle(City City)
        {
            var result = _CityDal.GetSingle(p=> p.CityID == City.CityID);
            return result;
        }

        public UpdateResult<City> Update(City City)
        {
            var result = _CityDal.Update(City);
            return result;
        }
    }
}
