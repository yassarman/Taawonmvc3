(function () {
    $(function () {


       
        var _propertyOwnershipService = abp.services.app.propertyOwnership;
        
        var _$modal = $('#propertyOwnershipCreateModal');
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

        $('.delete-propertyOwnership').click(function () {
            var propertyOwnershipId = $(this).attr("data-propertyOwnership-id");
            var propertyOwnershipName = $(this).attr('data-propertyOwnership-name');

            deletepropertyOwnership(propertyOwnershipId, propertyOwnershipName);
        });

        $('.edit-propertyOwnership').click(function (e) {
            var propertyOwnershipId = $(this).attr("data-propertyOwnership-id");
           // alert("1");
           e.preventDefault();
           $.ajax({
              // url: abp.appPath + 'PropertyOwnership/Index' ,
               url: abp.appPath + 'PropertyOwnership/EditPropertyOwnershipModal?propertyOwnershipId=' + propertyOwnershipId,
                type: 'POST',
               contentType: 'application/html',
               success: function (content) {
                //   alert("2");
                    $('#PropertyOwnershipEditModal div.modal-content').html(content);
               },
               error: function (e) { alert("3"); }
           });
        });

        _$form.find('button[type="submit"]').click(function (e) {
           e.preventDefault();

            if (!_$form.valid()) {
                return;
          }

            var _propertyOwnership = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            _propertyOwnership.PropertyOwnershipName = document.getElementById('PropertyOwnershipName').value;
        //   //user.roleNames = [];
        //   //var _$roleCheckboxes = $("input[name='role']:checked");
        //    //if (_$roleCheckboxes) {
        //    //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
        //   //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
        //    //        user.roleNames.push(_$roleCheckbox.attr('data-role-name'));
        //    //    }
        //    //}

            abp.ui.setBusy(_$modal);
            
            _propertyOwnershipService.create(_propertyOwnership).done(function () {
                
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

        function deletepropertyOwnership(propertyOwnershipId, propertyOwnershipName) {
            abp.message.confirm(
                "Delete Restoration Type '" + propertyOwnershipName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _propertyOwnershipService.delete({
                            id: propertyOwnershipId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();