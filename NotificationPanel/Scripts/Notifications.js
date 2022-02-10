$(document).ready(function () {

        

        $("#tableMain").DataTable();

        //$("#tableMain").css("border", "none");
        $("#tablediv a").css({
            "background-color": '#7e3af2',
            'border' : 'none',
            'color': 'white',
            'font-size': '15px',

        })
        $("#tableMain_info").css
            ({
                "color": "#707275", "text-transform": "uppercase", 'letter- spacing':
                    '.025em', 'font-size': '.75rem',
                'font-weight':
                    '600'
            });
        //$("#tablediv a#tableMain_previous").text("<");

        //$("#tablediv a#tableMain_next").text(">");

        $("Tbody Tr").hover(function () {
            $(this).css({
                "box-shadow": " 0 0 7px #7e3af2", "border-color": "#9ecaed", "cursor": "pointer"
            })

        }, function () {
            $(this).css({
                "box-shadow": "0 0 0 0 ", "border-color": ""
            })
        });

        $('Tbody Tr').click(function () {
            var Id = $(this).data("id");
            $.ajax({

                    type: "POST",

                    url: '/Notifications/Read',

                    dataType: "json",

                    data: JSON.stringify({ Id }),

                    contentType: "application/json; charset=utf-8",

                    dataType: "json",

                    success: function (data) {

                        console.log(data);

                    }

            });

            window.open(`/Notifications/View/${Id}`, "_self")


        });




    });