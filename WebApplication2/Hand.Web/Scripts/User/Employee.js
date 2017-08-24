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
    $scope.gridOptions = {
        enablePaginationControls: false,
        rowHeight: 60,
        paginationPageSize: 20,
        columnDefs:
        [
            //{ "field": "Id", "name": "系统序号", "width": 120 },
            //{ "field": "Name", "name": "名称" },
            //{ "field": "Description", "name": "描述" },
            //{ "field": "Button", "name": "编辑/添加组件", cellTemplate: '<div><input class="btnOpreation" type="Button" value="编辑" ng-click="grid.appScope.clearAll(row.entity);"></input><input id="btnConfig" type="Button" value="配置组件" ng-click="grid.appScope.webPartConfig(row.entity);"></input></div>' }
            { "field": "EmpNo", "name": "员工工号" },
            { "field": "EmpName", "name": "员工姓名" },
            { "field": "EmpGender", "name": "性别" },
            { "field": "EmpDept", "name": "部门" },
            { "field": "", "name": "" },
            { "field": "", "name": "" },
            { "field": "", "name": "" },
            { "field": "", "name": "" },
            { "field": "", "name": "" },
            { "field": "", "name": "" },
            { "field": "", "name": "" },
            { "field": "", "name": "" },
            { "field": "", "name": "" },
            { "field": "", "name": "" },
            { "field": "", "name": "" }
        ],
        data: ""
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