<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Main/Main.Master" AutoEventWireup="true" CodeBehind="MenuDetail.aspx.cs" Inherits="flavour_palette.View.Webform.Main.MenuDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex gap-10 w-full p-12 h-fit">
        <div class="w-1/4 h-fit px-6">
            <img class="w-full aspect-square rounded object-cover" src="../../../Storage/profile/menu/<%= imageName%>"/>
        </div>
        <div class="flex flex-col gap-5 h-grow w-1/4 ml-6 pr-12 border-b-2 border-dgray">
            <div id="currentDate" class="text-primary text-name font-medium text-justify"></div>
            <div class="text-secondary font-semibold text-title">
                <asp:Label ID="lbName" runat="server" Text=""></asp:Label>
            </div>
            <div class="text-secondary font-semibold text-title">
                <asp:Label ID="lbPrice" runat="server" Text=""></asp:Label>
                <asp:Label ID="price" runat="server" Text="" ClientIDMode="Static" display="none"></asp:Label>
            </div>
            <div class="w-full">
                <div class="text-dgray font-normal text-subheading text-justify">Description</div>
                <div class="font-normal text-heading text-secondary">
                    <asp:Label ID="lbDescription" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="flex grow px-6 justify-center items-center">
            <%if (Session["userRole"] as String == "Customer")
                {%>
                <div class="px-6 flex justify-center items-center w-[70%] rounded shadow bg-white border border-primary border-opacity-20 h-fit">
                    <div class="flex flex-col gap-5 p-5 w-full">
                        <div class="text-secondary text-heading font-semibold">Add to Cart</div>
                            <div class="flex gap-2 items-center">
                                <img class="w-[50px] h-[50px] object-cover rounded" src="../../../Storage/profile/menu/<%= imageName%>"/>
                                <div class="text-secondary text-subheading font-medium">
                                    <asp:Label ID="lbName2" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr class="line">
                            <div class="flex items-center justify-center w-full">
                                <label class="flex items-center justify-center bg-primary text-white rounded-l w-10 h-10" id="decrease">-</label>
                                <asp:TextBox class="w-10 h-10 text-center outline-none border-y border-primary" TextMode="Number" id="quantity" value="1" runat="server" ClientIDMode="Static"></asp:TextBox>
                                <label class="flex items-center justify-center bg-primary text-white rounded-r w-10 h-10" id="increase">+</label>
                            </div>
                            <div class="flex justify-between items-center w-full">
                                <label class="text-secondary text-subheading font-medium">Subtotal</label>
                                <span id="total_price" class="text-secondary text-subheading font-medium">Rp ini harganya ,00</span>
                            </div>
                            <div class="flex flex-col gap-2 items-center justify-center">
                                <asp:Button class="w-full btn-primary"  ID="Button1" runat="server" OnClick="btnAddToCart_Click" Text="+ Cart" />
                                <%--<button type="submit" class="w-full btn-primary" OnClick="btnAddToCart_Click">+ Cart</button>--%>
                            </div>
                        </div>
                </div>
            <%} %>
        </div>
    </div>
    <div class="p-12">
        <style>
            .hide-scroll-bar {
            -ms-overflow-style: none;
            scrollbar-width: none;
        }

        .hide-scroll-bar::-webkit-scrollbar {
            display: none;
        }
        </style>
        <h1 class="text-title text-secondary font-semibold mb-5"> Other Choices</h1>
        <div class="flex h-max overflow-x-scroll hide-scroll-bar">
            <div class="flex gap-10 p-1">
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
    <script>
    var currentDateElement = document.getElementById("currentDate");
    var currentDate = new Date();
    var formattedDate = currentDate.toDateString();

    currentDateElement.textContent = formattedDate;

        $(document).ready(function () {


            // Calculate and update total price
        function updateTotalPrice() {
            var quantity = parseInt($("#quantity").val());
            var foodPrice1 = document.getElementById('price');
            var foodPrice = foodPrice1.innerText;

            var totalPrice = quantity * foodPrice;
            $("#total_price").text("Rp " + totalPrice.toFixed(2));
        }

        // Decrease quantity on click
        $("#decrease").on("click", function () {
            var currentQty = parseInt($("#quantity").val());
            if (currentQty > 1) {
                $("#quantity").val(currentQty - 1);
                updateTotalPrice();
            }
        });

        // Increase quantity on click
        $("#increase").on("click", function () {
            var currentQty = parseInt($("#quantity").val());
            $("#quantity").val(currentQty + 1);
            updateTotalPrice();
        });


        // Initial update of total price
        updateTotalPrice();
    });


    </script>

</asp:Content>
