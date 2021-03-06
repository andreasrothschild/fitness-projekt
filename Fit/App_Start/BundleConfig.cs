﻿using System.Web;
using System.Web.Optimization;

namespace Fit
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/Content").Include(
                      "~/Content/js/scrollReveal.js",
                      "~/Content/js/isotope.pkgd.min.js",
                      "~/Content/js/snap.svg-min.js",
                      "~/Content/js/classie.js",
                      "~/Content/js/main.js",
                      "~/Content/js/app.js",
                      "~/Content/js/directives/isotope.js"));

            bundles.Add(new StyleBundle("~/Content/").Include(
                      "~/Content/all.css"));

        }
    }
}
