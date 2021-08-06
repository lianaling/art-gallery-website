﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArtGalleryWebsite.Models;
using ArtGalleryWebsite.Utils;

namespace ArtGalleryWebsite
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _BindData();
            }
        }

        private void _BindData()
        {
            try
            {
                List<Models.Entities.Art> arts = Database.Select<Models.Entities.Art>("SELECT * FROM Art;");

                if (arts.Count > 0 && arts != null)
                {
                    ArtsGrid.DataSource = arts;
                    ArtsGrid.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ArtsGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ArtsGrid.EditIndex = e.NewEditIndex;
                _BindData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ArtsGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string description = ((TextBox)ArtsGrid.Rows[e.RowIndex].FindControl("ArtDescriptionEdit")).Text;
                decimal price = Convert.ToDecimal(((TextBox)ArtsGrid.Rows[e.RowIndex].FindControl("ArtPriceEdit")).Text);
                int stock = Convert.ToInt32(((TextBox)ArtsGrid.Rows[e.RowIndex].FindControl("ArtStockEdit")).Text);
                string style = ((TextBox)ArtsGrid.Rows[e.RowIndex].FindControl("ArtStyleEdit")).Text;

                System.Diagnostics.Trace.WriteLine(description);
                System.Diagnostics.Trace.WriteLine(price);
                System.Diagnostics.Trace.WriteLine(stock);
                System.Diagnostics.Trace.WriteLine(style);

                ArtsGrid.EditIndex = -1;
                _BindData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ArtsGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ArtsGrid.EditIndex = -1;
            _BindData();
        }
    }
}