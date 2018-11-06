(function () {
    $(function () {


       
        var _RestorationTypeService = abp.services.app.restorationType;
        
        var _$modal = $('#RestorationTypeCreateModal');
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

        $('.delete-RestorationType').click(function () {
            var RestorationTypeId = $(this).attr("data-RestorationType-id");
            var RestorationTypeName = $(this).attr('data-RestorationType-name');

            deleteRestorationType(RestorationTypeId, RestorationTypeName);
        });

        $('.edit-RestorationType').click(function (e) {
            var RestorationTypeId = $(this).attr("data-RestorationType-id");

           e.preventDefault();
           $.ajax({
               url: abp.appPath + 'RestorationType/EditRestorationTypeModal?RestorationTypeId=' + RestorationTypeId,
                type: 'POST',
               contentType: 'application/html',
                success: function (content) {
                    $('#RestorationTypeEditModal div.modal-content').html(content);
               },
                error: function (e) { }
           });
        });

        _$form.find('button[type="submit"]').click(function (e) {
           e.preventDefault();

            if (!_$form.valid()) {
                return;
          }

            var _restorationType = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            _restorationType.RestorationTypeName = document.getElementById('restorationTypeName').value;
        //   //user.roleNames = [];
        //   //var _$roleCheckboxes = $("input[name='role']:checked");
        //    //if (_$roleCheckboxes) {
        //    //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
        //   //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
        //    //        user.roleNames.push(_$roleCheckbox.attr('data-role-name'));
        //    //    }
        //    //}

            abp.ui.setBusy(_$modal);
            
            _RestorationTypeService.create(_restorationType).done(function () {
                
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

        function deleteRestorationType(RestorationTypeId, RestorationTypeName) {
            abp.message.confirm(
                "Delete Restoration Type '" + RestorationTypeName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _RestorationTypeService.delete({
                            id: RestorationTypeId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();