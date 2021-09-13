﻿<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs"
    Inherits="ArtGalleryWebsite.Cart" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <%-- Hidden buttons to receive and process simulated clicks from frontend --%>

        <%-- Frontend code --%>
        <div id="app" class="hidden">
        </div>

        <%--  --%>
  <div class="flex font-garamond lg:mx-[350px] lg:my-[30px]">
    <!-- Cart -->
    <div class="lg:w-3/5">
      <div class="px-5">
        <div class="py-5">
          <p class="font-bold text-4xl">Your Cart</p>
        </div>
        <!-- Item Header -->
          <asp:Button
            ID="hdrItems"
            OnClick="btnShowItems_click"
            runat="server"
            CssClass="
              px-5
              py-2
              bg-accent
              text-white
              rounded-full
              flex
              w-full
              hover:bg-accent-hover
              text-2xl
              font-bold
            "
            Text="Items"
          />
          <!-- <div class="
              w-0
              h-0
              border-l-[5px]
              border-r-[5px]
              border-t-[10px]
              border-r-transparent
              border-l-transparent
              border-t-red" /> -->
        <!-- Item Detail -->
        <asp:Panel runat="server" ID="ItemsList">
          <% foreach (var art in Arts) { %>
            <div class="py-5 flex w-full mt-2">
              <!-- Image -->
              <div class="w-[8.5em] mr-5">
                <img
                  class="object-cover w-[8.5em] h-[8.5em] rounded-3xl"
                  src="<%= art.url %>"
                  alt="<%= art.description %>"
                />
              </div>
              <!-- Description -->
              <div class="flex flex-col w-[75%]">
                <p class="font-bold text-xl"><%= art.description %></p>
                <p>By <%= art.author.name %></p>
                <p class="mt-auto ml-auto">RM <%= art.price %></p>
              </div>
            </div>
          <% } %>
        </asp:Panel>
        <!-- Shipping and Billing -->
        <asp:Button
          ID="hdrShipBill"
          OnClick="btnShowShipBill_click"
          runat="server"
          CssClass="
            text-2xl
            font-bold
            px-5
            py-2
            bg-accent
            text-white
            rounded-full
            flex
            w-full
            my-5
            hover:bg-accent-hover
          "
          Text="Shipping and Billing"
          />
        <asp:Panel runat="server" ID="ShipBill" CssClass="px-5 text-xl">
          <!-- Shipping Address -->
          <div>
            <p class="font-bold">Shipping Address</p>
            <label for="txtFullName" class="p-2 block"> Full Name </label>
            <asp:TextBox
              runat="server"
              CssClass="form-input rounded-full block w-full"
              ID="txtFullName"
              placeholder="John M. Doe"
            />
            <label for="txtEmail" class="p-2 block"> Email</label>
            <asp:TextBox
              runat="server"
              CssClass="form-input rounded-full block w-full"
              ID="txtEmail"
              placeholder="john@example.com"
            />
            <label for="txtAdr" class="p-2 block"> Address</label>
            <asp:TextBox
              runat="server"
              CssClass="form-input rounded-full block w-full"
              ID="txtAdr"
              placeholder="542 W. 15th Street"
            />
            <label for="txtPhone" class="p-2 block">Phone</label>
            <asp:TextBox
              runat="server"
              CssClass="form-input rounded-full block w-full"
              id="txtPhone"
              placeholder="012-3456 789"
            />
          </div>
        </asp:Panel>
      </div>
    </div>
    <!-- Receipt -->
    <div class="px-5 w-auto lg:w-2/5 self-start sticky top-0">
      <p class="py-5 text-2xl font-bold">Order Summary</p>
      <div class="text-xl">
        <div class="flex">
          <p class="w-4/6">Subtotal</p>
          <!-- Testing -->
          <p class="w-1/6 text-gray-500">RM</p>
          <asp:Label runat="server" ID="lblSubtotal" class="w-1/6 text-right" Text="Subtotal"/>
        </div>
        <div class="flex">
          <p class="w-4/6">Shipping</p>
          <p class="w-1/6 text-gray-500">RM</p>
          <!-- Testing -->
          <asp:Label runat="server" ID="lblShipping" class="w-1/6 text-right" Text="Shipping"/>
        </div>
        <div class="my-5 border-t-2 border-b-2 border-gray-200 py-5 flex">
          <p class="w-4/6 font-bold">Order Total</p>
          <p class="w-1/6 text-gray-500">RM</p>
          <!-- Testing -->
          <asp:Label runat="server" ID="lblTotal" class="w-1/6 text-right" Text="Total"/>
        </div>
      </div>
      <!-- Payment -->
      <div class="text-xl">
        <p class="font-bold">Payment</p>
        <div class="py-5 border-b-2 border-gray-100">
          <asp:RadioButton
            runat="server"
            CssClass="form-radio text-accent mr-2"
            ID="rdbtnCard"
            value="card"
            GroupName="PayType"
          />
          <label for="rdbtnCard" class=""> Visa/Master/Amex </label><br/>
          <asp:RadioButton
            runat="server"
            CssClass="form-radio text-accent mr-2"
            ID="rdbtnTng"
            value="tng"
            GroupName="PayType"
          />
          <label for="rdbtnTng" class=""> Touch n' Go </label><br/>
          <asp:RadioButton
            runat="server"
            CssClass="form-radio text-accent mr-2"
            ID="rdbtnGrab"
            value="grab"
            GroupName="PayType"
          />
          <label for="rdbtnGrab" class=""> GrabPay </label><br/>
          <asp:RadioButton
            runat="server"
            CssClass="form-radio text-accent mr-2"
            ID="rdbtnFpx"
            value="fpx"
            GroupName="PayType"
          />
          <label for="rdbtnFpx" class=""> FPX </label><br/>
        </div>
        <!-- Pay Button -->
        <div class="py-5 flex justify-center">
          <asp:Button
            runat="server"
            ID="btnPayWith"
            OnCLick="btnPayWith_click"
            CssClass="
              bg-accent
              text-white
              px-5
              py-2
              rounded-full
              hover:bg-accent-hover
            "
            Text="Pay Using This Method"
          />
        </div>
      </div>
    </div>
  </div>

        <script src="Scripts/dist/CartPage.dist.js"></script>
    </asp:Content>
