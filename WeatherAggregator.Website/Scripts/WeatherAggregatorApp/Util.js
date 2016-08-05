/// <reference path="../typings/backbone/backbone.d.ts" />
var Util = (function () {
    function Util() {
    }
    Util.Hostname = "http://10.143.12.170:555/";
    Util.CityApiUrl = "api/location/getcities/";
    Util.CountryApiUrl = "api/location/getcountries/";
    Util.ImageApiUrl = "api/images/getimage/";
    Util.WeatherApiUrls = [
        "api/weather/wunderground/",
        "api/weather/openweathermap/"
    ];
    return Util;
}());
//# sourceMappingURL=Util.js.map