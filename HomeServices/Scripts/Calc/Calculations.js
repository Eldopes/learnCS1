/*
    Calulation client-side logic
*/

var _from;
var _to;
var _distance;
var yourUrl;  // contains url on which the api request will be done

$(document).ready(function () {

    $('#Distance').on('input', function () { // on the end of input, distance gets reassigned 
        _distance = document.getElementById("Distance").value; // Assign input result into global variable "_distance"      
    });

    document.getElementById("get-distance").onclick = callApi; // launches api query when button "Get disance" is clicked    
});

function callApi() // Api query for distance calculation
{ // insert the data entered above into our url
    _from = document.getElementById("From").value; // Assign input result into global variable "from" 
    _to = document.getElementById("To").value; // Assign input result into global variable "to"
    yourUrl = 'http://calc-api.ru/app:geo-api/null?a=' + encodeURIComponent(_from) + '&b=' + encodeURIComponent(_to);

    function Get(yourUrl) { // Get query to url, returns JSON
        var Httpreq = new XMLHttpRequest(); // a new request
        Httpreq.open("GET", yourUrl, false);
        Httpreq.send(null);
        return Httpreq.responseText;
    }

    var json_obj = JSON.parse(Get(yourUrl)); // parsing the returned JSON               
    _distance = json_obj.distanse; // Assign parse result to globale variable "_distance" 

    document.getElementById("result-distance").innerHTML = 'Average distance: ' + _distance; // Writes down "_distance" variable value into the document
    return _distance;
}

function getConsumption() 
{
    var _cost = document.getElementById("Fuel_cost").value; // getting the values from input 
    var _consumption = document.getElementById("Consumption").value;
    if (!_distance)
        {
            _distance = document.getElementById("Distance").value;
        }

    var fuel_info = { // building json object to send 
        Consumption: _consumption,
        Cost: _cost,
        Distance: _distance // _distance is already received by callApi() function
    }   
        $.ajax({
            url: '/Calc/GetCost', // ajax call to Action "CalculateCost" of Calc controller
            type: 'POST', // use Get for [HttpGet] action or POST for [HttpPost]
            data: JSON.stringify(fuel_info),
            contentType: "application/json; charset=utf-8", // what to send to server
            dataType: "json", // what to  get from server
           
            success: function (result) {
               document.getElementById("result-final").innerHTML = 'Total trip cost: ' + result; 
                // TODO: write the result to html 
        }
    });  
}
    







