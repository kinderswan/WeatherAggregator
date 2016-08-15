var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ImageView = (function (_super) {
    __extends(ImageView, _super);
    function ImageView(countryName, cityName, stateName) {
        _super.call(this);
        this.inputCountry = countryName;
        this.inputCity = cityName;
        this.inputState = stateName;
        this.weatherblocksView = new WeatherBlocksView(countryName, cityName, stateName);
        //this.render();
    }
    ImageView.prototype.events = function () {
        return {};
    };
    ImageView.prototype.render = function () {
        var cityImage = new ImageModel(this.inputCountry + " " + this.inputCity, 960);
        var self = this;
        cityImage.fetch({
            success: function (image) {
                $.get("Scripts/WeatherAggregatorApp/Templates/CityImageTemplate.html", function (data) {
                    var template = _.template(data);
                    var result = template({
                        model: image,
                        countryName: self.inputCountry,
                        cityName: self.inputCity
                    });
                    $("#wapp-city-image-placeHolder").append(result);
                    self.weatherblocksView.render();
                }, "html");
            }
        });
    };
    return ImageView;
}(Backbone.View));
//# sourceMappingURL=ImageView.js.map