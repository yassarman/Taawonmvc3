
// used for search bar 
$(document).ready(function () {
    $("body").on("keyup", "#myInput", function (event) {

       // alert("called");
        searchFunction();
        



    });
});

 function searchFunction() {
     var searchinput = document.getElementById("myInput");
     //alert(searchinput);
     var searchTXT = searchinput.value.toUpperCase();
     var url = abp.appPath + 'Building/SearchIndex?searchTXT=' + searchTXT;
     var token = $('input[name="__RequestVerificationToken"]').val();
     var headers = {};
     headers['__RequestVerificationToken'] = token;
   //  alert("called2"+ searchTXT);
         $.ajax({
             url: url,
             headers: headers,
               type: 'POST',
               contentType: 'application/html',
               success: function(content) {
                 // location.reload(false); //reload page to see new user!  
                   $('#TableContent').html(content);
                 //  alert("called3" + searchTXT);
                 //$('#TableContent').load(content);
                },
             error: function (xhr, ajaxOptions, thrownError) {
                // alert("called4" + searchTXT);
                 alert(xhr.status);
                 alert(thrownError);
             }
         });

}
// end of search bar 
// show created building units on submit input 

//$(document).ready(function () {
//    $("body").on("click", "#CreateNewUnit", function (event) {

//        // alert("called");
//        ShowCreatedUnitsFunction()

//    });
//});

// show created building unit from application form 
function ShowCreatedUnitsAppFunction() {
    // alert("ShowUploadedFile");
    var buildingId = document.getElementById("buildingId").value;
    // alert(buildingId);
    //var url = abp.appPath + 'Building/ShowUploadedFiles?buildingId=' + buildingId;
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
    //  alert("called2"+ searchTXT);
    $.ajax({
        url: abp.appPath + 'Building/ShowBuildingUnits?buildingId=' + buildingId,
        headers: headers,
        type: 'POST',
        contentType: 'application/html',
        success: function (content) {
            // location.reload(false); //reload page to see new user!  
            $('#ShowCreatedUnitsApp').html(content);
            //  alert("called3" + searchTXT);
            //$('#TableContent').load(content);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            // alert("called4" + searchTXT);
            alert(xhr.status);
            alert(thrownError);
        }
    });

}
//============ end ======================
function ShowCreatedUnitsFunction() {
    // alert("ShowUploadedFile");
    var buildingId = document.getElementById("buildingId").value;
    // alert(buildingId);
    //var url = abp.appPath + 'Building/ShowUploadedFiles?buildingId=' + buildingId;
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
    //  alert("called2"+ searchTXT);
    $.ajax({
        url: abp.appPath + 'Building/ShowBuildingUnits?buildingId=' + buildingId,
        headers: headers,
        type: 'POST',
        contentType: 'application/html',
        success: function (content) {
            // location.reload(false); //reload page to see new user!  
            $('#ShowCreatedUnits').html(content);
            //  alert("called3" + searchTXT);
            //$('#TableContent').load(content);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            // alert("called4" + searchTXT);
            alert(xhr.status);
            alert(thrownError);
        }
    });

}

//==== end ==================================

// for upload file and show uploaded files 
//$(document).ready(function () {
//    $("form").on("click", "#submitUploadFile", function (event) {

//        // alert("called");
        
//        UploadFilesFunction();
//        ShowUploadedFilesFunction();
//        //alert("in event listener");
        

//    });
//});
// show uploaded files when tab change 
$('#UploadFilesShow').on("shown.bs.tab", function (event) {
//   // alert("hello");
   ShowUploadedFilesFunction();
});
//========================================
// show created units when tab change 
$('#BuildingUnitsShow').on("shown.bs.tab", function (event) {
    //   // alert("hello");
    ShowCreatedUnitsFunction();
});
//==================================
// end of show files when tab changed 
//=========================================
// upload file and shows uploaded files =====
  function UploadShowFiles() {
      UploadFilesFunction();
      ShowUploadedFilesFunction();
   }
// end of upload file and shows uploaded files 

// show uploaded files function ===============

