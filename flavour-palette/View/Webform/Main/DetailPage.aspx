<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Main/Main.Master" AutoEventWireup="true" CodeBehind="DetailPage.aspx.cs" Inherits="flavour_palette.View.Webform.Main.DetailPage" %>
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
     <h1 class="text-title text-secondary font-semibold mb-5">Order Detail</h1>
        <div class="flex h-max overflow-x-scroll hide-scroll-bar">
            <div class="flex flex-col gap-5 p-1">
                <h3 class="text-title text-secondary font-semibold mb-5"><%# trHeader.TransactionDate %></h3>


                <asp:repeater runat="server" id="detailRepeater">
                    <itemtemplate>
                        <div class="flex gap-5"  data-Food-id='<%# Eval("Food.FoodID") %>'>
                            <div class="w-32">
                                <img src="../../../storage/profile/menu/<%# Eval("Food.FoodImage") %>" alt="<%# Eval("Food.FoodImage") %>" class="w-full aspect-square object-cover" />
                            </div>
                            <div class="flex flex-col">
                                <div class="text-secondary font-semibold text-heading"><%# Eval("Food.FoodName") %></div>
                                <div class="text-secondary font-semibold text-heading"><%# Eval("Qty") %></div>
                                <div class="text-secondary"><%# Eval("Food.FoodDescription") %></div>
                                <div class="text-secondary">price: <%# Eval("Food.FoodPrice") %></div>
                                <div class="text-secondary">
                                </div>
                            </div>
                        </div>
                    </itemtemplate>
                </asp:repeater>
                <%--<div class="text-secondary font-semibold">total: <asp:literal runat="server" id="totalamountliteral" /></div>--%>
                <%--<asp:button runat="server" id="checkoutbutton" text="checkout" onclick="checkoutbutton_click" cssclass="btn btn-primary mt-3" />--%>
            </div>
        </div>
</asp:Content>
