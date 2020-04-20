var uri = $('#environmentPath').val() + 'Home/PullCryptoList';
$(function () {
    PullCryptoList();
    setInterval(function () {
        PullCryptoList();
    }, 5000);
});

function PullCryptoList() {
    $.get(uri, function (response) {
        $('#divCryptoList').html(response);
    })
        .done(function () {
            applyDataTable('tblcryptoListing');
        })
        .fail(function (error) {
            console.log("unable to retrieve.");
        })
}

function applyDataTable(tableId) {
    $('#' + tableId).DataTable({
        orderCellsTop: true,
        dom: 'Bfrtip',
        rowReorder: true,
        lengthChange: false,
        scrollX: true, order: [],
        paging: true,
        buttons: [],
        responsive: true,
        autoWidth: true,
    });
}