var uri = $('#environmentPath').val() + 'Home/PullCryptoList';
var table = "";
$(function () {
    var tableId = 'tblcryptoListing';
    table = $('#' + tableId).DataTable({
        orderCellsTop: true,
        dom: 'Bfrtip',
        rowReorder: true,
        lengthChange: false,
        scrollX: true,
        order: [],
        paging: true,
        buttons: [],
        responsive: true,
        autoWidth: true,
        processing: true,
        serverSide: true,
        ajax: {
            "url": uri,
            type: 'POST'
        },
        columns: [
            { "data": "buy", className: 'text-center' },
            { "data": "spotRate", render: $.fn.dataTable.render.number(',', '.', 2), className: 'text-right'  },
            { "data": "changepercentage", render: $.fn.dataTable.render.number(',', '.', 2), className: 'text-right'  },
            { "data": "market", className: 'text-center'  },
            {
                "data": "timestamp", render: function (data) {
                    return moment(data).format('DD/MM/YYYY HH:MM:SS');
                }, className: 'text-center' 
            }
        ],
        destroy: true
    });

    setInterval(function () {
        refreshCryptoRate();
    }, 5000);
});

function refreshCryptoRate() {
    var refreshCryptoRateUri = $('#environmentPath').val() + 'CryptoAPI';
    $.get(refreshCryptoRateUri, function () { })
        .done(function () {
            table.ajax.reload(null, false);
        })
        .fail(function (error) {
            console.log("unable to retrieve.");
        })
}