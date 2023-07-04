using flavour_palette.Model;
using flavour_palette.User_Management.Authentication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.User_Management.Authentication
{
    public class AuthenticationHandler
    {
        private AuthenticationRepository ar = new AuthenticationRepository();

        public void addUser(String userName, String userEmail, String userPassword, String userGender, String userAddress, String userRole)
        {
            ar.add(userName, userEmail, userPassword, userGender, userAddress, userRole);
        }


        public User checkEmailUnique(string email)
        {
            return ar.checkEmailUnique(email);
        }

        public User login(string email, string password)
        {
            return ar.login(email, password);
        }

        public User getUserIdByEmail(string email)
        {
            return ar.getUserIdByEmail(email);
        }
    }
}