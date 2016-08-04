var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var WeatherModel = (function (_super) {
    __extends(WeatherModel, _super);
    function WeatherModel(url) {
        _super.call(this);
        this.url = url;
    }
    WeatherModel.prototype.defaults = function () {
        return {
            Temperature: 0,
            Humidity: "",
            WindSpeed: 0,
            WindDegrees: 0,
            Feelslike: "",
            Country: "",
            State: "",
            City: ""
        };
    };
    return WeatherModel;
}(Backbone.Model));
//# sourceMappingURL=WeatherModel.js.map