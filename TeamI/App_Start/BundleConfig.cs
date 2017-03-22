using System.Web;
using System.Web.Optimization;

namespace TeamI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/navigation").Include(
                      "~/Scripts/navigation.js"));

            bundles.Add(new ScriptBundle("~/bundles/sorttable").Include(
                     "~/Scripts/sorttable.js"));

            bundles.Add(new ScriptBundle("~/bundles/stats").Include(
                     "~/Scripts/circleStats/jquery.circliful.js"));

            bundles.Add(new ScriptBundle("~/bundles/modal").Include(
                      "~/Scripts/Modal.js"));

            bundles.Add(new ScriptBundle("~/bundles/fontsize").Include(
                      "~/Scripts/FontSize.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
              "~/Scripts/knockout-{version}.js",
              "~/Scripts/app.js"));

        bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Normalize.css",
                      "~/Content/site.css",
                      "~/Content/navigation.css",
                      "~/Content/Custom.css",
                      "~/Content/TabView.css",
                      "~/Content/Modal.css",
                      "~/Content/PassFailBtn.css",
                      "~/Content/FontSizeChange.css",
                      "~/Content/circleStats/jquery.circliful.css",
                      "~/Content/circleStats/material-design-iconic-font.css",
                      "~/Content/circleStats/material-design-iconic-font.min.css"));
        }
    }
}
