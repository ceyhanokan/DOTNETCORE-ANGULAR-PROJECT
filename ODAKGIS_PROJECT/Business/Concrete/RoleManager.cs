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
    public class RoleManager : IBaseBusinessService<Role>, IRoleBusService
    {
        private IRoleDAL _RoleDal;
        public RoleManager(IRoleDAL RoleDal)
        {
            _RoleDal = RoleDal;
        }
        public InsertResult<Role> Add(Role Role)
        {
         return _RoleDal.Add(Role);
        }

        public DeleteResult<Role> Delete(Role Role)
        {
            return _RoleDal.Detele(Role);
        }

        public SelectResult<Role> GetByID(int RoleID)
        {
            return _RoleDal.GetSingle(p=> p.RoleID == RoleID);
        }

        public SelectResult<Role> GetList()
        {
            var result = _RoleDal.GetList();
            return result;
        }

        public SelectResult<Role> GetSingle(Role Role)
        {
            var result = _RoleDal.GetSingle(p=> p.RoleID == Role.RoleID);
            return result;
        }

        public UpdateResult<Role> Update(Role Role)
        {
            var result = _RoleDal.Update(Role);
            return result;
        }
    }
}
