/// <reference path="../../typings/backbone/backbone.d.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var WeatherInfo = (function (_super) {
    __extends(WeatherInfo, _super);
    function WeatherInfo() {
        _super.call(this);
    }
    Object.defineProperty(WeatherInfo.prototype, "CityName", {
        get: function () {
            return this.cityName;
        },
        set: function (value) {
            this.cityName = value;
        },
        enumerable: true,
        configurable: true
    });
    return WeatherInfo;
}(Backbone.Model));
//# sourceMappingURL=weatherInfo.js.map