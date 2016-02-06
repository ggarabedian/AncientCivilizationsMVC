namespace AncientCivilizations.Web.Common.HtmlHelperExtensions
{
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHtmlHelpers
    {
        public static GridBuilder<T> CustomGrid<T>(this HtmlHelper helper, string name)
            where T : class
        {
            return helper.Kendo().Grid<T>()
                .Name(name)
                .Pageable(p => p.Refresh(true))
                .Sortable()
                .Filterable()
                .ColumnMenu();
        }
    }
}
