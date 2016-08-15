var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var IndexPageView = (function (_super) {
    __extends(IndexPageView, _super);
    function IndexPageView() {
        _super.call(this);
        //this.render();
    }
    IndexPageView.prototype.events = function () {
        return {};
    };
    IndexPageView.prototype.render = function () {
        this.renderCityImage();
        return {};
    };
    IndexPageView.prototype.renderCityImage = function (countryName, cityName) {
        var cityImage = new ImageModel(countryName + " " + cityName, 960);
        var self = this;
        cityImage.fetch({
            success: function (image) {
                $.get("Scripts/WeatherAggregatorApp/Templates/CityImageTemplate.html", function (data) {
                    var template = _.template(data);
                    var result = template({ model: image });
                    $("#wapp-city-image-placeHolder").append(result);
                    self.renderWeatherBlocks(countryName, cityName);
                }, "html");
            }
        });
    };
    IndexPageView.prototype.renderWeatherBlocks = function (countryName, cityName) {
        var weatherCollection = new WeatherCollection(countryName, cityName);
        weatherCollection.customFetch(function (weatherModel) {
            $.get("Scripts/WeatherAggregatorApp/Templates/WeatherInfoBlockTemplate.html", function (data) {
                var template = _.template(data);
                var result = template({ model: weatherModel });
                $("#wapp-weather-info-row").append(result);
            }, "html");
        });
    };
    IndexPageView.prototype.remove = function () {
        $("#wapp-city-image-content").remove();
        $(".wapp-weather-info-block-class").remove();
    };
    return IndexPageView;
}(Backbone.View));
//# sourceMappingURL=IndexPageView.js.map