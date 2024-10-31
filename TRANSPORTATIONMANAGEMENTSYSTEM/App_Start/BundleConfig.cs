using System.Web;
using System.Web.Optimization;

namespace TRANSPORTATIONMANAGEMENTSYSTEM
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // jQuery bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // jQuery Validation bundle
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Modernizr bundle
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Bootstrap bundle
            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            // DataTables scripts
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/datatables/jquery.dataTables.js",
                        "~/Scripts/datatables/dataTables.bootstrap4.js")); // If using Bootstrap 4

            // Styles for DataTables
            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                        "~/Content/datatables/dataTables.bootstrap4.css")); // If using Bootstrap 4

            // Main CSS bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
