using flavour_palette.Model;
using flavour_palette.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.User_Management.Authentication.Repository
{
    public class AuthenticationRepository
    {
        private DatabaseEntities db = DatabaseSingleton.getInstance();

        public User login(string email, string password)
        {
            return (from user in db.Users where user.UserEmail == email && user.UserPassword == password select user).FirstOrDefault();
        }

        public void add(String userName, String userEmail, String userPassword, String userGender, String userAddress, String userRole)
        {
            UserFactory uf = new UserFactory();
            User u = uf.create(userName, userEmail, userPassword, userGender, userAddress, userRole);

            db.Users.Add(u);
            db.SaveChanges();
        }

        public User checkEmailUnique(string email)
        {
            return (from user in db.Users where user.UserEmail == email select user).FirstOrDefault();
        }

        public User getUserIdByEmail(String email)
        {
            return (from User in db.Users where User.UserEmail == email select User).FirstOrDefault();
        }
    }
}