using DataAccess.sql.Repositories;
using DataAccess.SQLServer.Repositories;
using Entities;
using System.Data;

namespace BusinessLogic.core
{
    public class UserAuthentication
    {
        #region Private Variable

        private UserRepository _user = new UserRepository();

        #endregion

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
