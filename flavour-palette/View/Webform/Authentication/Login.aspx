<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Authentication/Authentication.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="flavour_palette.View.Webform.Authentication.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-[60%] py-12 min-h-full flex flex-col justify-center">
        <a href="../Main/Home.aspx"><img src="../../../Storage/assets/general/logo.png" class="mx-auto h-20 w-auto"></a>
        <h2 class="mt-5 text-center text-title text-secondary font-semibold">Welcome Back!</h2>
        <p class="mt-5 text-center text-name text-secondary font-normal">Sign in to continue</p>

        <div class="mt-10 w-full">
            <div>
                <label for="email" class="form-label">Email</label>
                <asp:TextBox type="email" ID="tbEmail" name="email" class="input-form" placeholder="Email" runat="server"></asp:TextBox>
            </div>
            <div class="mt-5">
                <label for="password" class="form-label">Password</label>
                <div class="relative flex items-center w-full h-fit">
                    <asp:TextBox type="password" class="input-form" id="tbPassword" name="password" placeholder="Password" runat="server"></asp:TextBox>
                    <div class="absolute top-1/2 right-[10px] -translate-y-1/3 cursor-pointer" onclick="password()">
                        <i id="eye-icon" class="fa fa-eye-slash"></i>
                    </div>
                </div>
            </div>

            <asp:Label ID="lbError" class="text-center text-red-500 text-name font-semibold mt-10" runat="server" Text=""></asp:Label>


            <div class="mt-10 flex items-center justify-center gap-3">
                <asp:CheckBox ID="cbRemember" class="rounded" type="checkbox" runat="server" />
                <label class="text-secondary text-name font-medium" for="remember">Remember Me</label>
            </div>

            <div class="mt-5 flex justify-center w-full">
                <asp:Button ID="btnLogin" class="w-full btn-primary" runat="server" Text="Sign In" OnClick="btnLogin_Click"/>
            </div>

            <p class="mt-20 text-center text-name text-secondary font-normal">
                Don’t have an account?
                <a href="Register.aspx" class ="text-primary text-name font-medium hover:text-secondary hover:underline" type="button">Sign Up</a>
            </p>
        </div>

    </div>
</asp:Content>
