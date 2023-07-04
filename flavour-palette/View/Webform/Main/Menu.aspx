<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Main/Main.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="flavour_palette.View.Webform.Main.Menu" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .indicator-container{
            display: flex;
            flex-direction: column;
            position: absolute;
            top: 50%;
            left: 5%;
            transform: translateX(-50%);
            z-index: 50;
            transition: all 0.3s;
        }

        .indicator-container input[type="radio"] {
            display: none;
        }

        .indicator-container label {
            display: inline-block;
            width: 1rem;
            height: 1rem;
            border-radius: 50%;
            margin: 10px 5px;
            cursor: pointer;
        }

        .indicator-container input[type="radio"]:not(:checked)+label {
            background-color: rgba(255, 255, 255, 0.411);
        }

        .indicator-container input[type="radio"]:checked+label {
            border: 1px solid white;
            background-color: white;
        }

        .slide {
            width: 100%;
            height: 100%;
            background-position: center;
            background-size: cover;
            transition: display 1s, transform 1s;
            display: none;
        }

        .active-slide{
            display: block;
        }
    </style>

    <div>
        <%if (Session["userRole"] as String != "Admin") {%>
            <!-- Carousel -->
            <div class="carousel-background flex w-screen overflow-x-hidden">
                <div class="slide slide-1 w-full">
                    <img src="../../../Storage/slider/slide-1.png" alt="slide 1" class="w-full">
                </div>
                <div class="slide slide-2 w-full">
                    <img src="../../../Storage/slider/slide-2.png" alt="slide 2" class="w-full">
                </div>
                <div class="slide slide-3 w-full">
                    <img src="../../../Storage/slider/slide-3.png" alt="slide 3" class="w-full">
                </div>
            </div>
            <div class="indicator-container">
                <input type="radio" name="carousel-indicator" id="indicator-1" class="page-indicator" checked>
                <label for="indicator-1" class="page-indicator-style"></label>

                <input type="radio" name="carousel-indicator" id="indicator-2" class="page-indicator">
                <label for="indicator-2" class="page-indicator-style"></label>

                <input type="radio" name="carousel-indicator" id="indicator-3" class="page-indicator">
                <label for="indicator-3" class="page-indicator-style"></label>
            </div>
            <script>
                var carousel = document.querySelector('.carousel-background');
                var slides = carousel.querySelectorAll('.slide');
                var radioButtons = document.querySelectorAll('.page-indicator');
                var indexNow = 0;
                const slideInterval = 3000;

                function displaySlide(index) {
                    for (var i = 0; i < slides.length; i++) {
                        slides[i].classList.remove('active-slide');
                    }
                    slides[index].classList.add('active-slide');
                }

                function changeSlide() {
                    for (var i = 0; i < radioButtons.length; i++) {
                        if (radioButtons[i].checked) {
                            indexNow = i;
                            displaySlide(indexNow);
                            break;
                        }
                    }
                }

                function nextSlide(){
                    radioButtons[indexNow].checked = false;
                    indexNow++;
                    if (indexNow >= slides.length) {
                        indexNow = 0;
                    }
                    radioButtons[indexNow].checked = true;
                    changeSlide(indexNow);
                }

                function startCarousel() {
                    setInterval(nextSlide, slideInterval);
                }

                displaySlide(indexNow);
                startCarousel();
            </script>
        <%} %>
    </div>

    <%if (Session["userRole"] as String == "Admin")
        {%>
        <h1 class="mt-10 pt-10 mx-12 pb-6 text-6xl font-bold text-primary text-center mt-10 border-b-2 border-primary">Available Meals</h1>

    <%}
        else
        {%>
    <h1 class="mx-12 pb-6 text-6xl font-bold text-primary text-center mt-10 border-b-2 border-primary">Pick Your Meals</h1>

    <%} %>

    <div class="flex flex-wrap justify-between gap-y-[50px] my-10 px-10">
        <asp:Repeater runat="server" ID="availableFoodRepeater">
            <ItemTemplate>
                <div class="relative w-80 min-h-[450px] rounded bg-white shadow-md overflow-hidden cursor-pointer">
                    <a href="/View/Webform/Main/MenuDetail.aspx?id=<%# Eval("FoodID") %>">
                        <img src="../../../Storage/profile/menu/<%# Eval("FoodImage") %>" alt="<%# Eval("FoodImage") %>" class="w-full aspect-square object-cover"/>
                    </a>
                    <div class="p-5">
                        <div class="flex gap-2 items-end justify-between grow">
                            <div class="flex flex-col gap-5 grow">
                                <div class=" w-max text-secondary font-semibold text-heading"><%# Eval("FoodName") %></div>
                                <div class=" text-secondary text-subheading font-semibold">
                                Rp<%# String.Format("{0:N2}", Eval("FoodPrice")) %>
                                </div>                        
                            </div>
                            <%if (Session["userRole"] as String == "Customer")
                                    {%>
                                    <div>
                                        <asp:Button ID="btnAddToCart" runat="server" CssClass="bg-primary rounded-full h-12 w-12 flex items-center justify-center text-white font-medium text-title hover:shadow-primary hover:shadow" Text="+" OnClick="btnAddToCart_Click" CommandArgument='<%# Eval("FoodID") %>' />
                                    </div>
                                <%} %>
                        </div>

                        <%if (Session["userRole"] as String == "Admin")
                            {%>
                        <div class="mt-5 flex items-center justify-between">
                            <a href="?id=<%# Eval("FoodID") %>" class="w-2/3 btn-primary">Edit</a>
                            <a href="../ArchiveFood.aspx?id=<%# Eval("FoodID") %>" class="mx-auto text-primary text-subheading font-medium">Archive</a>
                        </div>
                            <%} %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="h-[1px] w-80 bg-transparant"></div>
        <div class="h-[1px] w-80 bg-transparant"></div>
        <div class="h-[1px] w-80 bg-transparant"></div>
        <div class="h-[1px] w-80 bg-transparant"></div>
    </div>

    <%if (Session["userRole"] as String == "Admin")
        {%>
            <h1 class="mx-12 pb-6 text-6xl font-bold text-primary text-center mt-10 border-b-2 border-primary">Archived Meals</h1>
            <div class="flex flex-wrap justify-between gap-y-[50px] my-10 px-10">
                <asp:Repeater runat="server" ID="archivedFoodRepeater">
                    <ItemTemplate>
                        <div class="relative w-80 min-h-[450px] rounded bg-white shadow-md overflow-hidden cursor-pointer">
                            <a href="/View/Webform/Main/MenuDetail.aspx?id=<%# Eval("FoodID") %>">
                                <img src="../../../Storage/profile/menu/<%# Eval("FoodImage") %>" alt="<%# Eval("FoodImage") %>" class="w-full aspect-square object-cover"/>
                            </a>
                            <div class="p-5">
                                <div class="flex gap-2 items-end justify-between grow">
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
                                <div class="mt-5 flex items-center justify-between">
                                    <a href="?id=<%# Eval("FoodID") %>" class="w-2/3 btn-primary">Edit</a>
                                    <a href="../AvailableFood.aspx?id=<%# Eval("FoodID") %>" class="mx-auto text-primary text-subheading font-medium">Show</a>
                                </div>
                                    <%} %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="h-[1px] w-80 bg-transparant"></div>
                <div class="h-[1px] w-80 bg-transparant"></div>
                <div class="h-[1px] w-80 bg-transparant"></div>
                <div class="h-[1px] w-80 bg-transparant"></div>
            </div>
            <div class="mb-10 flex flex-col items-center justify-center p-10 mx-auto bg-white rounded shadow w-1/2 mt-20 border border-primary border-opacity-50">
                    <div class="flex w-full flex-col gap-5">
                        <% if (String.IsNullOrEmpty(Request.QueryString["id"]))
                            { %>
                            <div>
                                <h2 class="text-center text-title font-semibold text-secondary" >Add New Menu</h2>
                            </div>

                        <% } else {%>
                            <div>
                                <h2 class="text-center text-title font-semibold text-secondary" >Update <%= Request.QueryString["id"].ToString() %></h2>
                            </div>

                        <%} %>
                        <div>
                            <label for="menu_name" class="form-label">Image</label>
                            <asp:FileUpload ID="fuImage" class="input-form p-0 ring-0" name="menu_image" placeholder="Menu Image" runat="server"/>
                        </div>

                        <div>
                            <label for="menu_name" class="form-label">Name</label>
                            <asp:TextBox ID="tbName" type="text" class="input-form" placeholder="Menu Name" runat="server"></asp:TextBox>
                        </div>

                        <div>
                            <label for="menu_price" class="form-label">Price</label>
                            <asp:TextBox ID="tbPrice" type="number" class="input-form" placeholder="Menu Price" runat="server"></asp:TextBox>
                        </div>

                        <div>
                            <label for="menu_description" class="form-label">Description</label>
                            <asp:TextBox ID="tbDescription" type="text" TextMode="MultiLine" Rows="4" Columns="40" class="input-form" placeholder="Menu Description" runat="server"></asp:TextBox>
                        </div>

                        <div>
                            <label for="status" class="form-label">Status</label>
                        <asp:RadioButtonList ID="rbStatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Available" Value="Available" class="mr-2"/>
                            <asp:ListItem Text="Archive" Value="Archive"/>
                        </asp:RadioButtonList>
                        </div>

                        <asp:Label ID="lbError" class="text-center text-red-500 text-name font-semibold mt-5" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnSave" class="btn-primary" runat="server" Text="Save" OnClick="btnSave_Click"/>
                    </div>
                </div>

    <%}%>
</asp:Content>