function ShowUploadedFilesFunction() {
    // alert("ShowUploadedFile");
    var buildingId = document.getElementById("buildingId").value;
    // alert(buildingId);
    //var url = abp.appPath + 'Building/ShowUploadedFiles?buildingId=' + buildingId;
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
    //  alert("called2"+ searchTXT);
    $.ajax({
        url: abp.appPath + 'Building/ShowUploadedFiles?buildingId=' + buildingId,
        headers: headers,
        type: 'POST',
        contentType: 'application/html',
        success: function (content) {
            // location.reload(false); //reload page to see new user!  
            $('#ShowFiles').html(content);
            //  alert("called3" + searchTXT);
            //$('#TableContent').load(content);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            // alert("called4" + searchTXT);
            alert(xhr.status);
            alert(thrownError);
        }
    });

}

// end of uploaded files function ==========

/// ==== upload files 
function UploadFilesFunction() {
    var data = new FormData();

    var BuildingId = document.getElementById("buildingId").value;
    //=====for bar and not used 02082018
    var bar = $('.bar');
    var percent = $('.percent');
    var status = $('#status');
    //============

    // var filesInput = $("#datafile")[0].files;
    var filesInput = document.getElementById('datafile')
    var noOfFiles = filesInput.files.length;
    //alert(filesInput.files.length);
    //var filescount = filesInput.files.length;
    //alert(files1[0].name);
    // alert(files1[1].name);
    // var files = $("#datafile").get(0).files;
    for (var i = 0; i < filesInput.files.length; i++) {

        // alert(filesInput.files[i].name);

        // var files = $("#datafile").files;

        if (filesInput.files.length > 0) {

             data.append("HelpSectionImages" + i, filesInput.files[i]);
             // data.append("buildingId", BuildingId);
        }
        else {
              //common.showNotification('warning', 'Please select file to upload.', 'top', 'right');
              alert('Please select file to upload.');
              return false;
             }

                 $.ajax({
                    url: abp.appPath + 'Building/SaveUploadedFiles?BuildingId=' + BuildingId + '&filenumber=' + i + '&noOfFiles=' + noOfFiles,
                    type: "POST",
                    processData: false,
                    data: data,
                    dataType: 'json',
                    contentType: false,
                    // contentType:'application/html',
                    beforeSend: function () {
                        //status.empty();
                        //var percentVal = '0%';
                        //bar.width(percentVal);
                        //percent.html(percentVal);
                    },
                    uploadProgress: function (event, position, total, percentComplete) {
                        //var percentVal = percentComplete + '%';
                        //bar.width(percentVal);
                        //percent.html(percentVal);
                    },
                     success: function (response) {
                        //if (response != null || response != '')
                        //    alert(response);
                        //$("#datafile").val('');
                        // $('#ShowFiles').html(content);
                        //  bar.html(response.responseText);
                         $("#progress").show();
                         setTimeout(function () {
                         $("#progress").hide();
                          }, 2000);

                    },
                     complete: function (xhr) {
                        // status.html(xhr.responseText);
                     },

                     error: function (xhr, ajaxOptions, thrownError) {

                        // $("#message").html(er.responseText);
                        // $("#message").html("<font color='red'> ERROR: unable to upload files</font>");
                        alert(xhr.status);
                        alert(thrownError);
                     }

               });
    }
}
//===================
//============================================
//$(document).ready(function () {
//    //$("#myInput").keydown(function () {
//    //    $("#myInput").css("background-color", "yellow");
//    //});
//    $("#myInput").keyup(function () {
//       // $("#myInput").css("background-color", "pink");
//        var input = document.getElementById("myInput");
//        var searchTXT = input.value.toUpperCase();

//            $.ajax({
//               url: abp.appPath + 'Building/Index?searchTXT=' + searchTXT,
//               type: 'POST',
//               contentType: 'application/html',
//               success: function(content) {
//                 // location.reload(false); //reload page to see new user!  
//                 $('#TableContent').html(content);
//                 //$('#TableContent').load(content);
//               },
//               error: function() {}
//            });
//    });
//});
//document.querySelector('#myInput').addEventListener('keyup', searchFunction(), false);
//============================================

