function onChange(arg) {
    var listview = $("#listView").data("kendoListView"),
        index = listview.select().index(),
        dataItem = listview.dataSource.view()[index];

    $("#window").data("kendoWindow").open().content("<div class='container'>" +
                                                        "<div class='row'>" +
                                                            "<div class='col-md-4'>" +
                                                                "<h4 class='row'>by " + dataItem.ContrubitorFullName + "</h4>" +
                                                                "<br />" +
                                                                "<p class='row'>" + dataItem.Description + "</p>" +
                                                            "</div>" +
                                                            "<div class='col-md-6'>" +
                                                                "<img width='400' height='400' src='/Content/Pictures/" + dataItem.Url + "'/>" +
                                                            "</div>" +
                                                        "</div>" +
                                                     "</div>");
}

function onClose() {
    $("#undo").show();
}

$(document).ready(function () {
    $("#window").data("kendoWindow").close();
    $("#undo").bind("click", function () {
        $("#window").data("kendoWindow").open();
        $("#undo").hide();
    });
});
