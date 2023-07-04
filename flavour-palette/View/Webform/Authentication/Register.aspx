<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Authentication/Authentication.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="flavour_palette.View.Webform.Authentication.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="w-[60%] py-12 min-h-full flex flex-col justify-center">
        <a href="../Main/Home.aspx"><img src="../../../Storage/assets/general/logo.png" class="mx-auto h-20 w-auto"></a>
        <h2 class="mt-5 text-center text-title text-secondary font-semibold">Hello!</h2>
        <p class="mt-5 text-center text-name text-secondary font-normal">Sign up to continue</p>

        <div class="mt-10 w-full">

            <div id="form-content">
                    <div class="mt-10">
                        <label for="email" class="form-label">Email</label>
                        <asp:TextBox ID="tbEmail" type="text" class="input-form" runat="server" placeholder="Email"></asp:TextBox>
                    </div>

                    <div class="mt-5">
                        <label for="fullname" class="form-label">Full Name</label>
                        <asp:TextBox ID="tbName" type="text" class="input-form" runat="server" placeholder="Full Name"></asp:TextBox>
                    </div>

                    <div class="mt-5">
                        <label for="password" class="form-label">Password</label>
                        <div id="password_div" class="relative flex items-center w-full h-fit">
                            <asp:TextBox ID="tbPassword" type="password" class="input-form" runat="server" placeholder="Password"></asp:TextBox>
                            <div class="absolute right-[10px] top-1/2 -translate-y-1/3" onclick="password()">
                                <i id="eye-icon-pw" class="fa fa-eye-slash"></i>
                            </div>
                        </div>
                    </div>

                    <div class="mt-5">
                        <label for="password_confirmation" class="form-label">Confirm Password</label>
                        <div id="confirm_password_div" class="relative flex items-center w-full h-fit">
                            <asp:TextBox ID="tbPasswordConf" type="password" class="input-form" runat="server" placeholder="Password"></asp:TextBox>
                            <div class="absolute right-[10px] top-1/2 -translate-y-1/3" style="right: 10px;" onclick="confirm_password()">
                                <i id="eye-icon-conf" class="fa fa-eye-slash"></i>
                            </div>
                        </div>
                    </div>

                    <div class="mt-5 form-label flex">
                        <label for="gender" class="mr-2 form-label">Gender</label>
                        <asp:RadioButtonList ID="rbGender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Male" Value="Male" class="mr-2"/>
                            <asp:ListItem Text="Female" Value="Female"/>
                        </asp:RadioButtonList>
                    </div>
                    
                    <div class="mt-5 mb-5">
                        <label for="address" class="form-label">Address</label>
                        <asp:TextBox ID="tbAddress" type="text" class="input-form" runat="server" placeholder="Email"></asp:TextBox>
                    </div>

                </div>
                    <asp:Label ID="lbError" class="text-center text-red-500 text-name font-semibold mt-10" runat="server" Text=""></asp:Label>
    
                <div class="mt-10 flex justify-center w-full">
                    <asp:Button ID="btnRegister" class="w-full btn-primary" runat="server" Text="Sign Up" OnClick="btnRegister_Click"/>
                </div>
    
                <p class="mt-20 text-center text-name text-secondary font-normal">
                    Already have an account?
                    <a href="Login.aspx" class="text-primary text-name font-medium hover:text-secondary hover:underline" type="button">Sign In</a>
                </p>
            </div>
        </div>
</asp:Content>
