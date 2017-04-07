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


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/CircleStats").Include(
                 "~/Scripts/circleStats/jquery.circliful.js",
                 "~/Scripts/circleStats/jquery.circliful.min.js",
                "~/Scripts/circleStats/CircleStats.js"));

            bundles.Add(new ScriptBundle("~/bundles/SiteTour").Include(
                  "~/Scripts/SiteTour/bootstrap-tour.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/navigation").Include(
                      "~/Scripts/navigation.js"));

            bundles.Add(new ScriptBundle("~/bundles/modal").Include(
                      "~/Scripts/Modal.js"));

            bundles.Add(new ScriptBundle("~/bundles/fontsize").Include(
                      "~/Scripts/FontSize.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
              "~/Scripts/knockout-{version}.js",
              "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/tabSaveState").Include(
                     "~/Scripts/tabsSaveState.js"));





            bundles.Add(new StyleBundle("~/style/CircleStats").Include(
              "~/Content/circleStats/jquery.circliful.css",
              "~/Content/circleStats/material-design-iconic-font.css",
              "~/Content/circleStats/material-design-iconic-font.min.css"));

            bundles.Add(new StyleBundle("~/style/SiteTour").Include(
                   "~/Content/SiteTour/bootstrap-tour.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/bootstrap.css",
                   "~/Content/Normalize.css",
                   "~/Content/site.css",
                   "~/Content/navigation.css",
                   "~/Content/Custom.css",
                   "~/Content/Modal.css",
                   "~/Content/PassFailBtn.css",
                   "~/Content/FontSizeChange.css"
                  ));

        }
    }
}
