using flavour_palette.Model;
using flavour_palette.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.User_Management.Profile.Repository
{
    public class ProfileRepository
    {
        private DatabaseEntities db = DatabaseSingleton.getInstance();
        public List<User> fetchAll()
        {
            return (from User in db.Users select User).ToList();
        }

        public User search(int id)
        {
            return (from User in db.Users where User.UserID == id select User).FirstOrDefault();
        }

        public User getUserIdByEmail(String email)
        {
            return (from User in db.Users where User.UserEmail == email select User).FirstOrDefault();
        }

        public void delete(int id)
        {
            User a = search(id);
            db.Users.Remove(a);
            db.SaveChanges();
        }

        public void update(int id, String UserName, String UserEmail, String UserPassword, String UserGender, String UserAddress)
        {
            User c = search(id);
            c.UserName = UserName;
            c.UserEmail = UserEmail;
            c.UserPassword = UserPassword;
            c.UserGender = UserGender;
            c.UserAddress = UserAddress;

            db.SaveChanges();
        }

        public void update(int id, String UserName, String UserEmail, String UserPassword, String UserGender, String UserAddress, String UserRole)
        {
            User c = search(id);
            c.UserName = UserName;
            c.UserEmail = UserEmail;
            c.UserPassword = UserPassword;
            c.UserGender = UserGender;
            c.UserAddress = UserAddress;
            c.UserRole = UserRole;

            db.SaveChanges();
        }
    }
}