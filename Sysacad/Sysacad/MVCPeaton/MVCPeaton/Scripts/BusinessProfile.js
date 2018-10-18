$('#checkBox1').change(function () {
    $("#textBox1").prop("disabled", !$(this).is(':checked'));
});
$('#checkBox2').change(function () {
    $("#textBox2").prop("disabled", !$(this).is(':checked'));
});
$('#checkBox3').change(function () {
    $("#textBox3").prop("disabled", !$(this).is(':checked'));
});
$('#checkBox4').change(function () {
    $("#textBox4").prop("disabled", !$(this).is(':checked'));
});
$('#checkBox5').change(function () {
    $("#textBox5").prop("disabled", !$(this).is(':checked'));
});

var array = [];
var cont = 0;
var btn = document.getElementById("bntModal");
$("#buttonAgregar").on("click", agregar);
var i;
var verify = false;
var idmodify;
function agregar()
{
    if (verify == false)
    {
        for (var i = 0; i < 3; i++)
        {
            if (array[i] != null)
            {
                verify = false;
            }
            else
            {
                cont = i;
                verify = true;                
                agregar();
                verify = false;
                break;
            }
        }
    }
    if (verify) {
        var txt = $("<label id='label" + cont + "'>Otro</label>");
        var txt2 = $("<input type='Text' id='valor" + cont + "' readonly='readonly'> ");
        var txt3 = $("<input type='button' id='btnEliminar" + cont + "' value='Eliminar'>");
        var txt4 = $("<input type='button' id='btnModificar" + cont + "' value='Modificar'> <br/>");

        var nombre = $("#textNombre").val("Otro");
        var link = $("#textLink").val();
        $("#label").val(nombre);

        $("#input").append(txt, txt2, txt3,txt4);

        //Moificar
        var modificar = document.getElementById("btnModificar" + cont);
        modificar.addEventListener("click", modifyBtn, false);

        //Eliminar
        var eliminar = document.getElementById("btnEliminar" + cont);
        eliminar.addEventListener("click", removeBtn, false);

        array[cont] = eliminar;
        console.log(array);
      
        $("#valor" + cont + "").val(link);

        //Con este codigo pasamos los datos al controlador para agregar
        var j = cont + 6;
        $("#Link" + j + "").val(link);

        $("#textNombre").val("");
        $("#textLink").val("")
        cont++;

        var bool = false;
        for (var i = 0; i < 3; i++)
        {
            if (array[i] != null)
            {
                bool = true;
            }
            else
            {
                bool = false;
                return;
            }
        }
        console.log(bool);
        if (bool) { btn.setAttribute("style", "display:none"); };
    }
}
var contador;
function modifyBtn()
{  

    $('#myModalModify').modal('show');
    var idmod = this.getAttribute("id");
    idmodify = idmod.substr(idmod.length - 1);
    contador = (parseInt(idmodify) + 6);
    var m = $("#label" + idmodify + "").val();
    var n = $("#valor" + idmodify + "").val();

    $("#textNombreModify").val(m);
    $("#textLinkModify").val(n);

    $("#buttonModify").on("click", function () {       

        var modi = $("#textLinkModify").val();
        $("#valor" + idmodify + "").val(modi);
        $("#Link" + contador + "").val(modi);
    })
}
debugger;
function removeBtn()
{
    var id = this.getAttribute("id");
    var number = id.substr(id.length - 1);
    var toDelete1 = "label" + number;
    var toDelete2 = "valor" + number;
    var toDelete3 = "btnModificar" + number;
    var nodeToDelete1 = $("#" + toDelete1);
    var nodeToDelete2 = $("#" + toDelete2);
    var nodeToDelete3 = $("#" + toDelete3);
    nodeToDelete1.remove();
    nodeToDelete2.remove();
    nodeToDelete3.remove();
    this.remove();
    
    array[number] = null;
    cont = number;
    btn.setAttribute("style", "display:block");

    //Con este codigo pasamos los datos al controlador para eliminar...VER!
    var j = cont + 6;
    $("#Link" + j + "").val(link);
}


//Cargar foto de Portada
if ($("#mode").val() == "Update") {
    var idElement = document.getElementById("idScript");
    var photoElement = document.getElementById("photoScript");
    id = idElement.value;
    profilephoto = photoElement.value;
    {
        var qualiter = {
            Fitmode: 2,
            Height: 150,
            Widht: 150,
            Quality: 100
        };

        var requestData = {
            localFilePath: JSON.parse(JSON.stringify(profilephoto).replace(/\\""/g, '')),
            qual: qualiter
        };

        $.ajax({
            type: "POST",
            url: '/File/DownloadPublicPhoto',
            data: JSON.stringify(requestData),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                $("#Photo").attr("src", 'data:image/png;base64,' + response.Result);
            },
            error: function (error) {
                alert("error");
            }
        });

        function base64encode(binary) {
            return btoa(unescape(encodeURIComponent(binary)));
        }
    };
}


