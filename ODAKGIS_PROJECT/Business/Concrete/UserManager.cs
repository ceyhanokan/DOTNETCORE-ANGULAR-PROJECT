using Business.Abstract;
using Core.Handler;
using Core.Model;
using DataAccess.Abstract;
using Entities.TABLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserBusService
    {
        private IUserDAL _UserDal;
        
        public UserManager(IUserDAL userDal)
        {
            _UserDal = userDal;
        }
        public InsertResult<User> Add(User user)
        {
            if(user.UserName.Length < 5)
            {
                return new InsertResult<User>() { IsSuccess = false, Message = " Geçersiz kullanıcı adı." };
            }
            if (isExistUser(user.UserName))
            {
                return new InsertResult<User>() { IsSuccess = false, Message = user.UserName + " kullanıcıadı daha önce kullanılmış. Lütfen başka bir kullanıcı adıyla kayıt yapmayı deneyin." };
            }
            if (!CheckPassword(user.Password))
            {
                return new InsertResult<User>() { IsSuccess = false, Message = " Şifre güvenliği yeterli değil" };
            }
            string crypPassword = Cryptor.Sifrele(user.Password);
            user.Password = crypPassword;
            return _UserDal.Add(user);
        }

        private bool isExistUser(string username)
        {
            var result = _UserDal.GetSingle(p => p.UserName == username);
            if(result != null)
            {
                return true;
            }
            return false;
        }

        public UpdateResult<User> ChangePassword(int userID, string newpassword)
        {
            UpdateResult<User> result = new UpdateResult<User>();
            if (!CheckPassword(newpassword))
            {
                result.IsSuccess = false;
                result.Message = "Şifre en az sekiz ve en fazla 10 karakter, en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter içermelidir";
                return result;
            }
            var currentuser = _UserDal.GetSingle(P => P.UserID == userID).RecordSingle;
            if (currentuser != null)
            {
                string newCryptedPassword = Cryptor.Sifrele(newpassword);
                currentuser.Password = newCryptedPassword;
                result = _UserDal.Update(currentuser);
                result.IsSuccess = true;
                result.Message = "Güncelleme işlemi başarıyla tamamlandı.";
            }
            return result;
        }

        public DeleteResult<User> Delete(User user)
        {
           var result = _UserDal.Detele(user);
            result.IsSuccess = true;
            result.Message = "Silme işlemi başarılı";
            return result;
        }

        public SelectResult<User> GetByID(int userID)
        {
            var result = _UserDal.GetSingle(p=> p.UserID == userID);
            result.IsSuccess = result.RecordSingle != null ? true : false;
            result.Message = result.IsSuccess ? userID + " ID li 1 kayıt bulundu" : "Kayıt Bulunamadı";
            return result;
        }

        public SelectResult<User> GetList()
        {
            var result = _UserDal.GetList();
            result.IsSuccess = true;
            result.Message = "Başarılı";
            return result;
        }

        public SelectResult<User> GetSingle(User user)
        {
            var result = _UserDal.GetSingle(p=> p.UserID == user.UserID);
            result.IsSuccess = result.RecordSingle != null ? true : false;
            result.Message = result.IsSuccess ? user.UserID + " ID li 1 kayıt bulundu" : "Kayıt Bulunamadı";
            return result;
        }

        public UpdateResult<User> Update(User user)
        {
            var result = _UserDal.Update(user);
            result.IsSuccess = true;
            return result;
        }

        /// <summary>
        /// ŞifrelenMemiş text için En az sekiz ve en fazla 10 karakter, en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter
        /// kural kontrolü yapar
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static bool CheckPassword(string password)
        {
            string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$";
            /*
             *  En az sekiz karakter, en az bir harf ve bir sayı:
                "^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"

                En az sekiz karakter, en az bir harf, bir sayı ve bir özel karakter:
                "^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"

                En az sekiz karakter, en az bir büyük harf, bir küçük harf ve bir sayı:
                "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"

                En az sekiz karakter, en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter:
                "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"
             * */
            Match m = Regex.Match(password, regex, RegexOptions.IgnoreCase);
            if (m.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Şifrelenmiş text için Şifrelenmemiş halde En az sekiz ve en fazla 10 karakter, en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter
        /// kural kontrolü yapar.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static bool CheckPasswordWithCrypt(string password)
        {
            string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$";
            /*
             *  En az sekiz karakter, en az bir harf ve bir sayı:
                "^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"

                En az sekiz karakter, en az bir harf, bir sayı ve bir özel karakter:
                "^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"

                En az sekiz karakter, en az bir büyük harf, bir küçük harf ve bir sayı:
                "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"

                En az sekiz karakter, en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter:
                "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"
             * */
            Match m = Regex.Match(password, regex, RegexOptions.IgnoreCase);
            if (m.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
