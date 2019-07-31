/// <reference path="../../../lib/jquery/dist/jquery.js" />

var loginController = function () {
    this.initialize = function () {
        registerEvents();
    };
   

    var registerEvents = function () {
        $('#btnLogin').on('click', function (e) {
            e.preventDefault();
            var user = $('#txtUserName').val();
            var password = $('#txtPassword').val();
            login(user, password);
        });
    };

    var login = function (username, password) {
        $.ajax({
            type: 'POST',
            data: {
                Email: username,
                Password: password
            },
            dataType: 'json',
            url: '/admin/login/authen',
            success: function (res) {
                if (res.Success) {
                    window.location.href = '/admin/home/index';
                } else {
                    utilities.notify('Đăng nhập không đúng', 'error');
                }
            }
        });
    };

};