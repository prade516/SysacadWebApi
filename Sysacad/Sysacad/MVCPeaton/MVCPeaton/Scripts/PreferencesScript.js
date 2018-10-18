$(document).ready(function ()
{
    //Buttons
    $("#btnConfirm").on("mouseup", function (e) {
        UnCheckAll();
        OcultarModal();
    });
    $("#btnCancel").on("mouseup", function (e) {
        OcultarModal();
    });
    $("#btnBorrarIntereses").on("click", function (e) {
        $('input[type=checkbox]:checked').each(
        function () {
            document.getElementById('confirmReset').style.display = 'block';
            document.getElementById('fade').style.display = 'block';
            return;
        });
    });
    $("#btnCerrarConfirm").on("click", function (e) {
        document.getElementById('confirmReset').style.display = 'none';
        document.getElementById('fade').style.display = 'none';
    });
    $("#btnVerTodas").on("click", function (e) {
        document.getElementById('light').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
    });
    $("#btnCerrar").on("click", function (e) {
        OcultarModal();
    });
    $("#fade").on("click", function (e) {
        OcultarModal();
    });
    //Modal
    $(document).on("keyup", function (event) {
        if (event.which == 27) {
            OcultarModal();
        }
    });
    function OcultarModal() {
        if ($("#tagfilter").val() != "") {
            $("#tagfilter").val("");
            FiltrarTags();
        }
        document.getElementById('light').style.display = 'none';
        document.getElementById('fade').style.display = 'none';
        var x = document.getElementById('confirmReset');
        if (x != undefined) {
            x.style.display = 'none';
        }
    };

    //Reset preferences
    function UnCheckAll()
    {
        $('input[type=checkbox]:checked').each(
        function ()
        {
            $(this)[0].valueOf().checked = false;
        });
        var tags = document.getElementsByName('selectedtag');
        for (var x = 0; x < tags.length; x++) {
                tags[x].style.display = 'none';
        }
        var tagsmodal = document.getElementsByName('selectedtagmodal');
        for (var x = 0; x < tagsmodal.length; x++) {
            tagsmodal[x].style.display = 'none';
        }
        
    };
    
    //Filters functions
    function FiltratSelectedTags() {
        var tabla = $("#selectedtagscontent");
        var tags = document.getElementsByName('selectedtag');
        for (var x = 0; x < tags.length; x++) {
            var etiqueta = tags[x].innerText.toLocaleLowerCase();
            if (etiqueta.indexOf($("#selectedtagsfilter").val().toLocaleLowerCase()) != -1)
                tags[x].style.display = '';
            else
                tags[x].style.display = 'none';
        };
    };
    function FiltrarTags() {
        var tabla = $("#alltagscontent");
        var tags = document.getElementsByName('tag');

        for (var x = 0; x < tags.length; x++) {
            var etiqueta = tags[x].innerText.toLocaleLowerCase();
            if (etiqueta.indexOf($("#tagfilter").val().toLocaleLowerCase()) != -1)
                tags[x].style.display = '';
            else
                tags[x].style.display = 'none';
        };
    };
    function FiltrarBanks() {
        var tabla = $("#allbankscontent");
        var banks = document.getElementsByName('bank');

        for (var x = 0; x < banks.length; x++) {
            var etiqueta = banks[x].innerText.toLocaleLowerCase();
            if (etiqueta.indexOf($("#bankfilter").val().toLocaleLowerCase()) != -1)
                banks[x].style.display = '';
            else
                banks[x].style.display = 'none';
        };
    };
    function FiltrarItems() {
        var tabla = $("#allitemscontent");
        var items = document.getElementsByName('item');

        for (var x = 0; x < items.length; x++) {
            var etiqueta = items[x].innerText.toLocaleLowerCase();
            if (etiqueta.indexOf($("#itemfilter").val().toLocaleLowerCase()) != -1)
                items[x].style.display = '';
            else
                items[x].style.display = 'none';
        };
    };
    //Filters events
    $("#tagfilter").on("keyup", function (e) {
        FiltrarTags();
    });
    $("#bankfilter").on("keyup", function (e) {
        FiltrarBanks();
    });
    $("#itemfilter").on("keyup", function (e) {
        FiltrarItems();
    });
    $("#selectedtagsfilter").on("keyup", function (e) {
        FiltratSelectedTags();
    });
    //Filters resets
    $("#tagreset").on("click", function (e) {
        $("#tagfilter").val("");
        FiltrarTags();
    });
    $("#bankreset").on("click", function (e) {
        $("#bankfilter").val("");
        FiltrarBanks();
    });
    $("#itemreset").on("click", function (e) {
        $("#itemfilter").val("");
        FiltrarItems();
    });
    $("#selectedtagsreset").on("click", function (e) {
        $("#selectedtagsfilter").val("");
        FiltratSelectedTags();
    });

    //Function responsible of checkboxes management
    $('input[type=checkbox]').on("mouseup", function (e) {
        var x = this;
        if (x.valueOf().checked == true) {
            debugger;
            var x = document.getElementsByName(this.name);
            for (var p = 0; p < x.length; p++) {
                if (x[p] !== this && x[p].parentElement.parentElement.parentElement.id != "alltagscontent"
                    && x[p].parentElement.parentElement.parentElement.id != "allbankscontent"
                    && x[p].parentElement.parentElement.parentElement.id != "allitemscontent") {
                    x[p].valueOf().checked = false;
                    x[p].parentElement.parentElement.parentElement.style.display = 'none';
                    x[p].parentElement.parentElement.parentElement.hidden = true;
                    x[p].checked = false;
                }
            }
        }
        else {
            var x = document.getElementsByName(this.name);
            for (var p = 0; p < x.length; p++) {
                if (x[p] !== this && x[p].parentElement.parentElement.parentElement.id != "alltagscontent"
                    && x[p].parentElement.parentElement.parentElement.id != "allbankscontent"
                    && x[p].parentElement.parentElement.parentElement.id != "allitemscontent") {
                    x[p].valueOf().checked = true;
                    //x[p].parentElement.parentElement.style.display = '';
                    x[p].parentElement.parentElement.parentElement.style.display = '';
                    x[p].parentElement.parentElement.parentElement.hidden = false;
                    x[p].checked = true;
                }
            }
        }
    });
})