﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ArtGalleryWebsite
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            //Exception exc = Server.GetLastError();
            //Response.Clear();

            //HttpException httpException = exc as HttpException;

            //if (httpException != null)
            //{
            //    switch (httpException.GetHttpCode())
            //    {
            //        case 404:
            //            // Page not found
            //            Response.Redirect("Error_Pages/Oops.aspx");
            //            break;
            //        //case 500:
            //        //    RouteData.Values.Add("action", "HttpError500");
            //        //    break;
            //        //default:
            //        //    RouteData.Values.Add("action", "General");
            //        //    break;
            //    }
            //}
        }
    }
}