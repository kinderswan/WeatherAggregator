/// <reference path="../typings/backbone/backbone.d.ts" />
var UrlConstants = (function () {
    function UrlConstants() {
    }
    UrlConstants.Hostname = "https://10.143.12.195:888/";
    UrlConstants.CityApiUrl = "api/location/getcities/";
    UrlConstants.CountryApiUrl = "api/location/getcountries/";
    UrlConstants.ImageApiUrl = "api/images/getimage/";
    UrlConstants.WeatherApiUrls = [
        "api/weather/wunderground/",
        "api/weather/openweathermap/"
    ];
    return UrlConstants;
}());
//# sourceMappingURL=UrlConstants.js.map