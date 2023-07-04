using Model = flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.User_Management.Authentication
{
    public class UserFactory
    {
        public Model.User create(String name, String email, String password, String gender, String address, String role)
        {
            Model.User user = new Model.User();

            user.UserName = name;
            user.UserEmail = email;
            user.UserPassword = password;
            user.UserGender = gender;
            user.UserAddress = address;
            user.UserRole = role;

            return user;
        }
    }
}