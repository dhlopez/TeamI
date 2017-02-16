$(document).ready(function () {

    $('#linkIncrease').click(function () {
        //alert("Increase");
        modifyFontSize('increase');
    });

    $('#linkDecrease').click(function () {
        //alert("Decrease");
        modifyFontSize('decrease');
    });

    $('#linkReset').click(function () {
        //alert("Reset");
        modifyFontSize('reset');
    })

    function modifyFontSize(direction) {
        var divElement = $('body');
        var currentFontSize = parseInt(divElement.css('font-size'));
        var circles = $(document.getElementById("dataCircles"));

        if (direction == 'increase') {
            currentFontSize += 3;
            if (currentFontSize >= 30) {
                currentFontSize = 30;
            }
        }
            
        else if (direction == 'decrease') {
            currentFontSize -= 3;
            if (currentFontSize <= 10) {
                currentFontSize = 10;
            }
        }          
        else
            currentFontSize = 14;

        circles.css('font-size', 14);
        divElement.css('font-size', currentFontSize);
    }
});