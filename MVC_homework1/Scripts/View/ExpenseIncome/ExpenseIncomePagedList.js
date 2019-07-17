$(function () {
    var page = window.location.hash
        ? window.location.hash.slice(1)
        : 1;
    fetchPage(page);
});

var fetchPage = function (page) {
    var pagedPartialUrl = '/ExpenseIncome/List';

    $.get(pagedPartialUrl, { page: page }, function (data) {

        window.location.hash = page;

        $('#AccountData').html(data);

        $('#AccountData .pagination li a').each(function (i, item) {
            var hyperLinkUrl = $(item).attr('href');
            if (typeof hyperLinkUrl !== 'undefined' && hyperLinkUrl !== false) {
                var pageNumber = $(item).attr('href').replace('/ExpenseIncome/List?page=', '');;
                $(item).attr('href', '#').click(function (event) {
                    event.preventDefault();
                    $(event.target).attr('href');
                    fetchPage(pageNumber);
                });
            }
        });
    });
};