(function () {
    $(function () {

        var _BuildingService = abp.services.app.buildings;
        var _buildingUnitService = abp.services.app.buildingUnits;
        var _FileUploadService = abp.services.app.uploadFiles;
       // var _NeighborhoodService = abp.services.app.neighborhood
        var _$modal = $('#UserCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
            rules: {
                Password: "required",
                ConfirmPassword: {
                    equalTo: "#Password"
                }
            }
        });

        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-user').click(function () {
            var userId = $(this).attr("data-BuildingType-id");
            var userName = $(this).attr('data-BuildingType-name');

            deleteUser(userId, userName);
        });

        $('.delete-File').click(function () {
            var fileId = $(this).attr("data-Uploadfile-id");
            var fileName = $(this).attr('data-Uploadfile-name');

            deleteFile(fileId, fileName);
        });
        
        $('.delete-unit').click(function () {
            var unitId = $(this).attr("data-BuildingUnit-id");
            var unitName = $(this).attr('data-BuildingUnit-name');

            deleteUnit(unitId, unitName);
        });

        $('.delete-unit-refresh').click(function () {
            var unitId = $(this).attr("data-BuildingUnitR-id");
            var unitName = $(this).attr('data-BuildingUnitR-name');
           // alert("in delete");
            deleteUnitWithRefresh(unitId, unitName);
            deleteUnitAppWithRefresh(unitId, unitName);
        });

        $('.edit-user').click(function (e) {
            var userId = $(this).attr("data-BuildingType-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Building/EditBuildingModal?userId=' + userId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#UserEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        

        //$('.edit-Units').click(function (e) {
        //    var Id = $(this).attr("data-Building-id");

        //    e.preventDefault();
        //    $.ajax({
        //        url: abp.appPath + 'Building/ViewBuildingUnits?id=' + Id,
        //        type: 'POST',
        //        contentType: 'application/html',
        //        success: function (content) {
        //            $('#UploadFilesModal div.modal-content').html(content);
        //        },
        //        error: function (e) { }
        //    });
        //});

        $('.edit-BuildingUnit').click(function (e) {
            var Id = $(this).attr("data-BuildingUnit-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'BuildingUnit/EditBuildingUnitModal?BuildingUnitId=' + Id,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#UnitEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        //$('.submitUploadFile').click(function (e) {
        //    var Id = document.getElementById("buildingId").value;
        //   // var files = document.getElementById("datafile");
        //    var files = $("#datafile").get(0).files;
            
        //    // var httpfiles = document.getElementById("datafile").files;
        //    alert(files);
        //    e.preventDefault();
        //    $.ajax({
        //        url: abp.appPath + 'Building/UploadFiles?files=' +httpfiles+'&BuildingId=' + Id,
        //        type: 'POST',
        //        contentType: 'application/html',
        //        success: function (content) {
        //            $('#UploadFilesModal div.modal-content').html(content);
        //        },
        //        error: function (e) { }
        //    });
        //});
        //============================test upload file 02082018
        //$(function () {
        //    $('#submitUploadFile').click(function () {
        //        var data = new FormData();
                
        //        var BuildingId = document.getElementById("buildingId").value;
        //        //=====for bar and not used 02082018
        //        var bar = $('.bar');
        //        var percent = $('.percent');
        //        var status = $('#status');
        //        //============
               
        //        // var filesInput = $("#datafile")[0].files;
        //        var filesInput = document.getElementById('datafile')
        //        var noOfFiles = filesInput.files.length;
        //        //alert(filesInput.files.length);
        //        //var filescount = filesInput.files.length;
        //        //alert(files1[0].name);
        //       // alert(files1[1].name);
        //       // var files = $("#datafile").get(0).files;
        //        for (var i = 0; i < filesInput.files.length; i++) {

        //           // alert(filesInput.files[i].name);

        //            // var files = $("#datafile").files;

        //            if (filesInput.files.length > 0) {
                    
        //                data.append("HelpSectionImages" + i, filesInput.files[i]);
        //               // data.append("buildingId", BuildingId);
        //            }
        //            else {
        //            //    //common.showNotification('warning', 'Please select file to upload.', 'top', 'right');
        //              alert('Please select file to upload.');
        //               return false;
        //            }

        //            $.ajax({
        //                url: abp.appPath + 'Building/SaveUploadedFiles?BuildingId=' + BuildingId + '&filenumber=' + i + '&noOfFiles=' + noOfFiles,
        //                type: "POST",
        //                processData: false,
        //                data: data,
        //                dataType: 'json',
        //                contentType: false,
        //               // contentType:'application/html',
        //                beforeSend: function () {
        //                    //status.empty();
        //                    //var percentVal = '0%';
        //                    //bar.width(percentVal);
        //                    //percent.html(percentVal);
        //                },
        //                uploadProgress: function (event, position, total, percentComplete) {
        //                    //var percentVal = percentComplete + '%';
        //                    //bar.width(percentVal);
        //                    //percent.html(percentVal);
        //                },
        //                success: function (response) {
        //                    //if (response != null || response != '')
        //                    //    alert(response);
        //                    //$("#datafile").val('');
        //                    //$('#ShowFiles').html(content);

        //                    //  bar.html(response.responseText);
        //                      $("#progress").show();
        //                      setTimeout(function () {
        //                      $("#progress").hide();
        //                       }, 2000);

        //                },
        //                complete: function (xhr) {
        //                    // status.html(xhr.responseText);
        //                },

        //                error: function (xhr, ajaxOptions, thrownError) {

        //                    // $("#message").html(er.responseText);
        //                   // $("#message").html("<font color='red'> ERROR: unable to upload files</font>");
        //                    alert(xhr.status);
        //                    alert(thrownError);
        //                }

        //            });

        //        }
               
        //        return false;
        //    });

        //});


        //upload file end ===========================

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();
            //alert("1");
            if (!_$form.valid()) {
                return;
            }

            var _building = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            _building.numOfBuildingUnits = document.getElementById('numOfBuildingUnits').value;
            _building.numOfFloors = document.getElementById('numOfFloors').value;
            _building.streetName = document.getElementById('streetName').value;
            _building.buildingNo = document.getElementById('buildingNo').value;
            _building.IsInHoush = document.getElementById('IsInHoush').value;
            _building.houshName = document.getElementById('houshName').value;
            _building.neighborhoodID = document.getElementById('neighborhoodID').value;
            _building.buildingTypeID = document.getElementById('buildingTypeID').value;
            _building.buildingUsesID = document.getElementById('buildingUsesID').value;
            _building.GISMAP = document.getElementById('GISMAP').value;
            _building.houshProperty = document.getElementById('houshProperty').value;
            _building.X = document.getElementById('X').value;
            _building.Y = document.getElementById('Y').value;
            _building.BuildingName = document.getElementById('BuildingName').value;
           

            //user.roleNames = [];
            //var _$roleCheckboxes = $("input[name='role']:checked");
            //if (_$roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
            //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
            //        user.roleNames.push(_$roleCheckbox.attr('data-role-name'));
            //    }
            //}

            abp.ui.setBusy(_$modal);
            _BuildingService.create(_building).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshUserList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteUser(userId, userName) {
            abp.message.confirm(
                "Delete Building '" + userName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _BuildingService.delete({
                            id: userId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }

        function deleteFile(fileId, fileName) {
            abp.message.confirm(
                "Delete File '" + fileName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _FileUploadService.delete({
                            id: fileId
                        }).done(function () {
                            ShowUploadedFilesFunction();
                        });
                    }
                }
            );
        }

        function deleteUnit(unitId, unitName) {
            abp.message.confirm(
                "Delete Unit '" + unitName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _buildingUnitService.delete({
                            id: unitId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }

        function deleteUnitWithRefresh(unitId, unitName) {
            abp.message.confirm(
                "Delete Unit '" + unitName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _buildingUnitService.delete({
                            id: unitId
                        }).done(function () {
                            ShowCreatedUnitsFunction();
                            ShowCreatedUnitsAppFunction();

                        });
                    }
                }
            );
        }



    });
})();