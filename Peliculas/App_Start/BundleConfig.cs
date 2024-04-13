using System.Web;
using System.Web.Optimization;

namespace Peliculas
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/chosen.jquery.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/index.global.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.*",
                        "~/Scripts/mvcfoolproof.unobtrusive.min.js",
                        "~/Scripts/jquery.validate.ar.js?v=1"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
          "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/slim").Include(
                      "~/Scripts/slim.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/popper.min.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/jquery-ui.min.css",
                      "~/Content/css/datepicker.css",
                      "~/Content/css/daterangepicker.css",
                      "~/Content/css/chosen.min.css",
                      "~/Content/css/all.min.css",
                      "~/Content/css/styles.css"));
        }
    }
}
