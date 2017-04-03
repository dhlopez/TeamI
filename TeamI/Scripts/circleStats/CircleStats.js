$(document).ready(function () {
    $("#circle1").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        text: "Passed",
        backgroundcolor: "#1a1a1a",
        foregroundColor: "Green"
    });

    $("#circle2").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,
        text: "Failed",
        foregroundColor: "Red"
    });

    $("#circle3").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,

        text: "Total",
        foregroundColor: "#0073cf"
    });
    $("#circle4").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,

        text: "Pending",
        foregroundColor: "purple"
    });
    $("#circle5").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,

        text: "Complete",
        foregroundColor: "lime"
    });
    $("#circle6").circliful({
        animationStep: 5,
        foregroundBorderWidth: 5,
        backgroundBorderWidth: 15,

        text: "Overdue",
        foregroundColor: "orange"
    });
});