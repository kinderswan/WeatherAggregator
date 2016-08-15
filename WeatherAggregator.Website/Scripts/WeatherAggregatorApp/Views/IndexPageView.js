var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var IndexPageView = (function (_super) {
    __extends(IndexPageView, _super);
    function IndexPageView(countryName, cityName, stateName) {
        _super.call(this);
        this.inputCountry = countryName;
        this.inputState = stateName;
        this.inputCity = cityName;
        this.locationView = new LocationView(countryName, cityName, stateName);
        this.imageView = new ImageView(countryName, cityName, stateName);
    }
    IndexPageView.prototype.render = function () {
        this.locationView.render();
        this.imageView.render();
    };
    IndexPageView.prototype.remove = function () {
        $("#wapp-city-image-content").remove();
        $("#wapp-city-image-description").remove();
        $("#wapp-location-countries").remove();
        $(".wapp-weather-info-block-class").remove();
    };
    return IndexPageView;
}(Backbone.View));
//# sourceMappingURL=IndexPageView.js.map