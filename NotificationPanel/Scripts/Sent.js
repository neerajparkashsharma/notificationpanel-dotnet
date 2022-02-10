

    $(document).ready(function () {


        $("#tableMain").DataTable();

    $("#tablediv a").css({
        "background-color": '#7e3af2',
    'border': 'none',
    'color': 'white',
    'font-size': '15px',

        })

        $("#tableBody Tr").hover(function () {
        $(this).css({
            "box-shadow": " 0 0 7px #7e3af2", "border-color": "#9ecaed", "cursor": "pointer"
        })

    }, function () {
        $(this).css({
            "box-shadow": "0 0 0 0 ", "border-color": ""
        })
    });
        $('#tableBody tr').click(function () {
            var Id = $(this).data("id");
    window.open(`/Notifications/View/${Id}`, "_self")
        });

    });

