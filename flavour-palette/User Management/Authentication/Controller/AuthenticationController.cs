using flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace flavour_palette.User_Management.Authentication
{
    public class AuthenticationController
    {
        AuthenticationHandler ah = new AuthenticationHandler();

        public bool doRemember(String email, String password)
        {
            if (ah.login(email, password) != null)
            {
                return true;
            }
            return false;
        }

        public void logout()
        {
            HttpContext.Current.Session["userId"] = null;
            HttpContext.Current.Session["userRole"] = null;

            HttpCookie userCookie = HttpContext.Current.Request.Cookies["UserData"];

            if (userCookie != null)
            {
                userCookie.Values["email"] = null;
                userCookie.Values["password"] = null;
                userCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(userCookie);
            }
        }
        public String checkName(String name)
        {
            String errorMsg = null;
            if (name.Length < 5 || name.Length > 50)
            {
                if (name.Length == 0)
                {
                    errorMsg = "Name must be filled!";
                }
                else
                {
                    errorMsg = "Name must be between 5 and 50 characters!";
                }
            }

            return errorMsg;
        }

        public string doLogin(string email, string password, CheckBox cbRemember)
        {
            String errorMsg = null;

            if (email.Length == 0)
            {
                errorMsg = "Email must be filled!";
            }
            else if (password.Length == 0)
            {
                errorMsg = "Password must be filled!";
            }
            else if (ah.login(email, password) == null)
            {
                errorMsg = "Invalid Credentials!";
            }
            else if (errorMsg == null)
            {
                User currentCustomer = new User();
                currentCustomer = ah.getUserIdByEmail(email);

                if (cbRemember.Checked)
                {
                    HttpCookie userCookie = new HttpCookie("UserData");
                    userCookie.Values["email"] = email;
                    userCookie.Values["password"] = password;
                    userCookie.Expires = DateTime.Now.AddMinutes(1);
                    HttpContext.Current.Response.Cookies.Add(userCookie);
                }

                HttpContext.Current.Session["userId"] = currentCustomer.UserID;
                HttpContext.Current.Session["userRole"] = currentCustomer.UserRole;
                HttpContext.Current.Session["userName"] = currentCustomer.UserName;
                HttpContext.Current.Session["userGender"] = currentCustomer.UserGender;
                HttpContext.Current.Session["userAddress"] = currentCustomer.UserAddress;
                HttpContext.Current.Session["userEmail"] = currentCustomer.UserEmail;


            }
            return errorMsg;
        }

        public String checkEmail(String email)
        {
            String errorMsg = null;

            if (email.Length == 0)
            {
                errorMsg = "Email must be filled!";
            }
            else if (ah.checkEmailUnique(email) != null)
            {
                errorMsg = "Email must be unique!";
            }
            return errorMsg;
        }

        public String checkAddress(String address)
        {
            String errorMsg = null;
            if (address.Length == 0)
            {
                errorMsg = "Address must be filled!";
            }
            else if (!address.EndsWith("Street"))
            {
                errorMsg = "Address must be ends with Street!";
            }
            return errorMsg;
        }

        public String checkPassword(String password)
        {
            String errorMsg = null;

            if (password.Length == 0)
            {
                errorMsg = "Password must be filled!";
            }

            return errorMsg;
        }

        public String isAlphanumeric(String password)
        {
            String errorMsg = null;
            bool isDigit = false;
            bool isLetter = false;
            bool isAlphanumeric = false;
            foreach (char c in password)
            {
                if (Char.IsDigit(c))
                {
                    isDigit = true;
                    break;
                }
            }

            if (isDigit == true)
            {
                foreach (char c in password)
                {
                    if (Char.IsLetter(c))
                    {
                        isLetter = true;
                        break;
                    }
                }
            }

            if (isDigit && isLetter)
            {
                isAlphanumeric = true;
            }

            if (!isAlphanumeric)
            {
                errorMsg = "Password must be alphanumeric!";
            }

            return errorMsg;
        }

        public string checkGender(String gender)
        {
            String errorMsg = null;

            if (gender == "Male" || gender == "Female") return errorMsg;
            errorMsg = "Gender must be filled";
            return errorMsg;
        }

        public string checkConfirm(String password, String confPassword)
        {
            String errorMsg = null;

            if (password == confPassword) return errorMsg;

            errorMsg = "Confirmation Password and Password must be the same";
            return errorMsg;
        }

        public String doRegister(String name, String email, String address, String password, String confPassword, String gender)
        {
            String errorMsg = checkName(name);

            if (errorMsg == null)
            {
                errorMsg = checkEmail(email);
            }
            if (errorMsg == null)
            {
                errorMsg = checkGender(gender);
            }
            if (errorMsg == null)
            {
                errorMsg = checkAddress(address);
            }
            if (errorMsg == null)
            {
                errorMsg = checkPassword(password);
            }
            if (errorMsg == null)
            {
                errorMsg = isAlphanumeric(password);
            }
            if (errorMsg == null)
            {
                errorMsg = checkConfirm(password, confPassword);
            }
            if (errorMsg == null)
            {
                ah.addUser(name, email, password, gender, address, "Customer");
            }
            return errorMsg;
        }
    }
}