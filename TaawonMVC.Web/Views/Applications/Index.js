
// search bar rejected applications
$(document).ready(function () {
    $("body").on("keyup", "#RejectedApplicationInput", function (event) {

        // alert("called");
        searchRejectedFunction();
    });
});

function searchRejectedFunction() {
    var searchinput = document.getElementById("RejectedApplicationInput");
    //alert(searchinput);
    var searchTXT = searchinput.value.toUpperCase();
    var url = abp.appPath + 'Applications/SearchRejectedIndex?searchTXT=' + searchTXT;
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
    //  alert("called2"+ searchTXT);
    $.ajax({
        url: url,
        headers: headers,
        type: 'POST',
        contentType: 'application/html',
        success: function (content) {
            // location.reload(false); //reload page to see new user!  
            $('#RejectedApplicationTableContent').html(content);
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
// end of search bar Rejected applications 

// search bar approved applications
$(document).ready(function () {
    $("body").on("keyup", "#ApprovedApplicationInput", function (event) {

        // alert("called");
        searchApprovedFunction();
    });
});

function searchApprovedFunction() {
    var searchinput = document.getElementById("ApprovedApplicationInput");
    //alert(searchinput);
    var searchTXT = searchinput.value.toUpperCase();
    var url = abp.appPath + 'Applications/SearchApprovedIndex?searchTXT=' + searchTXT;
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
    //  alert("called2"+ searchTXT);
    $.ajax({
        url: url,
        headers: headers,
        type: 'POST',
        contentType: 'application/html',
        success: function (content) {
            // location.reload(false); //reload page to see new user!  
            $('#ApprovedApplicationTableContent').html(content);
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
// end of search bar approved applications 

// search bar not processed applications  ==================
//$(document).ready(function () {
//    $("body").on("keyup", "#ApplicationInput", function (event) {

//        // alert("called");
//        searchFunction();
//    });
//});

//function searchFunction() {
//    var searchinput = document.getElementById("ApplicationInput");
//    //alert(searchinput);
//    var searchTXT = searchinput.value.toUpperCase();
//    var url = abp.appPath + 'Applications/SearchIndex?searchTXT=' + searchTXT;
//    var token = $('input[name="__RequestVerificationToken"]').val();
//    var headers = {};
//    headers['__RequestVerificationToken'] = token;
//    //  alert("called2"+ searchTXT);
//    $.ajax({
//        url: url,
//        headers: headers,
//        type: 'POST',
//        contentType: 'application/html',
//        success: function(content) {
//            // location.reload(false); //reload page to see new user!  
//            $('#ApplicationTableContent').html(content);
//            //  alert("called3" + searchTXT);
//            //$('#TableContent').load(content);
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            // alert("called4" + searchTXT);
//            alert(xhr.status);
//            alert(thrownError);
//        }
//    });

//}

// end of search bar =======================


//$(document).ready(function () {
//    var table = $('#example').DataTable();

//    $('#example tbody').on('click', 'tr', function () {
//        $(this).toggleClass('selected');
//        alert("1");
//    });

//    $('#button').click(function () {
//        alert(table.rows('.selected').data().length + ' row(s) selected');
//    });
//});
//======================================
// upload project files =======
function ProjectUploadShowFiles() {
    ProjectUploadFilesFunction();
    ProjectShowUploadedFilesFunction();
}

function ProjectShowUploadedFilesFunction() {
    // alert("ShowUploadedFile");
    var projectId = document.getElementById("projectId").value;
    // alert(buildingId);
    //var url = abp.appPath + 'Building/ShowUploadedFiles?buildingId=' + buildingId;
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
    //  alert("called2"+ searchTXT);
    $.ajax({
        url: abp.appPath + 'Applications/ShowProjectUploadedFiles?projectId=' + projectId,
        headers: headers,
        type: 'POST',
        contentType: 'application/html',
        success: function (content) {
            // location.reload(false); //reload page to see new user!  
            $('#ShowProjectFiles').html(content);
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

function ProjectUploadFilesFunction() {
    var data = new FormData();

    var projectId = document.getElementById("projectId").value;
    var filesInput = document.getElementById('datafile');
    var restorationLevel;
    if (document.getElementById('status1').checked) {
        restorationLevel = document.getElementById('status1').value;
    }
    if (document.getElementById('status2').checked) {
        restorationLevel = document.getElementById('status2').value;
    }
    if (document.getElementById('status3').checked) {
        restorationLevel = document.getElementById('status3').value;
    }
    alert(restorationLevel);
    var noOfFiles = filesInput.files.length;
    //alert(filesInput.files.length);
    //alert(files1[0].name);
    // alert(files1[1].name);
    for (var i = 0; i < filesInput.files.length; i++) {

        // alert(filesInput.files[i].name);


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
            url: abp.appPath + 'Applications/SaveProjectUploadedFiles?projectId=' + projectId + '&filenumber=' + i + '&noOfFiles=' + noOfFiles + '&restorationLevel=' + restorationLevel,
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
// end of upload project files 
function UploadShowFiles() {
    UploadFilesFunction();
    ShowUploadedFilesFunction();
}

function ShowUploadedFilesFunction() {
    // alert("ShowUploadedFile");
    var applicationId = document.getElementById("applicationId").value;
    // alert(buildingId);
    //var url = abp.appPath + 'Building/ShowUploadedFiles?buildingId=' + buildingId;
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
    //  alert("called2"+ searchTXT);
    $.ajax({
        url: abp.appPath + 'Applications/ShowUploadedFiles?applicationId=' + applicationId,
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

function UploadFilesFunction() {
    var data = new FormData();

    var applicationId = document.getElementById("applicationId").value;
    var filesInput = document.getElementById('datafile')
    var noOfFiles = filesInput.files.length;
    //alert(filesInput.files.length);
    //alert(files1[0].name);
    // alert(files1[1].name);
    for (var i = 0; i < filesInput.files.length; i++) {

        // alert(filesInput.files[i].name);


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
            url: abp.appPath + 'Applications/SaveUploadedFiles?applicationId=' + applicationId + '&filenumber=' + i + '&noOfFiles=' + noOfFiles,
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





(function () {
    $(function () {


       
        var _applicationService = abp.services.app.applications;
        var _uploadApplicationFileService = abp.services.app.uploadApplicationFiles;
        var _uploadProjectFileService = abp.services.app.uploadProjectFiles;
        var _projectService =abp.services.app.projects;

        
        
        //var _$modal = $('#propertyOwnershipCreateModal');
        //var _$form = _$modal.find('form');

        //_$form.validate({
        //    rules: {
        //        Password: "required",
        //        ConfirmPassword: {
        //            equalTo: "#Password"
        //        }
        //    }
        //});
        $('.delete-File').click(function () {
            var fileId = $(this).attr("data-Uploadfile-id");
            var fileName = $(this).attr('data-Uploadfile-name');

            deleteFile(fileId, fileName);
        });

        $('.delete-project-File').click(function () {
            var fileId = $(this).attr("data-Project-Uploadfile-id");
            var fileName = $(this).attr('data-Project-Uploadfile-name');

            deleteProjectFile(fileId, fileName);
        });

        $('.delete-project').click(function () {
            var projectId = $(this).attr("data-Project-id");
            var projectName = $(this).attr('data-Project-name');

            deleteProject(projectId, projectName);
        });

        $('.reject-Application').click(function () {
           // alert("1");
            var ApplicationId = $(this).attr("data-application-id");
           // var applicationName = $(this).attr('data-application-name');
            $.ajax({ 
                url: abp.appPath + 'Applications/RejectApplication?applicationId=' + ApplicationId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    alert("Application has been Rejected");
                    refreshUserList();
                },
                error: function (exhr, thrownError) {
                    alert(exhr.status);
                    alert("Application Already Rejected");
                }
            });
        });

        $('.approve-Application').click(function () {
            // alert("1");
            var ApplicationId = $(this).attr("data-application-id");
            // var applicationName = $(this).attr('data-application-name');
            $.ajax({
                url: abp.appPath + 'Applications/ApproveApplication?applicationId=' + ApplicationId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    alert("Application has been Approved");
                    refreshUserList();

                },
                error: function (exhr, ajaxOptions, thrownError) {
                    alert(exhr.status);
                   // alert(xhr.responseText);
                   // alert(xhr.statusText);
                    alert(thrownError);
                    alert("Application Already Approved");
                }
            });
        });

        $('.edit-project').click(function () {
            // alert("1");
            var projectId = $(this).attr("data-Project-id");
            // var applicationName = $(this).attr('data-application-name');
            $.ajax({
                url: abp.appPath + 'Applications/EditProject?projectId=' + projectId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#ProjectEditModal div.modal-content').html(content); 
                },
                error: function (exhr, ajaxOptions, thrownError) {
                    alert(exhr.status);
                    alert(thrownError);
                }
            });
        });


        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-application').click(function () {
            var applicationId = $(this).attr("data-application-id");
            var applicationName = $(this).attr('data-application-name');

            deleteApplication(applicationId, applicationName);
        });

        $('.upload-application-file').click(function (e) {
            var applicationId = $(this).attr("data-application-id");
           // alert("1");
           e.preventDefault();
           $.ajax({
              // url: abp.appPath + 'PropertyOwnership/Index' ,
               url: abp.appPath + 'Applications/UploadFileModal?applicationId=' + applicationId,
               type: 'POST',
               contentType: 'application/html',
               success: function (content) {
               //   alert("2");
                   $('#FileUploadModal div.modal-content').html(content);
               },
              error: function (e) { alert("3"); }
           });
        });

        $('.upload-project-file').click(function (e) {
            var ProjectId = $(this).attr("data-Project-id");
            // alert("1");
            e.preventDefault();
            $.ajax({
                // url: abp.appPath + 'PropertyOwnership/Index' ,
                url: abp.appPath + 'Applications/UploadProjectFileModal?ProjectId=' + ProjectId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    //   alert("2");
                    $('#ProjectFileUploadModal div.modal-content').html(content);
                },
                error: function (e) { alert("3"); }
            });
        });

        //_$form.find('button[type="submit"]').click(function (e) {
        //   e.preventDefault();

        //    if (!_$form.valid()) {
        //        return;
        //  }

        //    var _propertyOwnership = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
        //    _propertyOwnership.PropertyOwnershipName = document.getElementById('PropertyOwnershipName').value;
        ////   //user.roleNames = [];
        ////   //var _$roleCheckboxes = $("input[name='role']:checked");
        ////    //if (_$roleCheckboxes) {
        ////    //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
        ////   //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
        ////    //        user.roleNames.push(_$roleCheckbox.attr('data-role-name'));
        ////    //    }
        ////    //}

        //    abp.ui.setBusy(_$modal);
            
        //    _propertyOwnershipService.create(_propertyOwnership).done(function () {
                
        //    _$modal.modal('hide');
        //     location.reload(true); //reload page to see new user!
        //        }).always(function () {
        //        abp.ui.clearBusy(_$modal);
        //        });
        //     });

        //_$modal.on('shown.bs.modal', function () {
        //    _$modal.find('input:not([type=hidden]):first').focus();
        //});

        function refreshUserList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteApplication(applicationId, applicationName) {
            abp.message.confirm(
                "Delete Application '" + applicationName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _applicationService.delete({
                            id: applicationId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }

        //function RejectApplication(applicationId, applicationName) {
        //    abp.message.confirm(
        //        "Reject Application '" + applicationName + "'?",
        //        function (isConfirmed) {
        //            if (isConfirmed) {
        //                $.ajax({
        //                    // url: abp.appPath + 'PropertyOwnership/Index' ,
        //                    url: abp.appPath + 'Applications/RejectApplication?applicationId=' + applicationId,
        //                    type: 'POST',
        //                    contentType: 'application/html',
        //                    success: function (content) {
        //                        //   alert("2");
        //                        Alert("Application has been Rejected");
        //                    },
        //                    error: function (e) { alert("3"); }
        //                });
        //            }
        //        }
        //    );
        //}

        function deleteFile(fileId, fileName) {
            abp.message.confirm(
                "Delete File '" + fileName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _uploadApplicationFileService.delete({
                            id: fileId
                        }).done(function () {
                            ShowUploadedFilesFunction();
                        });
                    }
                }
            );
        }

        function deleteProjectFile(fileId, fileName) {
            abp.message.confirm(
                "Delete File '" + fileName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _uploadProjectFileService.delete({
                            id: fileId
                        }).done(function () {
                            ProjectShowUploadedFilesFunction();
                        });
                    }
                }
            );
        }

        function deleteProject(projectId, projectName) {
            abp.message.confirm(
                "Delete Project '" + projectName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _projectService.delete({
                            id: projectId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();