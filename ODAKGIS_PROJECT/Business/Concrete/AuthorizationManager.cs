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
    public class AuthorizationManager : IBaseBusinessService<Authorization>, IAuthorizationBusService
    {
        private IAuthorizationDAL _AuthorizationDal;
        public AuthorizationManager(IAuthorizationDAL AuthorizationDal)
        {
            _AuthorizationDal = AuthorizationDal;
        }
        public InsertResult<Authorization> Add(Authorization Authorization)
        {
         return _AuthorizationDal.Add(Authorization);
        }

        public DeleteResult<Authorization> Delete(Authorization Authorization)
        {
            return _AuthorizationDal.Detele(Authorization);
        }

        public SelectResult<Authorization> GetByID(int AuthorizationID)
        {
            return _AuthorizationDal.GetSingle(p=> p.AuthID == AuthorizationID);
        }

        public SelectResult<Authorization> GetList()
        {
            var result = _AuthorizationDal.GetList();
            return result;
        }

        public SelectResult<Authorization> GetSingle(Authorization Authorization)
        {
            var result = _AuthorizationDal.GetSingle(p=> p.AuthID == Authorization.AuthID);
            return result;
        }

        public UpdateResult<Authorization> Update(Authorization Authorization)
        {
            var result = _AuthorizationDal.Update(Authorization);
            return result;
        }
    }
}
