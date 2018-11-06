(function () {
    $(function () {


       
        
        var _donorService = abp.services.app.donors
        var _$modal = $('#DonorCreateModal');
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

        $('.delete-Donor').click(function () {
            var DonorId = $(this).attr("data-Donor-id");
            var DonorName = $(this).attr('data-Donor-name');

            deleteDonor(DonorId, DonorName);
        });

        $('.edit-Donor').click(function (e) {
            var DonorId = $(this).attr("data-Donor-id");
           // alert(1);
           e.preventDefault();
           $.ajax({
               url: abp.appPath + 'Donors/EditDonorModal?DonorId=' + DonorId,
                type: 'POST',
               contentType: 'application/html',
                success: function (content) {
                    $('#DonorEditModal div.modal-content').html(content);
               },
                error: function (e) { }
           });
        });

        _$form.find('button[type="submit"]').click(function (e) {
           e.preventDefault();

            if (!_$form.valid()) {
                return;
          }

            var _donor = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            _donor.DonorName = document.getElementById('DonorName').value;
        //   //user.roleNames = [];
        //   //var _$roleCheckboxes = $("input[name='role']:checked");
        //    //if (_$roleCheckboxes) {
        //    //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
        //   //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
        //    //        user.roleNames.push(_$roleCheckbox.attr('data-role-name'));
        //    //    }
        //    //}

             abp.ui.setBusy(_$modal);
            _donorService.create(_donor).done(function () {
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

        function deleteDonor(DonorId, DonorName) {
            abp.message.confirm(
                "Delete Donor '" + DonorName + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _donorService.delete({
                            id: DonorId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();