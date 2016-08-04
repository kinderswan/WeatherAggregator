/// <reference path="../../typings/backbone/backbone.d.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var WeatherModel = (function (_super) {
    __extends(WeatherModel, _super);
    function WeatherModel() {
        _super.apply(this, arguments);
    }
    WeatherModel.prototype.defaults = function () {
        return {
            temperature: 0,
            humidity: "",
            windSpeed: 0,
            windDegrees: 0,
            feelslike: "",
            country: "",
            state: "",
            city: ""
        };
    };
    WeatherModel.prototype.initialize = function () {
        var util = new Util();
    };
    WeatherModel.prototype.clear = function () {
        this.destroy();
    };
    return WeatherModel;
}(Backbone.Model));
//# sourceMappingURL=WeatherModel.js.map