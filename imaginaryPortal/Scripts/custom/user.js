$(document).ready(function () {
    bindTable();
    load_json_data('country');
    function load_json_data(id, parent_id) {
        var html_code = '';
        $.getJSON('http://localhost:1208/country_state_city.json', function (data) {

            html_code += '<option value="">Select ' + id + '</option>';
            $.each(data, function (key, value) {
                if (id == 'country') {
                    if (value.parent_id == '0') {
                        html_code += '<option value="' + value.id + '">' + value.name + '</option>';
                    }
                }
                else {
                    if (value.parent_id == parent_id) {
                        html_code += '<option value="' + value.id + '">' + value.name + '</option>';
                    }
                }
            });
            $('#' + id).html(html_code);
        });

    }

    $(document).on('change', '#country', function () {
        var country_id = $(this).val();
        if (country_id != '') {
            load_json_data('state', country_id);
        }
        else {
            $('#state').html('<option value="">Select state</option>');
            $('#city').html('<option value="">Select city</option>');
        }
    });
    $(document).on('change', '#state', function () {
        var state_id = $(this).val();
        if (state_id != '') {
            load_json_data('city', state_id);
        }
        else {
            $('#city').html('<option value="">Select city</option>');
        }
    });
    $("#Pic").change(function () {

        var File = this.files;

        if (File && File[0]) {
            ReadImage(File[0]);
        }

    })
});

//$(document).on('click', '#btnSubmit', function () {
   
//    var pic = $("#Pic").get(0).files;
//    var data = new FormData;
//    data.append("Photo", pic[0]);
//    data.append("FullName", $('#txtFirstName').val() + $('#txtLastName').val());
//    data.append("Email", $('#txtEmail').val());
//    data.append("Country", $('#country').find(":selected").text());
//    data.append("State", $('#state').find(":selected").text());
//    data.append("City", $('#city').find(":selected").text());
//    data.append("Password", $('#txtPassword').val());
//    data.append("Mobile", $('#txtMobile').val());
//    data.append("Gender", $('input[name=Gender]:checked', 'frmUSer').val());
//    console.log(data);
//    $.ajax({
//        url: '/Registration/Index',
//        type: 'POST',
//        data: data,
//        contentType: false,
//        processData: false,
//        dataType: 'json',
//        success: function () {
//            $("#imageBrowes").val('');
//            $("#description").text('');
//            $("#imgPreview").hide();
//            alert("saved");
//        }
//    });
//});


var ReadImage = function (file) {

    var reader = new FileReader;
    var image = new Image;

    reader.readAsDataURL(file);
    reader.onload = function (_file) {

        image.src = _file.target.result;
        image.onload = function () {
            $("#targetImg").attr('src', _file.target.result);
            $("#imgPreview").toggle();

        }

    }
}

function ClearPreview() {
    $("#imgPreview").toggle();
    $("#Pic").val('');
}

 function bindTable () {
    $.ajax({
        type: 'GET',
        url: '/api/master/loadUsers',
        dataType: 'JSON',
        success: function (data) {
            console.log(data);
        }


    });
}