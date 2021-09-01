using Core.Model;
using Entities.TABLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserBusService:IBaseBusinessService<User>
    {
        //Ana Interface olarak IBaseBusinessService tanımlı. Temel ve ortak işlemler bu interfaceden kalıtılıyor.
        //varsa eklenecek diğer fonksiyonları buraya tanımlıyoruz
        //SelectResult<User> GetUserList();
        //SelectResult<User> GetUserSingle(User user);
        //SelectResult<User> GetUserListByID(int userID);
        //InsertResult<User> Add(User user);
        //UpdateResult<User> Update(User user);
        //DeleteResult<User> Delete(User user);
        UpdateResult<User> ChangePassword(int userID,string newpassword);
    }
}
