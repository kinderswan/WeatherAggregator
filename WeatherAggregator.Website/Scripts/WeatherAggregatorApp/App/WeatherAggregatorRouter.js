/// <reference path="../../typings/backbone/backbone.d.ts" />
/// <reference path="../views/IndexPageView.ts" />
/// <reference path="../../utilgeolocation.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var WeatherAggregatorRouter = (function (_super) {
    __extends(WeatherAggregatorRouter, _super);
    function WeatherAggregatorRouter(options) {
        _super.call(this, options);
        this.routes = {
            "": "indexRoute",
            "(:country)/(:city)": "weatherRoute"
        };
        Backbone.Router.apply(this, arguments);
    }
    WeatherAggregatorRouter.prototype.indexRoute = function () {
        var coords = new UtilGeolocation();
        navigator.geolocation.getCurrentPosition(function (location) {
            coords.codeLatLng(location.coords.latitude, location.coords.longitude);
        });
    };
    WeatherAggregatorRouter.prototype.weatherRoute = function (country, city) {
        if (this.indexPageView !== undefined) {
            this.indexPageView.remove();
        }
        this.indexPageView = new IndexPageView();
        this.indexPageView.renderCityImage(country, city);
    };
    return WeatherAggregatorRouter;
}(Backbone.Router));
var router = new WeatherAggregatorRouter();
Backbone.history.start();
//# sourceMappingURL=WeatherAggregatorRouter.js.map