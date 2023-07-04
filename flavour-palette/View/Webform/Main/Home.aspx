<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Main/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="flavour_palette.View.Webform.Main.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="relative h-screen w-screen">
        <div class="absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-[60%] w-[65%] h-max px-24 py-12 flex flex-col gap-10 items-center justify-center z-20 rounded bg-white bg-opacity-70 text-center text-primary shadow-md">
            <% if (Session["userRole"] as String == "Admin")
                {%>
                <h1 class="text-title font-bold drop-shadow-md">Increase Your Sales with Flavour Palette</h1>
                <p class="text-secondary text-heading font-medium">Welcome to our online catering website! We provide an easy and convenient way for you to showcase and sell your delicious food to a wide audience. Our platform offers a simple and user-friendly interface for you to manage your orders and reach new customers. Join us and become part of our growing community of satisfied sellers and customers. Start selling on our website today and let us help you grow your business!</p>
            <% }
                else
                {%>
                <h1 class="text-title font-bold drop-shadow-md">Savor with Ease Delicious Meals for All</h1>
                <p class="text-secondary text-heading font-medium">Welcome to our online catering website! We provide a wide variety of delicious food that can be easily enjoyed by everyone. We offer a wide selection of food that can satisfy your taste buds. We believe that good food doesn't have to be difficult to enjoy. Therefore, we provide easy and fast online catering services so you can enjoy delicious food anytime, anywhere.</p>
                <a href="Menu.aspx" class="btn-primary">View Menu</a>
            <%} %>
        </div>
        <div class="absolute inset-0 z-10">
            <img src="../../../Storage/assets/general/header-photo.png" alt="" class="w-full h-screen object-cover">
        </div>
    </section>

    <div class="w-[85%] h-max mx-auto my-20 flex flex-col gap-20">
        <div class="flex w-full h-max justify-between items-center">
            <div class="h-full flex flex-col gap-10 w-[45%]">
                <h1 class="text-secondary font-semibold text-title text-left">Revolutionize Your Daily Meals</h1>
                <p class="text-secondary text-heading font-normal  text-left">Are you tired of the same boring meals every day? Say goodbye to mealtime monotony with our catering subscription service! Our platform allows you to customize your daily meals according to your dietary preferences and taste buds.</p>
                <a href="Menu.aspx" class="btn-secondary">View Menu</a>
            </div>
            <img class="w-[50%] h-auto" src="../../../Storage/assets/home/first-image.png" alt="">
        </div>

    <img class="w-full h-auto shadow-md" src="../../../Storage/assets/home/second-image.png" alt="">

    <div>
        <style>
            .hide-scroll-bar {
            -ms-overflow-style: none;
            scrollbar-width: none;
        }

        .hide-scroll-bar::-webkit-scrollbar {
            display: none;
        }
        </style>
        <h1 class="text-title text-secondary font-semibold mb-5"> Popular Menu For The Week</h1>
        <div class="flex h-max overflow-x-scroll hide-scroll-bar">
            <div class="flex gap-5 p-1">
                <asp:Repeater runat="server" ID="foodRepeater">
                    <ItemTemplate>
                        <div class="relative w-80 min-h-[450px] rounded bg-white shadow-md overflow-hidden cursor-pointer">
                            <a href="/View/Webform/Main/MenuDetail.aspx?id=<%# Eval("FoodID") %>">
                                <img src="../../../Storage/profile/menu/<%# Eval("FoodImage") %>" alt="<%# Eval("FoodImage") %>" class="w-full aspect-square object-cover"/>
                            </a>
                            <div class="m-5 flex gap-2 items-end justify-between grow">
                                <div class="flex flex-col gap-5 grow">
                                    <div class=" w-max text-secondary font-semibold text-heading"><%# Eval("FoodName") %></div>
                                    <div class=" text-secondary text-subheading font-semibold">
                                    Rp<%# String.Format("{0:N2}", Eval("FoodPrice")) %>
                                    </div>                        
                                </div>
                                <%if (Session["userRole"] as String == "Customer")
                                {%>
                                <div>
                                    <button class="bg-primary rounded-full h-12 w-12 flex items-center justify-center text-white font-medium text-title hover:shadow-primary hover:shadow" type="submit">+</button>
                                </div>
                            <%} %>
                            </div>

                            <%if (Session["userRole"] as String == "Admin")
                                {%>
                            <a href="/View/Main/Update.aspx?id=<%# Eval("FoodID") %>" class="w-2/3 text-center text-dPink font-medium border-2 border-dPink px-6 py-2 rounded-full hover:bg-dPink hover:text-white">Update Food</a>
                            <a href="/View/Delete.aspx?id=<%# Eval("FoodID") %>" class="w-2/3 text-center text-white font-medium bg-dPink border-2 border-dPink px-6 py-2 rounded-full hover:bg-dDPink hover:border-dDPink">Delete Food</a>
                            <%} %>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </div>

    <%if (Session["userRole"] as String != "Admin") { %>
            <!-- About Us -->
            <div class="w-full flex justify-between">
                <img src="../../../Storage/assets/home/food-photo.png" alt="food image" class="mb-auto w-[35%]">
                <div class="flex flex-col items-end justify-between w-[60%] gap-10">
                    <div>
                        <div class="h-full flex flex-col gap-5 w-full items-start">
                            <h1 id="about-us" class="text-title text-secondary font-semibold">About Us</h1>
                            <p class="text-heading text-secondary font-normal">We are Flavour Palette, an online catering service that allows you to enjoy quality meals every day. We have more than 100 professional catering kitchens that are ready to cook your favorite menu, from healthy, fusion, oriental, to traditional dishes. You can order daily catering menu through Flavour Palette app with affordable price and flexible booking. You can also freely customize your catering menu according to your taste and schedule.</p>
                        </div>
                    </div >
                    <div class="flex justify-between items-center">
                        <img src="../../../Storage/assets/home/delivery-photo.png" alt="delivery image" class="w-[45%] h-full object-cover">
                        <img src="../../../Storage/assets/home/katsu-photo.png" alt="katsu image" class="w-[52%] h-full object-cover">
                    </div>
                </div>
            </div>
        <%} %>
    </div>

</asp:Content>
