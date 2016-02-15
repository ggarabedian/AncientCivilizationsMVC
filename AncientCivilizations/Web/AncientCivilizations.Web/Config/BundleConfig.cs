namespace AncientCivilizations.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            RegisterScriptBundles(bundles);
            RegisterStyleBundles(bundles);

            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/kendo")
                        .Include("~/Content/Kendo/kendo.common-bootstrap.min.css", "~/Content/Kendo/kendo.silver.min.css"));

            bundles.Add(new StyleBundle("~/Content/css")
                        .Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/custom")
                        .Include("~/Content/site.css"));
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/kendo")
                        .Include("~/Scripts/Kendo/kendo.all.min.js",
                                 "~/Scripts/Kendo/kendo.aspnetmvc.min.js",
                                 "~/Scripts/Custom/kendo-form-validator.js",
                                 "~/Scripts/Custom/kendo-grid-rebind.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                        .Include("~/Scripts/Kendo/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                        .Include("~/Scripts/jquery.validate*", "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrusiveajax")
                        .Include("~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                        .Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));
        }
    }
}
