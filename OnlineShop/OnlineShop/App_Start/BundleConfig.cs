﻿using System.Web.Optimization;
namespace OnlineShop.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundleCollection)
        {
            bundleCollection.Add(new ScriptBundle("~/bundle/BasicScripts")
                .Include("~/Scripts/jquery-3.1.0.min.js", "~/Scripts/jquery.unobtrusive-ajax.min.js"
                ,"~/Scripts/jquery.form.min.js", "~/Scripts/jquery.validate.min.js"
                , "~/Scripts/jquery-ui-1.11.4.min.js", "~/Scripts/bootstrap.min.js"
                , "~/Scripts/modernizr-2.6.2.js", "~/Scripts/jquery.validate.unobtrusive.js"));
            bundleCollection.Add(new ScriptBundle("~/bundle/AddProductScripts")
             .Include("~/Scripts/formScript.js", "~/Scripts/FillSubCategory.js"
             , "~/Scripts/DiscriptionParameters.js", "~/Scripts/FileInputEventListener.js"));
            bundleCollection.Add(new StyleBundle("~/bundle/AddProductStyles")
         .Include("~/Content/ValidationStyle.css", "~/Content/DescriptionParameters.css"
         , "~/Content/AddProducts.css"));
        }
    }
}
