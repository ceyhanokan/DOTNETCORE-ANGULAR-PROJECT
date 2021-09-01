using Core.DataAccessCore.EntityFWC;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFW.Context;
using Entities.TABLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFW
{
    public class EF_RoleDAL: EFC_RepositoryBase<Role, EF_DBContext>,IRoleDAL
    {
    }
}
