﻿using System;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using ArtGalleryWebsite.Utils;
using ArtGalleryWebsite.Models.Queries;
using System.Collections.Generic;
using ArtGalleryWebsite.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace ArtGalleryWebsite
{
    public partial class Cart : System.Web.UI.Page
    {
        protected List<ArtQuery> Arts = new List<ArtQuery> { };
        protected int[] array = { 1, 2, 3, 4, 5 };
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get current session user
            ApplicationUserManager manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindById(Page.User.Identity.GetUserId<int>());

            // Get data for the page
            List<ArtQuery> data = selectAllArt();

            // Register hidden field to pass data from backend to frontend
            //registerHiddenField("arts", data);

            // Update variable
            Arts = data;

            // Calculate
            decimal subtotal = calculateSubtotal();
            decimal shipping = 20;
            decimal total = calculateTotal(subtotal, shipping);

            // Set labels
            setLblSubtotal(subtotal);
            setLblShipping(shipping);
            setTotal(total);
        }

        private void registerHiddenField(string id, object obj)
        {
            Page.ClientScript.RegisterHiddenField(id, JsonConvert.SerializeObject(obj));
        }

        // Fetch all [Art]s in the database
        private List<ArtQuery> selectAllArt()
        {
            ArtQuery.FetchAllArt();
            return Database.Select<ArtQuery>(ArtQuery.SqlQuery);
        }

        private decimal calculateSubtotal()
        {
            decimal subtotal = 0;
            foreach (ArtQuery art in Arts)
            {
                subtotal += art.price;
            }

            return subtotal;
        }
        
        private decimal calculateTotal(decimal subtotal, decimal shipping)
        {
            return subtotal + shipping;
        }

        private void setLblSubtotal(decimal subtotal)
        {
            lblSubtotal.Text = decimal.Round(subtotal, 2) + "";
        }
        
        private void setLblShipping(decimal shipping)
        {
            string str = (decimal.Round(shipping, 2) + "");
            if (!str.Contains("."))
            {
                str += ".00";
            }
            lblShipping.Text = str;
        }
        
        private void setTotal(decimal total)
        {
            lblTotal.Text = decimal.Round(total, 2) + "";
        }

        protected void btnShowItems_click(object sender, EventArgs e)
        {
            ItemsList.Visible = !ItemsList.Visible;
        }

        protected void btnShowShipBill_click(object sender, EventArgs e)
        {
            ShipBill.Visible = !ShipBill.Visible;
        }

        protected void btnPayWith_click(object sender, EventArgs e)
        {
            string alertContent = "Paid with ";
            if (rdbtnCard.Checked)
            {
                // Do something
                alertContent += "card";
            } else if (rdbtnTng.Checked) {
                alertContent += "Touch and Go";
            } else if (rdbtnGrab.Checked) {
                alertContent += "Grab Pay";
            } else if (rdbtnFpx.Checked) {
                alertContent += "FPX";
            } else
            {
                alertContent = "Please select a payment method";
            }

            System.Diagnostics.Trace.WriteLine(alertContent);
        }

        protected void btnSubmitShipBill_click(object sender, EventArgs e)
        {

        }
    }
}