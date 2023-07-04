<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Main/Main.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="flavour_palette.View.Webform.Main.History" %>
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
    <h1 class="text-title text-secondary font-semibold mb-5 px-12 pt-12">Order History</h1>
    <div class="flex h-max overflow-x-scroll hide-scroll-bar w-full p-12">
        <div class="flex flex-col gap-5 p-1 w-full">
            <asp:Repeater runat="server" ID="headerRepeater">
                <ItemTemplate>
                    <a href="DetailPage.aspx?TransactionId=<%# Eval("TransactionId") %>" class="flex flex-col items-center justify-center w-full gap-5">
                        <div class=" bg-white rounded shadow w-full p-5 border border-primary border-opacity-50 flex flex-col gap-4">
                            <div class="flex gap-3 items-center text-primary">
                                <div class="text-primary font-normal text-subname">
                                    <%# Eval("TransactionDate") %>
                                </div>
                                |
                                <div class="text-primary font-normal text-subname">
                                    <%# Eval("TransactionId") %>
                                </div>
                            </div>

                            <div class="flex justify-between items-center h-full ">
                                <div class="w-3/4 h-full flex flex-col gap-2">
                                    <div class="text-base text-dgray">Preview</div>
                                    <div class="flex w-full items-center gap-2">
                                        <div class="w-[50px]">
                                            <img src="../../../storage/profile/menu/<%# Eval("FoodImage") %>" alt="<%# Eval("FoodImage") %>" class="w-full aspect-square object-cover" />
                                        </div>
                                        <div class="text-heading text-secondary font-medium">
                                            <%# Eval("FoodName") %>
                                        </div>
                                    </div>
                                    <div class="mt-1 text-name text-primary font-normal">+ item(s)</div>
                                </div>
                            </div>
                            <div class="text-right text-primary text-name font-medium">See Detail</div>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>