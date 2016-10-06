
$(document).ready(function () {
    document.getElementById("get-distance").onclick = callApi; // launches api query when button "Get disance" is clicked

    var _from;
    var _to;
    var _distance;
    var yourUrl; // contains url on which the api request will be done

    $('#From').on('input', function () {
        // Actions to take upon end of "From" input field
            _from = document.getElementById("From").value; // Assign input result into global variable "from"      
    });

    $('#To').on('input', function () {
        // Actions to take upon end of "To" input field
            _to = document.getElementById("To").value; // Assign input result into global variable "to"
    });   

    function callApi() // Api query for distance calculation
    { // insert the data entered above into our url
        yourUrl = 'http://calc-api.ru/app:geo-api/null?a=' + encodeURIComponent(_from) + '&b=' + encodeURIComponent(_to) ;

        function Get(yourUrl)
        { // Get query to url, returns JSON
            var Httpreq = new XMLHttpRequest(); // a new request
            Httpreq.open("GET",yourUrl,false);
            Httpreq.send(null);
            return Httpreq.responseText;
        }

        var json_obj = JSON.parse(Get(yourUrl)); // parsing the returned JSON               
         _distance = json_obj.distanse; // Assign parse result to globale variable "_distance" 

         document.getElementById("result-distance").innerHTML = 'Average distance: ' + _distance; // Writes down "_distance" variable value into the document
        return _distance;
    } 
});

function getConsumption() // TODO: gets the consumtion from input and passes it to the controller to process 
{
    var _cost = document.getElementById("Fuel_cost").value; // getting the values from input 
    var _consumption = document.getElementById("Consumption").value;

    var fuel_info = { // building json object to send 
        Consumption: _consumption,
        Cost: _cost
    }   
        $.ajax({
            url: '/Calc/CalculateCost', // ajax call to Action "CalculateCost" of Calc controller
            type: 'POST', // use Get for [HttpGet] action or POST for [HttpPost]
            data: JSON.stringify(fuel_info),
            contentType: "application/json; charset=utf-8", // what to send to server
            dataType: "json", // what to  get from server
           
            success: function (result) {
                console.log(result); // success : dealing with the result     
        }

    });
}
    







