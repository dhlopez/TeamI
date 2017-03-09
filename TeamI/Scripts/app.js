var ViewModel = function () {
    var self = this;
    //inspection
    self.inspections = ko.observableArray();
    self.error = ko.observable();

    //details
    self.detail = ko.observableArray();

    //hazardsobserved
    self.hazobs = ko.observableArray();

    //empty space
    self.allInfo = ko.observableArray();

    //properties for dropdownlists
    self.labs = ko.observableArray();
    self.users = ko.observableArray();

    self.newInspection = {
        Date: ko.observable(),
        Lab: ko.observable(),
        User: ko.observable(),
        Status: ko.observable()
    }
    self.newInspectionDet = {
        InspectionNo: ko.observable(),
        User: ko.observable(),
        Date: ko.observable(),
        AreaEquip: ko.observable()
    }
    self.newHazardObs = {
        InspectionDetNo: ko.observable(),
        Hazard: ko.observable(),
        Comments: ko.observable(),
        Status: ko.observable()
    }

    var inspUri = '/INSPECTIONs/LoadIns';
    var insDetUri = '/INSPECTIONs/LoadInsDet/';
    var hazUri = '/INSPECTIONs/HazObs/';
    var newInsUri = '/INSPECTIONs/CreatePost/';
    var labsUri = '/INSPECTIONs/LoadLabs/';
    var usersUri = '/INSPECTIONs/LoadUsers/';

    

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

    self.getHazardsObserved = function (item) {
        ajaxHelper(hazUri + item.Id, 'GET').done(function (data) {
            self.hazobs(data);
        });
    }

    function getLabs() {
        ajaxHelper(labsUri, 'GET').done(function (data) {
            self.labs(data);
        });
    }
    function getUsers() {
        ajaxHelper(usersUri, 'GET').done(function (data) {
            self.users(data);
        });
    }
    

    self.addInspection = function (formElement) {
        console.info(self.newInspection.Date());
        var inspec = {
            date: self.newInspection.Date(),
            labID: self.newInspection.Lab().ID,
            userID: self.newInspection.User().ID,
            status: self.newInspection.Status
        };
        /*
        ajaxHelper(newInsUri, 'POST', inspec).done(function (item) {
            self.inspections.push(item);
        });
        */
        ajaxHelper(newInsUri, 'POST', inspec).done(function (item) {
            self.allInfo.push(item);
        });
    }

    // Fetch the initial data.
    getAllInspections();
    getLabs();
    getUsers();
    /*
    self.addInspectionDet = new function (formElement) {

    }
    self.addHazardObs = new function (formElement) {

    }
    */
    
};

ko.applyBindings(new ViewModel());