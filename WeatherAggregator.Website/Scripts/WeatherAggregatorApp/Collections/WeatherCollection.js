/// <reference path="../models/WeatherModel.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var WeatherCollection = (function (_super) {
    __extends(WeatherCollection, _super);
    function WeatherCollection(countryName, cityName, stateName) {
        _super.call(this);
        this.countryName = countryName;
        this.cityName = cityName;
        this.stateName = stateName;
    }
    WeatherCollection.prototype.customFetch = function () {
        for (var i = 0; i < Util.WeatherApiUrls.length; i++) {
            var weatherModel = new WeatherModel(this.buildUrl(Util.WeatherApiUrls[i]));
            weatherModel.fetch();
            this.add(weatherModel);
        }
    };
    WeatherCollection.prototype.buildUrl = function (uri) {
        return this.stateName === undefined
            ? Util.Hostname + uri + this.countryName + "/" + this.cityName
            : Util.Hostname + uri + this.countryName + "/" + this.stateName + "/" + this.cityName;
    };
    return WeatherCollection;
}(Backbone.Collection));
//# sourceMappingURL=WeatherCollection.js.map