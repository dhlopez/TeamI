$(document).ready(function () {


    $("#circle1").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        noPercentageSign: 1,
        text: "Pending",
        foregroundColor: "Blue"
    });
    $("#circle2").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        noPercentageSign:1,
        text: "Overdue",
        foregroundColor: "orange"
    });
    $("#circle3").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        text: "Pass Rate",
        foregroundColor: "Green",
        decimals:2
    });
});