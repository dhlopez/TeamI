$(document).ready(function () {


    $("#circle1").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        text: "Pending",
        foregroundColor: "purple"
    });
    $("#circle2").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        text: "Overdue",
        foregroundColor: "orange"
    });
    $("#circle3").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        text: "Pass Rate",
        foregroundColor: "Red",
        decimals: 2
    });
});