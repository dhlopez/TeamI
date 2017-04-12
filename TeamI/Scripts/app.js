var ViewModel = function () {
    var self = this;
    //inspection
    self.inspections = ko.observableArray();
    self.error = ko.observable();
    self.insIDAfterSave = ko.observable();

    //details
    self.detail = ko.observableArray();

    //hazardsobserved
    self.hazobs = ko.observableArray();

    //empty space and all fields to add new ins, det and hazs
    self.allInfo = ko.observableArray();
    self.areas = ko.observableArray();
    self.hazObsSec = ko.observableArray();

    //properties for dropdownlists
    self.labs = ko.observableArray();
    self.users = ko.observableArray();
    self.hazards = ko.observableArray();

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
        //Comments: ko.observable(),
        urgentAction: ko.observable(),
        problemFound: ko.observable(),
        actionRequired: ko.observable(),
        Status: ko.observable()
    }

    var inspUri = '/INSPECTIONs/LoadIns';
    var insDetUri = '/INSPECTIONs/LoadInsDet/';
    var hazUri = '/INSPECTIONs/HazObs/';
    var labsUri = '/INSPECTIONs/LoadLabs/';
    var usersUri = '/INSPECTIONs/LoadUsers/';
    var hazardsUri = '/INSPECTIONs/LoadHazards/';

    //creates
    var newInsUri = '/INSPECTIONs/CreatePost/';
    var newInsDetUri = '/INSPECTIONs/CreateDetailPost/';
    var newHazardObsUri = '/INSPECTIONs/CreateHazardObsPost/';
    
    

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
    function getHazards() {
        ajaxHelper(hazardsUri, 'GET').done(function (data) {
            self.hazards(data);
        });
    }
    

    self.addInspection = function (formElement) {
        //console.info(self.newInspection.Date());
        var inspec = {
            date: self.newInspection.Date(),
            labID: self.newInspection.Lab().ID,
            userID: self.newInspection.User().ID,
            status: self.newInspection.Status()
        };
        /*
        ajaxHelper(newInsUri, 'POST', inspec).done(function (item) {
            self.inspections.push(item);
        });
        */
        ajaxHelper(newInsUri, 'POST', inspec).done(function (item) {
            self.newInspectionDet.InspectionNo = item.Id;
            //console.info(item.Id);
            self.allInfo.push(item);
        });
    }
    self.addInspectionDetail = function (formElement) {
        var inspecDet = {
            InspectionID: self.newInspectionDet.InspectionNo,
            /*UserID: self.newInspectionDet.User().ID,
            Date: self.newInspectionDet.Date,*/
            AreaEquipment: self.newInspectionDet.AreaEquip()
        };        
        ajaxHelper(newInsDetUri, 'POST', inspecDet).done(function (item) {
            self.newHazardObs.InspectionDetNo = item.Id;
            self.areas.push(item);
        });
    }
    self.addHazardObserved = function (formElement) {
        //console.info(self.newInspectionDet.AreaEquip());
        var hazObsRow = {
            InspectionDetailID: self.newHazardObs.InspectionDetNo,
            HazardID: self.newHazardObs.Hazard().ID,
            UrgentAction: self.newHazardObs.urgentAction(),
            ProblemFound: self.newHazardObs.problemFound(),
            ActionRequired: self.newHazardObs.actionRequired()
            //Comments: self.newHazardObs.Comments(),
            //Status: self.newHazardObs.Status()

            /*UserID: self.newInspectionDet.User().ID,
            Date: self.newInspectionDet.Date,*/
        };
        console.info(self.newHazardObs.urgentAction());
        ajaxHelper(newHazardObsUri, 'POST', hazObsRow).done(function (item) {
            self.hazObsSec.push(item);
        });
    }

    // Fetch the initial data.
    getAllInspections();
    getLabs();
    getUsers();
    getHazards();
};

ko.applyBindings(new ViewModel());