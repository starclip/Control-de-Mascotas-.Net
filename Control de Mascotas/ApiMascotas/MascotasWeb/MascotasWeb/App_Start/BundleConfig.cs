using System.Web;
using System.Web.Optimization;

namespace MascotasWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.4.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Base.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/plugin/css").Include(
                     "~/Content/datatable/css/jquery.dataTables.min.css",
                     "~/Content/datatable/css/responsive.dataTables.min.css",
                     "~/Content/fontawesome-free/css/all.css",
                     "~/Content/datatable/css/dataTables.dateTime.min.css",
                     "~/Content/jQuery-ui/jquery-ui.min.css",
                     "~/Content/jQuery-ui/jquery-ui.structure.min.css",
                     "~/Content/jQuery-ui/jquery-ui.theme.min.css",
                     "~/Content/datatable/css/select.dataTables.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/plugin/js").Include(
                      "~/Content/datatable/idioma/datatableIdioma.js",
                      "~/Content/datatable/js/jquery.dataTables.min.js",
                      "~/Content/datatable/js/dataTables.responsive.min.js",
                      "~/Content/datatable/js/dataTables.dateTime.min.js",
                      "~/Content/datatable/js/select.dataTables.min.js",
                      "~/Content/datatable/js/dataTables.select.min.js",
                      "~/Content/fontawesome-free/js/all.js",
                      "~/Content/sweetAlert/sweetAlert.js",
                      "~/Content/jQuery-ui/jquery-ui.min.js",
                      "~/Content/jQuery-ui/bootstrap-datepicker.es.js",
                      "~/Content/jQuery-Mask-Plugin-master/src/jquery.mask.js"));
        }
    }
}
