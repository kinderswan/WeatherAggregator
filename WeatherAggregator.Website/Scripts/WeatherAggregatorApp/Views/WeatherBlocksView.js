var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var WeatherBlocksView = (function (_super) {
    __extends(WeatherBlocksView, _super);
    function WeatherBlocksView(countryName, cityName, stateName) {
        _super.call(this);
        this.inputCountry = countryName;
        this.inputCity = cityName;
        this.inputState = stateName;
    }
    WeatherBlocksView.prototype.events = function () {
        return {};
    };
    WeatherBlocksView.prototype.render = function () {
        var weatherCollection = new WeatherCollection(this.inputCountry, this.inputCity, this.inputState);
        weatherCollection.customFetch(function (weatherModel) {
            $.get("Scripts/WeatherAggregatorApp/Templates/WeatherInfoBlockTemplate.html", function (data) {
                var template = _.template(data);
                var result = template({
                    model: weatherModel
                });
                $("#wapp-weather-info-row").append(result);
            }, "html");
        });
    };
    return WeatherBlocksView;
}(Backbone.View));
//# sourceMappingURL=WeatherBlocksView.js.map