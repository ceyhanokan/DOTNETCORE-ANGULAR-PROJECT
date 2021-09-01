using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFW;
using Entities.TABLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyControl.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserBusService>();
            builder.RegisterType<EF_UserDAL>().As<IUserDAL>();

            builder.RegisterType<AuthorizationManager>().As<IAuthorizationBusService>();
            builder.RegisterType<EF_AuthorizationDAL>().As<IAuthorizationDAL>();

            builder.RegisterType<CityManager>().As<ICityBusService>();
            builder.RegisterType<EF_CityDAL>().As<ICityDAL>();

            builder.RegisterType<DistrictManager>().As<IDistrictBusService>();
            builder.RegisterType<EF_DistrictDAL>().As<IDistrictDAL>();


            builder.RegisterType<NeighbourhoodManager>().As<INeighbourhoodBusService>();
            builder.RegisterType<EF_NeighbourhoodDAL>().As<INeighbourhoodDAL>();

            builder.RegisterType<ImmovableManager>().As<IimmovableBusService>();
            builder.RegisterType<EF_ImmovableDAL>().As<IimmovableDAL>();

            builder.RegisterType<RoleManager>().As<IRoleBusService>();
            builder.RegisterType<EF_RoleDAL>().As<IRoleDAL>();

            builder.RegisterType<TypeTBLManager>().As<ITypeTBLBusService>();
            builder.RegisterType<EF_TypeDAL>().As<ITypeTBLDAL>();

            //base.Load(builder);
        }
    }
}
