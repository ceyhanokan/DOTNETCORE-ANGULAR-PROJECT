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
    public class LogManager : IBaseBusinessService<Log>, ILogBusService
    {
        private ILogDAL _LogDal;
        public LogManager(ILogDAL LogDal)
        {
            _LogDal = LogDal;
        }
        public InsertResult<Log> Add(Log Log)
        {
         return _LogDal.Add(Log);
        }

        public DeleteResult<Log> Delete(Log Log)
        {
            return _LogDal.Detele(Log);
        }

        public SelectResult<Log> GetByID(int LogID)
        {
            return _LogDal.GetSingle(p=> p.LogID == LogID);
        }

        public SelectResult<Log> GetList()
        {
            var result = _LogDal.GetList();
            return result;
        }

        public SelectResult<Log> GetSingle(Log Log)
        {
            var result = _LogDal.GetSingle(p=> p.LogID == Log.LogID);
            return result;
        }

        public UpdateResult<Log> Update(Log Log)
        {
            var result = _LogDal.Update(Log);
            return result;
        }
    }
}
