<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Main/Main.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="flavour_palette.View.Webform.Main.Cart" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
            .hide-scroll-bar {
            -ms-overflow-style: none;
            scrollbar-width: none;
        }

        .hide-scroll-bar::-webkit-scrollbar {
            display: none;
        }
        </style>
    <div class="p-12">
        <% if (Session["userRole"] as String != "Admin") { %>
        <h1 class="text-title text-secondary font-semibold mb-5">Cart</h1>
        <div class="flex h-max justify-between ">
            <div class="flex flex-col gap-5 p-1 w-[50%]">
                <asp:Repeater runat="server" ID="cartRepeater">
                    <ItemTemplate>
                        <div class="flex gap-5 h-fit border-b-2 border-dgray pb-6" data-user-id='<%# Eval("UserId") %>' data-food-id='<%# Eval("FoodId") %>'>
                            <div class="w-40">
                                <img src="../../../Storage/profile/menu/<%# Eval("Food.FoodImage") %>" alt="<%# Eval("Food.FoodImage") %>" class="rounded shadow object-cover w-full aspect-square" />
                            </div>
                            <div class="flex flex-col grow justify-between">
                                <div class="text-secondary font-semibold text-heading"><%# Eval("Food.FoodName") %></div>
                                <div class="text-secondary"><%# Eval("Food.FoodDescription") %></div>
                                <div class="text-secondary">Price: Rp<%# String.Format("{0:N2}", Eval("Food.FoodPrice")) %></div>
                                <div class="text-secondary">Status: <%# Eval("Food.FoodStatus") %></div>
                                <div class="text-secondary flex">
                                   <asp:Button runat="server" ID="decreaseButton" CssClass="flex items-center justify-center bg-primary text-white rounded-l w-10 h-10"
                                        Text="-" CommandArgument='<%# Eval("FoodId") + "|" + Eval("Qty") %>' CommandName="Decrease" OnCommand="button_Command" />
                                   <asp:TextBox runat="server" ID="quantityTextBox" CssClass="w-10 h-10 text-center outline-none border-y border-primary"
                                        Text='<%# Eval("Qty") %>' Enabled="false" />
                                   <asp:Button runat="server" ID="increaseButton" CssClass="flex items-center justify-center bg-primary text-white rounded-r w-10 h-10"
                                        Text="+" CommandArgument='<%# Eval("FoodId") + "|" + Eval("Qty") %>' CommandName="Increase" OnCommand="button_Command" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="grow flex justify-center w-[50%]">
                <div class="w-[50%] p-6 h-fit bg-white shadow rounded">
                    <div class="flex w-full justify-between ">
                        <div class="text-secondary font-semibold">Total Price:</div>
                        <asp:Literal runat="server" ID="totalAmountLiteral" />
                    </div>
                    <asp:Button runat="server" ID="checkoutButton" Text="Checkout" OnClick="checkoutButton_Click" CssClass="w-full btn btn-primary mx-auto mt-3" />
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
