using DataAccess.sql.Repositories;
using DataAccess.SQLServer.Repositories;
using Entities;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BusinessLogic.core
{
    public class UserAuthentication
    {
        #region Private Variable

        private UserRepository _user = new UserRepository();

        #endregion

        #region CRUD Method

        public void Create(ref User user)
        {
            _user.Create(ref user);
        }

        public void Update(ref User user)
        {
            _user.Update(ref user);
        }

        public void Delete(ref User user)
        {
            _user.Delete(ref user);
        }

        #endregion

        public bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }
        public bool Login(ref User user)
        {
            

            if (_user.VerifyUserByEmail(user.Email,user.Password))
            {
               

                if (_user.AuthenticateUser(ref user))
                {
                    return true;
                }
                else
                {
                    user.ErrorMessage = "La contraseña es incorrecta";
                }
            }
            else 
            {
                user.ErrorMessage = "El correo no se encontro";
            }

            return false;
        }
    }
}
