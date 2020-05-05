using System.Web;
using System.Web.Optimization;

namespace AttendanceManagementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.min.js"));

            // Jquery validator & unobstrusive ajax  
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive-ajax.js", "~/Scripts/jquery.unobtrusive-ajax.min.js", "~/Scripts/jquery.validate*", "~/Scripts/jquery.validate.unobtrusive.js", "~/Scripts/jquery.validate.unobtrusive.min.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //Bootstrap Graph
            bundles.Add(new ScriptBundle("~/bundles/script/bootstrapgraph").Include(
                      "~/Scripts/script/mdb.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/script/jquerytimepicker").Include(
                      "~/Scripts/script/jquery.timepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
          "~/Scripts/sweetalert.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/script/accordion").Include(
                      "~/Scripts/script/accordion.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style/jquery.timepicker.css",
                      "~/Content/fontawesome-all.css",
                      "~/Content/style/style.css"));
        }
    }
}
