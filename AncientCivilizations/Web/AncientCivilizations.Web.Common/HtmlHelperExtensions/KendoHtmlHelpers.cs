namespace AncientCivilizations.Web.Common.HtmlHelperExtensions
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHtmlHelpers
    {
        public static GridBuilder<T> CustomGrid<T>(this HtmlHelper helper, string controllerName, Expression<Func<T, object>> modelIdExpression)
            where T : class
        {
            return helper.Kendo().Grid<T>()
                .Name("grid")
                .Pageable(p => p.Refresh(true))
                .Sortable()
                .Filterable()
                .ColumnMenu()
                .DataSource(data => data.Ajax()
                                        .Model(m => m.Id(modelIdExpression))
                                        .Read(read => read.Action("Read", controllerName))
                                        .Create(create => create.Action("Create", controllerName))
                                        .Update(update => update.Action("Update", controllerName))
                                        .Destroy(destroy => destroy.Action("Destroy", controllerName))
                                        );
        }
    }
}
