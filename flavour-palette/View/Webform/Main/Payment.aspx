<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Main/Main.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="flavour_palette.View.Webform.Main.Payment" %>
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
        
            <div class="bg-primary flex flex-col px-5 py-3 rounded mb-10">
                <label class="text-white font-medium">Location</label>
                <div class="flex items-center gap-2">
                    <img src="../../../Storage/assets/icon/location.png") }}" style="width: 20px">
                    <asp:TextBox runat="server" ID="addressInput" class="w-full outline-none border-0 bg-transparent text-white text-subheading font-medium placeholder:text-white placeholder:font-normal" />
                    <asp:Label runat="server" ID="addressErrorLabel" CssClass="text-danger text-red" Visible="false" Text="Address must be filled" />
                </div>
            </div>
            <div class="flex h-max overflow-x-scroll hide-scroll-bar">
                <div class="flex flex-col gap-5 p-1">
                    <asp:Repeater runat="server" ID="cartRepeater">
                        <ItemTemplate>
                            <div class="flex gap-5" data-user-id='<%# Eval("UserId") %>' data-food-id='<%# Eval("FoodId") %>'>
                                <div class="w-32">
                                    <img src="../../../Storage/profile/menu/<%# Eval("Food.FoodImage") %>" alt="<%# Eval("Food.FoodImage") %>" class="w-full aspect-square object-cover" />
                                </div>
                                <div class="flex flex-col">
                                    <div class="text-secondary font-semibold text-heading"><%# Eval("Food.FoodName") %></div>
                                    <div class="text-secondary"><%# Eval("Food.FoodDescription") %></div>
                                    <div class="text-secondary">Price: <%# Eval("Food.FoodPrice") %></div>
                                    <div class="text-secondary">Status: <%# Eval("Food.FoodStatus") %></div>
                                    <div class="text-secondary">
                                        Total Cost: <%# Convert.ToDecimal(Eval("Food.FoodPrice")) * Convert.ToDecimal(Eval("Qty")) %>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="grow flex justify-center w-[50%]">
                <div class="w-[50%] p-6 h-fit bg-white shadow rounded">
                    
                    <div class="text-secondary font-semibold">Total: <asp:Literal runat="server" ID="totalAmountLiteral" /></div>
                    <div class="mt-3">
                        <label for="paymentMethod" class="text-secondary">Payment Method:</label>
                        <asp:DropDownList runat="server" ID="paymentMethod" CssClass="w-full border border-primary rounded p-1">
                            <asp:ListItem Text="BCA" Value="1" />
                            <asp:ListItem Text="Gopay" Value="2" />
                            <asp:ListItem Text="ShopeePay" Value="3" />
                            <asp:ListItem Text="Ovo" Value="4" />
                        </asp:DropDownList>
                    </div>
                    <asp:Button runat="server" ID="payButton" Text="Pay" OnClick="payButton_Click" CssClass="btn btn-primary mt-3" />
                </div>
                </div>
            </div>
        <% } %>
    </div>
</asp:Content>
