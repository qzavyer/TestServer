if (IndexScript === undefined) {
    var IndexScript = (function () {
        $(document).ready(function () {
            // поле ввода даты (jquery-ui)
            $("#date").datepicker({
                dateFormat: "dd.mm.yy"
            });
            $("#date").datepicker("setDate", new Date());
            // окно добавления фильма (jquery-ui)
            $("#addWindow").dialog({
                autoOpen: false,
                width: 500,
                close: function() {
                    $("#name").val("");
                    $("#date").datepicker("setDate", new Date());
                }
            });

        });
        // показ соощения об ошибке
        function showResult(text, color) {
            "use strict";
            var args = arguments.length;
            if (args === 0) {
                return;
            }
            var div = $("#actionResultDiv");
            var lbl = $("#actionResult");
            lbl.text(text);
            if (args > 1) {
                lbl.css("color", color);
            }
            var top = ($(window).height() - div.height()) / 2;
            var left = ($(window).width() - div.width()) / 2;
            div.css({ top: top, left: left });
            div.show();
            var timer = setTimeout(function () {
                lbl.css("color", "#ff0000");
                lbl.text("");
                div.hide();
                clearTimeout(timer);
            }, 2000);
        }
        return {
            // клик по кнопке Добавить
            addClick: function () {
                $("#addWindow").dialog("open");
            },

            // клик по кнопке Добавить
            removeClick: function (id) {
                if(confirm("Удалить фильм?"))
                $.ajax({
                    url: "/Home/RemoveMovie",
                    type: "POST",
                    dataType: "json",
                    data: {
                        id: id
                    },
                    success: function (jdata) {
                        if (jdata.result === 0) {
                            location.reload();
                        } else {
                            showResult(jdata.msg);
                        }
                    }
                });
            },
            // клик по кнопке Отмена
            cancelClick: function() {
                $("#name").val("");
                $("#addWindow").dialog("close");
            },
            // клик по кнопке Сохранить
            saveClick:function() {
                $.ajax({
                    url: "/Home/AddMovie",
                    type: "POST",
                    dataType:"json",
                    data: {
                        date: $("#date").val(),
                        name: $("#name").val()
                    },
                    success:function(jdata) {
                        if (jdata.result === 0) {
                            location.reload();
                        } else {
                            showResult(jdata.msg);
                        }
                    }
                });
            }
    };
    })();
}