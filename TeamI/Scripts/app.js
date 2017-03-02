var ViewModel = function () {
    var self = this;
    //inspection
    self.inspections = ko.observableArray();
    self.error = ko.observable();

    //details
    self.detail = ko.observableArray();

    var inspUri = '/INSPECTIONs/LoadIns';
    var insDetUri = '/INSPECTIONs/LoadInsDet/';

    //function ajaxHelper(uri, method, data) {
    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            //url: uri,
            url: uri,
            //async: false,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllInspections() {
        ajaxHelper(inspUri, 'GET').done(function (data) {
            self.inspections(data);
        });
    }

    self.getInspectionDetails = function (item) {
        ajaxHelper(insDetUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    // Fetch the initial data.
    getAllInspections();
};

ko.applyBindings(new ViewModel());