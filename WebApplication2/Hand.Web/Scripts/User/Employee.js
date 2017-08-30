var app = angular.module('app', ['ui.grid', 'ui.grid.selection', 'ui.grid.resizeColumns', 'ui.grid.pagination']);
app.config(function ($provide) {
    $provide.decorator('GridOptions', ['$delegate', 'i18nService', function ($delegate, i18NService) {
        var gridOptions = angular.copy($delegate);
        gridOptions.initialize = function (options) {
            var initOptions = $delegate.initialize(options);
            return initOptions;
        };
        i18NService.setCurrentLang('zh-cn');
        return gridOptions;
    }]);
});

app.controller('MainCtrl', function ($scope) {
    var employee = "";
    $.ajax({
        url: "http://10.211.53.211:1314/user/getEmp",
        type:"get",
        async: false,
        success: function (data) {
            employee = data;
        },
        error: function (data) {
            alert("数据获取失败");
        }
    });

    $scope.gridOptions = {
        enablePaginationControls: false,
        rowHeight: 60,
        paginationPageSize: 20,
        columnDefs:
        [
            { "field": "EmpId", "display": "none", visible: false },
            { "field": "EmpNo", "name": "员工工号" },
            { "field": "EmpName", "name": "员工姓名" },
            { "field": "EmpEmail", "name": "电子邮件", cellTooltip: function (row) { return 'Email: ' + row.entity.EmpEmail } },
            { "field": "EmpMobile", "name": "手机号码" },
            { "field": "EmpJoinTime", "name": "入职日期" },
            { "field": "EmpWorkAddress", "name": "工作地点", cellTooltip: function (row) { return 'Address: ' + row.entity.EmpWorkAddress } },
            { "field": "EmpRoleName", "name": "岗位职责" },
            { "field": "EmpIsValid", "name": "是否在职" },
            { "field": "EmpDeptName", "name": "所在部门" }
        ],
        data: employee
    };

    $scope.gridOptions.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    };

    //输入框数值限制
    $scope.maxpage = function () {
        if ($scope.page * $scope.gridOptions.paginationPageSize > $scope.gridOptions.data.count)
            $scope.page = Math.floor($scope.gridOptions.data.length / $scope.gridOptions.paginationPageSize) + 1;
        if ($scope.page <= 0) {
            $scope.page = 1;
            $scope.gridApi.pagination.seek(1);
        }
    };

    //上一页的限制
    $scope.pp = function () {
        if ($scope.page > 1)
            $scope.page = $scope.page - 1;
    }

    //下一页限制
    $scope.np = function () {
        if ($scope.page * $scope.gridOptions.paginationPageSize < $scope.gridOptions.data.length)
            $scope.page = $scope.page + 1;
    }
});