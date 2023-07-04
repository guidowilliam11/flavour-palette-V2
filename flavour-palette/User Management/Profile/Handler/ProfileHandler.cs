using flavour_palette.Model;
using flavour_palette.User_Management.Profile.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.User_Management.Profile
{
    public class ProfileHandler
    {
        private ProfileRepository pr = new ProfileRepository();

        public void updateUser(int userId, String userName, String userEmail, String userPassword, String userGender, String userAddress)
        {
            pr.update(userId, userName, userEmail, userPassword, userGender, userAddress);
        }

        public User getUserIdByEmail(string email)
        {
            return pr.getUserIdByEmail(email);
        }

        public void deleteAccount(int userId)
        {
            pr.delete(userId);
        }
    }
}