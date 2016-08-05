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
        this.renderCityImage("USA", "Salt LAke City");
        return {};
    };
    IndexPageView.prototype.renderCityImage = function (countryName, cityName) {
        var cityImage = new ImageModel(countryName + " " + cityName, 960);
        var self = this;
        cityImage.fetch({
            success: function (x) {
                $.get("Scripts/WeatherAggregatorApp/Templates/CityImageTemplate.html", function (data) {
                    var template = _.template(data);
                    var result = template({ model: x });
                    $("#wapp-city-image-placeHolder").append(result);
                }, "html");
            }
        });
    };
    IndexPageView.prototype.remove = function () {
        $("#wapp-city-image-content").remove();
    };
    return IndexPageView;
}(Backbone.View));
//# sourceMappingURL=IndexPageView.js.map