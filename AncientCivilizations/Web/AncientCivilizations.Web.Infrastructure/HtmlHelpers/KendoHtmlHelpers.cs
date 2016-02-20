namespace AncientCivilizations.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Web.Mvc;

    using Common.GlobalConstants;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHtmlHelpers
    {
        public static GridBuilder<T> CustomGrid<T>(
            this HtmlHelper helper,
            string name,
            string controllerName,
            bool canCreate,
            Action<DataSourceModelDescriptorFactory<T>> factory,
            bool rebindOnEdit = false)
           where T : class
        {
            return helper.Kendo().Grid<T>()
                .Name(name)
                .Pageable(p => p.Refresh(true))
                .Sortable()
                .Filterable()
                .ColumnMenu()
                .ToolBar(toolbar => 
                {
                    if (canCreate)
                    {
                        toolbar.Create();
                    }
                })
                .Editable(edit => edit.Mode(GridEditMode.PopUp))
                .DataSource(dataSource => dataSource
                    .Ajax()
                    .PageSize(10)
                    .Model(factory)
                    .Read(read => read.Action(Actions.Read, controllerName))
                    .Create(create => create.Action(Actions.Create, controllerName))
                    .Update(update => update.Action(Actions.Update, controllerName))
                    .Destroy(destroy => destroy.Action(Actions.Destroy, controllerName))
                    .Events(events => 
                    {
                        if (rebindOnEdit)
                        {
                            events.RequestEnd("rebindOnEdit");
                        }
                    }));
        }
    }
}
