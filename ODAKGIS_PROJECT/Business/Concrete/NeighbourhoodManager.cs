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
    public class NeighbourhoodManager : IBaseBusinessService<Neighbourhood>, INeighbourhoodBusService
    {
        private INeighbourhoodDAL _NeighbourhoodDal;
        public NeighbourhoodManager(INeighbourhoodDAL NeighbourhoodDal)
        {
            _NeighbourhoodDal = NeighbourhoodDal;
        }
        public InsertResult<Neighbourhood> Add(Neighbourhood Neighbourhood)
        {
         return _NeighbourhoodDal.Add(Neighbourhood);
        }

        public DeleteResult<Neighbourhood> Delete(Neighbourhood Neighbourhood)
        {
            return _NeighbourhoodDal.Detele(Neighbourhood);
        }

        public SelectResult<Neighbourhood> GetByID(int NeighbourhoodID)
        {
            return _NeighbourhoodDal.GetSingle(p=> p.NeighbourhoodID == NeighbourhoodID);
        }

        public SelectResult<Neighbourhood> GetList()
        {
            var result = _NeighbourhoodDal.GetList();
            return result;
        }

        public SelectResult<Neighbourhood> GetSingle(Neighbourhood Neighbourhood)
        {
            var result = _NeighbourhoodDal.GetSingle(p=> p.NeighbourhoodID == Neighbourhood.NeighbourhoodID);
            return result;
        }

        public UpdateResult<Neighbourhood> Update(Neighbourhood Neighbourhood)
        {
            var result = _NeighbourhoodDal.Update(Neighbourhood);
            return result;
        }
    }
}
