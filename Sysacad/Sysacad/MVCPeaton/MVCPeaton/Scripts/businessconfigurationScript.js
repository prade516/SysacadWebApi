$(document).ready(function () {
    //SetUp
    document.getElementById("createAcc").addEventListener("click", createAcc, false);
    document.getElementById("createBranch").addEventListener("click", createBranch, false);
    var view = document.getElementById("view");
    var divacc = document.getElementById("divacc");
    var divbranch = document.getElementById("divbranch");

    //Modal
    document.getElementById("saveChangeTags").addEventListener("click", saveChangeTags, false);
    var countTags = document.getElementById("countTags").value;
    var tagsCheck = [];
    for (var o = 0; o < countTags; o++)
    {
        tagsCheck[o] = document.getElementById("check_" + o);
    }

    //Get lists
    var countAcc = document.getElementById("countAcc");
    var countBranch = document.getElementById("countBranch");
    var i = 1;
    if (countAcc != null)
        i = (parseInt(countAcc.value) + 1);
    var j = 1;
    if (countBranch != null)
        j = (parseInt(countBranch.value) + 1);
    for (var k = 0; k < (i - 1); k++)
    {
        var idDeleteAcc = 'deleteAcc_' + k;
        var buttonDeleteAcc = document.getElementById(idDeleteAcc);
        buttonDeleteAcc.addEventListener("click", deleteCustomAcc, false);

        var idUnDeleteAcc = 'undeleteAcc_' + k;
        var buttonUnDeleteAcc = document.getElementById(idUnDeleteAcc);
        buttonUnDeleteAcc.addEventListener("click", unDeleteCustomAcc, false);
    }
    for (var l = 0; l < (j - 1); l++)
    {
        var idBranch = 'deleteBranch_' + l;
        var buttonBranch = document.getElementById(idBranch);
        buttonBranch.addEventListener("click", deleteCustomBranch, false);

        var idUnDeleteBranch = 'undeleteBranch_' + l;
        var buttonUnDeleteBranch = document.getElementById(idUnDeleteBranch);
        buttonUnDeleteBranch.addEventListener("click", unDeleteCustomBranch, false);
    }

    function createAcc()
    {
        if (i <= 5)
        {
            //Elements
            var label1Acc = document.createElement("label");
            label1Acc.setAttribute("for", "Cuenta_empleado_" + i + ":_");
            label1Acc.innerText = "Cuenta empleado: " + i;

            var labelUsername = document.createElement("label");
            labelUsername.className += "control-label col-md-2";
            labelUsername.setAttribute("for", "EmployeeAccounts_" + (i - 1) + "__username");
            labelUsername.innerText = "username"

            var labelPassword = document.createElement("label");
            labelPassword.className += "control-label col-md-2";
            labelPassword.setAttribute("for", "EmployeeAccounts_" + (i - 1) + "__password");
            labelPassword.innerText = "password"

            var labelConfirm = document.createElement("label");
            labelConfirm.className += "control-label col-md-2";
            labelConfirm.setAttribute("for", "EmployeeAccounts_" + (i - 1) + "__Confirm");
            labelConfirm.innerText = "confirm"

            var divToDeleteAcc = document.createElement("div");
            divToDeleteAcc.id = "divToDeleteAcc_" + (i - 1);
            divToDeleteAcc.setAttribute("style", "background:green");

            var div1Username = document.createElement("div");
            div1Username.className += "form-group";

            var div1Password = document.createElement("div");
            div1Password.className += "form-group";

            var div1Confirm = document.createElement("div");
            div1Confirm.className += "form-group";

            var div2Username = document.createElement("div");
            div2Username.className += "col-md-10";

            var div2Password = document.createElement("div");
            div2Password.className += "col-md-10";

            var div2Confirm = document.createElement("div");
            div2Confirm.className += "col-md-10";

            var inputIDAcc = document.createElement("input");
            inputIDAcc.setAttribute("data-val", "true");
            inputIDAcc.setAttribute("data-val-number", "The field idemployeeaccount must be a number.");
            inputIDAcc.setAttribute("data-val-required", "El campo idemployeeaccount es obligatorio.");
            inputIDAcc.setAttribute("id", "EmployeeAccounts_" + (i - 1) + "__idemployeeaccount");
            inputIDAcc.setAttribute("name", "EmployeeAccounts[" + (i - 1) + "].idemployeeaccount");
            inputIDAcc.setAttribute("type", "hidden");
            inputIDAcc.setAttribute("value", "0");

            var inputUsername = document.createElement("input");
            inputUsername.className += "form-control text-box single-line";
            inputUsername.setAttribute("data-val", "true");
            inputUsername.setAttribute("data-val-required", "Introduzca un usuario");
            inputUsername.id += "username" + (i - 1)
            inputUsername.name += "EmployeeAccounts[" + (i - 1) + "].username";
            inputUsername.type = "text";
            inputUsername.value = "";

            var inputPassword = document.createElement("input");
            inputPassword.className += "form-control text-box single-line password";
            inputPassword.setAttribute("data-val", "true");
            inputPassword.setAttribute("data-val-length", "Debe contener entre 6 a 20 caracteres");
            inputPassword.setAttribute("data-val-length-max", "20");
            inputPassword.setAttribute("data-val-length-min", "6");
            inputPassword.setAttribute("data-val-required", "Introduzca la contraseña");
            inputPassword.id += "password" + (i - 1)
            inputPassword.name += "EmployeeAccounts[" + (i - 1) + "].password";
            inputPassword.type = "password";
            inputPassword.value = "";

            var inputConfirm = document.createElement("input");
            inputConfirm.className += "form-control text-box single-line password";
            inputConfirm.setAttribute("data-val", "true");
            inputConfirm.setAttribute("data-val-equalto", "'confirm' y 'password' no coinciden.");
            inputConfirm.setAttribute("data-val-equalto-other", "*.password");
            inputConfirm.setAttribute("data-val-length", "Debe contener entre 6 a 20 caracteres");
            inputConfirm.setAttribute("data-val-length-max", "20");
            inputConfirm.setAttribute("data-val-length-min", "6");
            inputConfirm.setAttribute("data-val-required", "Vuelva a introducir la contraseña");
            inputConfirm.id += "confirm" + (i - 1);
            inputConfirm.name += "EmployeeAccounts[" + (i - 1) + "].confirm";
            inputConfirm.type = "password";
            inputConfirm.value = "";

            var inputStateAcc = document.createElement("input");
            inputStateAcc.setAttribute("class", "text-box single-line");
            inputStateAcc.setAttribute("data-val", "true");
            inputStateAcc.setAttribute("data-val-number", "The field state must be a number.");
            inputStateAcc.setAttribute("data-val-required", "El campo state es obligatorio.");
            inputStateAcc.setAttribute("hidden", "hidden");
            inputStateAcc.setAttribute("id", "stateAcc_" + (i - 1));
            inputStateAcc.setAttribute("name", "EmployeeAccounts[" + (i - 1) + "].state");
            inputStateAcc.setAttribute("type", "number");
            inputStateAcc.setAttribute("value", "1");

            var spanUsername = document.createElement("span");
            spanUsername.className += "field-validation-valid text-danger";
            spanUsername.setAttribute("data-valmsg-for", "EmployeeAccounts[" + (i - 1) + "].username");
            spanUsername.setAttribute("data-valmsg-replace", "true");

            var spanPassword = document.createElement("span");
            spanPassword.className += "field-validation-valid text-danger";
            spanPassword.setAttribute("data-valmsg-for", "EmployeeAccounts[" + (i - 1) + "].password");
            spanPassword.setAttribute("data-valmsg-replace", "true");

            var spanConfirm = document.createElement("span");
            spanConfirm.className += "field-validation-valid text-danger";
            spanConfirm.setAttribute("data-valmsg-for", "EmployeeAccounts[" + (i - 1) + "].confirm");
            spanConfirm.setAttribute("data-valmsg-replace", "true");

            //Appends
            divacc.appendChild(divToDeleteAcc);

            divToDeleteAcc.appendChild(inputIDAcc);

            divToDeleteAcc.appendChild(label1Acc);

            divToDeleteAcc.appendChild(div1Username);
            div1Username.appendChild(labelUsername);
            div1Username.appendChild(div2Username);
            div2Username.appendChild(inputUsername);
            div2Username.appendChild(spanUsername);

            divToDeleteAcc.appendChild(div1Password);
            div1Password.appendChild(labelPassword);
            div1Password.appendChild(div2Password);
            div2Password.appendChild(inputPassword);
            div2Password.appendChild(spanPassword);

            divToDeleteAcc.appendChild(div1Confirm);
            div1Confirm.appendChild(labelConfirm);
            div1Confirm.appendChild(div2Confirm);
            div2Confirm.appendChild(inputConfirm);
            div2Confirm.appendChild(spanConfirm);

            divToDeleteAcc.appendChild(inputStateAcc);

            //Button delete
            var divDeleteAcc1 = document.createElement("div");
            divDeleteAcc1.className += "form-group";

            var divDeleteAcc2 = document.createElement("div");
            divDeleteAcc2.className += "col-md-10";

            var inputAccDelete = document.createElement("input");
            inputAccDelete.type = "button";
            inputAccDelete.id = "deleteAcc_" + (i - 1);
            inputAccDelete.value = "Eliminar esta cuenta";

            var inputAccunDelete = document.createElement("input");
            inputAccunDelete.type = "button";
            inputAccunDelete.id = "undeleteAcc_" + (i - 1);
            inputAccunDelete.value = "Recuperar esta cuenta";
            inputAccunDelete.setAttribute("disabled", "disabled");
            inputAccunDelete.setAttribute("hidden", "hidden");

            divToDeleteAcc.appendChild(divDeleteAcc1);
            divDeleteAcc1.appendChild(divDeleteAcc2);
            divDeleteAcc2.appendChild(inputAccDelete);
            divDeleteAcc2.appendChild(inputAccunDelete);
            inputAccDelete.addEventListener("click", deleteCustomAcc, false);
            inputAccunDelete.addEventListener("click", unDeleteCustomAcc, false);

            //i
            i++;
        }
    }

    function createBranch()
    {
        if (j <= 15)
        {
            //Elements
            var label1Branch = document.createElement("label");
            label1Branch.setAttribute("for", "Sucursal_" + j + ":_");
            label1Branch.innerText = "Sucursal: " + j;

            var divToDeleteBranch = document.createElement("div");
            divToDeleteBranch.id = "divToDeleteBranch_" + (j - 1);
            divToDeleteBranch.setAttribute("style", "background:green");

            var div1Name = document.createElement("div");
            div1Name.className += "form-group";

            var div1Address = document.createElement("div");
            div1Address.className += "form-group";

            var div1AddressNumber = document.createElement("div");
            div1AddressNumber.className += "form-group";

            var labelName = document.createElement("label");
            labelName.className += "control-label col-md-2";
            labelName.setAttribute("for", "Branches_" + (j - 1) + "__name");
            labelName.innerText = "name"

            var labelAddress = document.createElement("label");
            labelAddress.className += "control-label col-md-2";
            labelAddress.setAttribute("for", "Branches_" + (j - 1) + "__address");
            labelAddress.innerText = "address"

            var labelAddressNumber = document.createElement("label");
            labelAddressNumber.className += "control-label col-md-2";
            labelAddressNumber.setAttribute("for", "Branches_" + (j - 1) + "__addressnumber");
            labelAddressNumber.innerText = "addressnumber"
            
            var div2Name = document.createElement("div");
            div2Name.className += "col-md-10";

            var div2Address = document.createElement("div");
            div2Address.className += "col-md-10";

            var div2AddressNumber = document.createElement("div");
            div2AddressNumber.className += "col-md-10";

            var inputIDBranch = document.createElement("input");
            inputIDBranch.setAttribute("data-val", "true");
            inputIDBranch.setAttribute("data-val-number", "The field idbranche must be a number.");
            inputIDBranch.setAttribute("data-val-required", "El campo idbranche es obligatorio.");
            inputIDBranch.setAttribute("id", "Branches_" + (j - 1) + "__idbranche");
            inputIDBranch.setAttribute("name", "Branches[" + (j - 1) + "].idbranche");
            inputIDBranch.setAttribute("type", "hidden");
            inputIDBranch.setAttribute("value", "0");

            var inputName = document.createElement("input");
            inputName.className += "form-control text-box single-line";
            inputName.id += "name" + (j - 1)
            inputName.name += "Branches[" + (j - 1) + "].name";
            inputName.type = "text";
            inputName.value = "";

            var inputAddress = document.createElement("input");
            inputAddress.className += "form-control text-box single-line";
            inputAddress.id += "address" + (j - 1)
            inputAddress.name += "Branches[" + (j - 1) + "].address";
            inputAddress.type = "text";
            inputAddress.value = "";

            var inputAddressNumber = document.createElement("input");
            inputAddressNumber.className += "form-control text-box single-line";
            inputAddressNumber.setAttribute("data-val", "true");
            inputAddressNumber.setAttribute("data-val-number", "The field addressnumber must be a number.");
            inputAddressNumber.setAttribute("data-val-required", "El campo addressnumber es obligatorio.");
            inputAddressNumber.id += "addressnumber" + (j - 1)
            inputAddressNumber.name += "Branches[" + (j - 1) + "].addressnumber";
            inputAddressNumber.type = "number";
            inputAddressNumber.value = "";

            var inputStateBranch = document.createElement("input");
            inputStateBranch.setAttribute("class", "text-box single-line");
            inputStateBranch.setAttribute("data-val", "true");
            inputStateBranch.setAttribute("data-val-number", "The field state must be a number.");
            inputStateBranch.setAttribute("data-val-required", "El campo state es obligatorio.");
            inputStateBranch.setAttribute("hidden", "hidden");
            inputStateBranch.setAttribute("id", "stateBranch_" + (j - 1));
            inputStateBranch.setAttribute("name", "Branches[" + (j - 1) + "].state");
            inputStateBranch.setAttribute("type", "number");
            inputStateBranch.setAttribute("value", "1");

            var spanName = document.createElement("span");
            spanName.className += "field-validation-valid text-danger";
            spanName.setAttribute("data-valmsg-for", "Branches[" + (j - 1) + "].name");
            spanName.setAttribute("data-valmsg-replace", "true");

            var spanAddress = document.createElement("span");
            spanAddress.className += "field-validation-valid text-danger";
            spanAddress.setAttribute("data-valmsg-for", "Branches[" + (j - 1) + "].address");
            spanAddress.setAttribute("data-valmsg-replace", "true");

            var spanAddressNumber = document.createElement("span");
            spanAddressNumber.className += "field-validation-valid text-danger";
            spanAddressNumber.setAttribute("data-valmsg-for", "Branches[" + (j - 1) + "].addressnumber");
            spanAddressNumber.setAttribute("data-valmsg-replace", "true");

            //Appends
            divbranch.appendChild(divToDeleteBranch);

            divToDeleteBranch.appendChild(inputIDBranch);

            divToDeleteBranch.appendChild(label1Branch);

            divToDeleteBranch.appendChild(div1Address);
            div1Address.appendChild(labelAddress);
            div1Address.appendChild(div2Address);
            div2Address.appendChild(inputAddress);
            div2Address.appendChild(spanAddress);

            divToDeleteBranch.appendChild(div1AddressNumber);
            div1AddressNumber.appendChild(labelAddressNumber);
            div1AddressNumber.appendChild(div2AddressNumber);
            div2AddressNumber.appendChild(inputAddressNumber);
            div2AddressNumber.appendChild(spanAddressNumber);

            divToDeleteBranch.appendChild(div1Name);
            div1Name.appendChild(labelName);
            div1Name.appendChild(div2Name);
            div2Name.appendChild(inputName);
            div2Name.appendChild(spanName);

            divToDeleteBranch.appendChild(inputStateBranch);

            //Delete button
            var divDeleteBranch1 = document.createElement("div");
            divDeleteBranch1.className += "form-group";

            var divDeleteBranch2 = document.createElement("div");
            divDeleteBranch2.className += "col-md-10";

            var inputBranchDelete = document.createElement("input");
            inputBranchDelete.type = "button";
            inputBranchDelete.id = "deleteBranch_" + (j - 1);
            inputBranchDelete.value = "Eliminar esta sucursal";

            var inputBranchunDelete = document.createElement("input");
            inputBranchunDelete.type = "button";
            inputBranchunDelete.id = "undeleteBranch_" + (j - 1);
            inputBranchunDelete.value = "Recuperar esta sucursal";
            inputBranchunDelete.setAttribute("disabled", "disabled");
            inputBranchunDelete.setAttribute("hidden", "hidden");

            divToDeleteBranch.appendChild(divDeleteBranch1);
            divDeleteBranch1.appendChild(divDeleteBranch2);
            divDeleteBranch2.appendChild(inputBranchDelete);
            divDeleteBranch2.appendChild(inputBranchunDelete);
            inputBranchDelete.addEventListener("click", deleteCustomBranch, false);
            inputBranchunDelete.addEventListener("click", unDeleteCustomBranch, false);

            //j
            j++;
        }
    }

    function deleteCustomAcc()
    {
        var id = this.getAttribute("id");
        var number = id.replace("deleteAcc_", "");
        var stateToChange = "stateAcc_" + number;
        nodeState = $("#" + stateToChange);
        nodeState[0].setAttribute("value", "2");

        var toDeleteAcc = "divToDeleteAcc_" + number;
        var nodeToDeleteAcc = $("#" + toDeleteAcc);
        nodeToDeleteAcc[0].setAttribute("style", "background:red");

        this.setAttribute("disabled", "disabled");
        this.setAttribute("hidden", "hidden");

        var btnUnDelete = "undeleteAcc_" + number;
        var nodeUnDelete = $("#" + btnUnDelete);
        nodeUnDelete[0].removeAttribute("hidden");
        nodeUnDelete[0].removeAttribute("disabled");

        //var nodes = nodeToDelete[0].childNodes;
        //console.log(nodes);
        //for (var i = 0; i < nodes.length; i++)
        //{

        //}
    }

    function deleteCustomBranch()
    {
        var id = this.getAttribute("id");
        var number = id.replace("deleteBranch_", "");
        var stateToChange = "stateBranch_" + number;
        nodeState = $("#" + stateToChange);
        nodeState[0].setAttribute("value", "2");

        var toDeleteBranch = "divToDeleteBranch_" + number;
        var nodeToDeleteBranch = $("#" + toDeleteBranch);
        nodeToDeleteBranch[0].setAttribute("style", "background:red");

        this.setAttribute("disabled", "disabled");
        this.setAttribute("hidden", "hidden");

        var btnUnDelete = "undeleteBranch_" + number;
        var nodeUnDelete = $("#" + btnUnDelete);
        nodeUnDelete[0].removeAttribute("hidden");
        nodeUnDelete[0].removeAttribute("disabled");
    }

    function unDeleteCustomAcc()
    {
        var id = this.getAttribute("id");
        var number = id.replace("undeleteAcc_", "");
        var stateToChange = "stateAcc_" + number;
        nodeState = $("#" + stateToChange);
        nodeState[0].setAttribute("value", "1");

        var toDeleteAcc = "divToDeleteAcc_" + number;
        var nodeToDeleteAcc = $("#" + toDeleteAcc);
        nodeToDeleteAcc[0].setAttribute("style", "background:green");

        this.setAttribute("hidden", "hidden");
        this.setAttribute("disabled", "disabled");

        var btnUnDelete = "deleteAcc_" + number;
        var nodeUnDelete = $("#" + btnUnDelete);
        nodeUnDelete[0].removeAttribute("hidden");
        nodeUnDelete[0].removeAttribute("disabled");
    }

    function unDeleteCustomBranch()
    {
        var id = this.getAttribute("id");
        var number = id.replace("undeleteBranch_", "");
        var stateToChange = "stateBranch_" + number;
        nodeState = $("#" + stateToChange);
        nodeState[0].setAttribute("value", "1");

        var toDeleteBranch = "divToDeleteBranch_" + number;
        var nodeToDeleteBranch = $("#" + toDeleteBranch);
        nodeToDeleteBranch[0].setAttribute("style", "background:green");

        this.setAttribute("hidden", "hidden");
        this.setAttribute("disabled", "disabled");

        var btnUnDelete = "deleteBranch_" + number;
        var nodeUnDelete = $("#" + btnUnDelete);
        nodeUnDelete[0].removeAttribute("hidden");
        nodeUnDelete[0].removeAttribute("disabled");
    }

    //Modal
    function saveChangeTags()
    {

    }

    //Photo
    $("#FileUpload").on("change", function (event) {
        readURL(this);
    });

    function EnDisSubmit(event)
    {

    };

    function ExecuteUpload()
    {
        var formData = new FormData();
        var totalFiles = document.getElementById("FileUpload").files.length;
        for (var i = 0; i < totalFiles; i++)
        {
            var file = document.getElementById("FileUpload").files[i];
            formData.append("FileUpload", file);
        }
        $.ajax({
            type: "POST",
            url: '/File/UploadPublicPhoto',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response)
            {
                $("#profilephoto").val(response.Path);
                EnDisSubmit();
            },
            error: function (error)
            {
                $("#profilephoto").val("");
                EnDisSubmit();
            }
        });
    };

    function readURL(fileInput)
    {
        
        var files = fileInput.files;
        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            var validExtensions = ['jpg', 'jpeg', 'png', 'gif'];
            var fileName = file.name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
            if ($.inArray(fileNameExt, validExtensions) == -1) {

                alert("Tipo de archivo inválido");
                ClearFile();
                EnDisSubmit();
                event.stopPropagation();
                event.preventDefault();
                return false;
            }
            else if (file.size / 1024 / 1024 > 5)
            {
                alert("No puede subir una imagen mayor a 5 Mb");
                ClearFile();
                EnDisSubmit();
                event.stopPropagation();
                event.preventDefault();
                return false;
            }
            var img = document.getElementById("Photo");
            img.file = file;
            var reader = new FileReader();
            reader.onload = (function (aImg) {
                return function (e) {
                    aImg.src = e.target.result;
                };
            })(img);
            reader.readAsDataURL(file);
            ExecuteUpload();
        }

    }

    function ClearFile()
    {
        document.getElementById("Photo").src = "";
        document.getElementById("FileUpload").files = null;
        document.getElementById("FileUpload").value = "";
        $("#FileUpload").val("");
        $('#file').replaceWith($('#file').clone());
        $("#profilephoto").val("");
    }

    function clearFileInput(ctrl)
    {
        try
        {
            ctrl.value = null;
        }
        catch (ex)
        {

        }
        if (ctrl.value)
        {
            ctrl.parentNode.replaceChild(ctrl.cloneNode(true), ctrl);
        }
    }

    //Charge photo
    if(view.value == "update")
    {
            var idElement = document.getElementById("idScript");
            var photoElement = document.getElementById("photoScript");
            id = idElement.value;
            profilephoto = photoElement.value;
            {
                var qualiter = {
                    Fitmode: 2,
                    Height: 150,
                    Widht:150,
                    Quality:100
                };

                var requestData = {
                    localFilePath: JSON.parse(JSON.stringify(profilephoto).replace(/\\""/g, '')),
                    qual:qualiter
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
                        console.log("error");
                    }
                });

                function base64encode(binary) {
                    return btoa(unescape(encodeURIComponent(binary)));
                }
            };
    }
})