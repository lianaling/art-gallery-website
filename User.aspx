﻿<%@ Page Title="User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs"
    Inherits="ArtGalleryWebsite.User" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div id="app">
        </div>

        <script src="Scripts/dist/UserPage.dist.js"></script>

        <!-- Profile Header -->
        <div class="rounded-full justify-items-center mt-10">
            <a href="/">
            <img
            class="rounded-full h-[130px] w-[130px] mx-auto block"
            src="https://lumiere-a.akamaihd.net/v1/images/character_princess_jasmine_7da1e27a.jpeg?region=0%2C0%2C450%2C450"
            alt="Jasmine profile picture"
            />
            </a>
        </div>
        <br />
        <h1 class="text-center text-4xl font-bold font-garamond">Liana Ling</h1>
        <h2 class="text-center text-lg text-gray-500 font-bold font-garamond">
            @lianalingliya
        </h2>
        <h2 class="text-center text-lg text-gray-500 font-bold font-garamond">
            0 following
        </h2>

        <!-- Icons -->
        <div class="w-full">
            <div class="m-3 inline">
                <a href="/">
                <img class="bg-transparent hover:bg-light-hover inline" src="https://img.icons8.com/material-sharp/24/000000/pencil--v2.png" alt="Edit icon"
                />
                </a>
            </div>
            <div class="m-3 inline">
                <a href="/">
                <img class="bg-transparent hover:bg-light-hover inline" src="https://img.icons8.com/material-rounded/24/000000/share.png" alt="Edit icon"
                />
                </a>
            </div>

            <div class="m-3 inline float-right">
                <a href="/">
                <img class="bg-transparent hover:bg-light-hover inline float-right" src="https://img.icons8.com/material-outlined/24/000000/settings--v1.png" alt="Settings icon"
                />
                </a>
            </div>

            <div class="m-3 inline float-right">
                <a href="/">
                <img class="bg-transparent hover:bg-light-hover inline float-right" src="https://img.icons8.com/material-rounded/24/000000/add.png" alt="Add icon"
                />
                </a>
            </div>
        </div>

        <!-- My saves -->
        <div class="border-b-2 w-full">
            <div class="m-14 mr-0 grid grid-cols-2 gap-[1px] w-[22.1rem]">
                <div class="inline">
                    <a href="/">
                    <img class="inline h-[161px] w-[11rem] object-cover rounded-l-2xl" src="https://i.pinimg.com/originals/da/68/e7/da68e7f731bfd78e20dba0ead711ca99.jpg" alt="The Weasleys" />
                    </a>
                </div>

                <div class="inline grid grid-rows-2 gap-[1px] h-[10rem]">
                    <a href="/">
                    <img class="inline h-[5rem] w-[5rem] object-cover rounded-tr-2xl" src="https://i.pinimg.com/originals/da/68/e7/da68e7f731bfd78e20dba0ead711ca99.jpg" alt="The Weasleys" />
                    </a>
                    <a href="/">
                    <img class="inline h-[5rem] w-[5rem] object-cover rounded-br-2xl" src="https://i.pinimg.com/originals/da/68/e7/da68e7f731bfd78e20dba0ead711ca99.jpg" alt="The Weasleys" />
                    </a>
                </div>
            </div>
            <div class="m-14 font-garamond">
                <strong class="text-xl">My saves</strong>
                <br/>
                <h3 class="inline">12 Arts</h3>
                <h4 class="inline text-sm text-gray-500 font-bold">9d</h4>
            </div>
        </div>

        <!-- Unorganised Saves -->
        <div class="m-14 font-garamond">
            <strong class="text-xl inline">Unorganised Saves</strong>

            <a class="px-3 py-2 font-bold bg-light hover:bg-light-hover rounded-full inline float-right" href="/">Organise</a>
        </div>



            <div id="reference">
                <a href="https://icons8.com/icon/89821/pencil">Pencil icon by Icons8</a> <br />
                <a href="https://icons8.com/icon/83213/share">Share icon by Icons8</a> <br />
                <a href="https://icons8.com/icon/82535/settings">Settings icon by Icons8</a> <br />
                <a href="https://icons8.com/icon/85096/add">Add icon by Icons8</a> <br />
            </div>
    </asp:Content>