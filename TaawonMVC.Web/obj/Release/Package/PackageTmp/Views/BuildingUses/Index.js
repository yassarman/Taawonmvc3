(function () {
    $(function () {


        var _buildingUsesService = abp.services.app.buildingUses;
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
            var BuildingUsesId = $(this).attr("data-BuildingUses-id");
            var BuildingUsesName = $(this).attr('data-BuildingUses-name');

            deleteUser(BuildingUsesId, BuildingUsesName);
        });

        $('.edit-user').click(function (e) {
            var BuildingUsesId = $(this).attr("data-BuildingUses-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'BuildingUses/EditBuildingUsesModal?BuildingUsesId=' + BuildingUsesId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#UserEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var _buildingUses = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            _buildingUses.UsedFor = document.getElementById('UsedFor').value;
            //user.roleNames = [];
            //var _$roleCheckboxes = $("input[name='role']:checked");
            //if (_$roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
            //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
            //        user.roleNames.push(_$roleCheckbox.attr('data-role-name'));
            //    }
            //}

            abp.ui.setBusy(_$modal);
            _buildingUsesService.create(_buildingUses).done(function () {
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

        function deleteUser(BuildingUsesId, BuildingUsesName) {
            abp.message.confirm(
                "Delete Building Uses '" + BuildingUsesName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _buildingUsesService.delete({
                            id: BuildingUsesId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();