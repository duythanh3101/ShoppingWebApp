var productController =  function () {
    this.initialize =  function () {
        loadData();
        registerEvents();
    };

    var registerEvents = function () {
        $('#ddlShowPageSize').on('change', function () {
            utilities.configs.pageSize = $(this).val();
            utilities.configs.pageIndex = 1;
            loadData(true);
        });

        $('#btnSearch').on('click', function () {
            loadData();
        });
    };

    var loadData = function (isPageChanged) {
        var template = $('#tableTemplate').html();
        var render = '';
        $.ajax({
            type: 'GET',
            data: {
                categoryId: null,
                keyword: $('#txtKeyword').val(),
                page: utilities.configs.pageIndex,
                pageSize: utilities.configs.pageSize
            },
            url: '/Admin/Product/GetAllPaging',
            dataType: 'json',
            success: function (response) {
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Image: item.Image === null ? '<img src="/admin-side/images/user.png" width=40' : '<img src="' + item.Image + '" width=60 height=60/>',
                        CategoryName: item.ProductCategory.Name,
                        Price: utilities.formatNumber(item.Price, 0),
                        CreatedDate: utilities.dateTimeFormatJson(item.DateCreated),
                        Status: utilities.getStatus(item.Status)
                    });
                  
                });
                $('#lblTotalRecords').text(response.RowCount);
                if (render !== '') {
                    $('#tblContent').html(render);
                }
                wrapPaging(response.RowCount, function () {
                    loadData();
                }, isPageChanged);
            },
            error: function (status) {
                console.log(status);
                utilities.notify('Cannot loading data', 'error');
            }
        });
    };


    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / utilities.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, page) {
                utilities.configs.pageIndex = page;
                setTimeout(callBack(), 200);
            }
        });
    }
};