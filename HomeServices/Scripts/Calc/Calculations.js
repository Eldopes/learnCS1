
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


    var consumption;
    function getConsumption() // TODO: gets the consumtion from input and passes it to the controller to process 
    { 
        consumption = 35;
        alert("a");

        $.ajax({
            url: '@Url.Action("CalculateCost","Calc")', // ajax call to Action "CalculateCost" of Calc controller
            type: 'POST', // use Get for [HttpGet] action or POST for [HttpPost]
            data: consumption, // no need to stringify
            success: function (result) {
                if (result == true) {
                    // window.location = "/Dashboard";
                    alert("success");
                } else {
                    // $QuickLoginErrors.text(result);
                    alert("fail");
                }
            }
        });

        
     }


    

});
    







