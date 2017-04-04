$(document).ready(function () {

    $("#circle1").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        text: "Complete",
        foregroundColor: "lime"
    });
    $("#circle2").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,

        text: "Pending",
        foregroundColor: "purple"
    });
    $("#circle3").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,

        text: "Overdue",
        foregroundColor: "orange"
    });
    $("#circle4").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        text: "Failed",
        foregroundColor: "Red"
    });
});