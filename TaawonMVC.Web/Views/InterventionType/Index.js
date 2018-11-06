(function () {
    $(function () {


       
        var _interventionTypeService = abp.services.app.interventionType;
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

        $('.delete-InterventionType').click(function () {
            var InterventionTypeId = $(this).attr("data-InterventionType-id");
            var InterventionTypeName = $(this).attr('data-InterventionType-name');

            deleteInterventionType(InterventionTypeId, InterventionTypeName);
        });

        $('.edit-InterventionType').click(function (e) {
            var IntervertionTypeId = $(this).attr("data-InterventionType-id");

           e.preventDefault();
           $.ajax({
               url: abp.appPath + 'InterventionType/EditIntervertionTypeModal?IntervertionTypeId=' + IntervertionTypeId,
                type: 'POST',
               contentType: 'application/html',
                success: function (content) {
                    $('#InterventionTypeEditModal div.modal-content').html(content);
               },
                error: function (e) { }
           });
        });

        _$form.find('button[type="submit"]').click(function (e) {
           e.preventDefault();

            if (!_$form.valid()) {
                return;
          }

            var _interventionType = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            _interventionType.InterventionName = document.getElementById('InterventionName').value;
        //   //user.roleNames = [];
        //   //var _$roleCheckboxes = $("input[name='role']:checked");
        //    //if (_$roleCheckboxes) {
        //    //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
        //   //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
        //    //        user.roleNames.push(_$roleCheckbox.attr('data-role-name'));
        //    //    }
        //    //}

             abp.ui.setBusy(_$modal);
            _interventionTypeService.create(_interventionType).done(function () {
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

        function deleteInterventionType(InterventionTypeId, InterventionTypeName) {
            abp.message.confirm(
                "Delete Intervention Type '" + InterventionTypeName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _interventionTypeService.delete({
                            id: InterventionTypeId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();