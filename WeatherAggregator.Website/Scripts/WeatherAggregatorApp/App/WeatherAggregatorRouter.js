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
            "(:country)/(:city)": "weatherRoute",
            "(:country)/(:state)/(:city)": "weatherStateRoute"
        };
        Backbone.Router.apply(this, arguments);
        this.locationView = new LocationView();
        this.locationView.render();
    }
    WeatherAggregatorRouter.prototype.indexRoute = function () {
        var coords = new UtilGeolocation();
        navigator.geolocation.getCurrentPosition(function (location) {
            coords.codeLatLng(location.coords.latitude, location.coords.longitude);
        });
    };
    WeatherAggregatorRouter.prototype.weatherRoute = function (country, city) {
        LocationView.inputCountry = country;
        LocationView.inputCity = city;
        this.indexPageView = new IndexPageView(country, city);
        this.indexPageView.remove();
        this.indexPageView.render();
    };
    WeatherAggregatorRouter.prototype.weatherStateRoute = function (country, state, city) {
        LocationView.inputCountry = country;
        LocationView.inputCity = city;
        LocationView.inputState = state;
        this.indexPageView = new IndexPageView(country, city, state);
        this.indexPageView.remove();
        this.indexPageView.render();
    };
    return WeatherAggregatorRouter;
}(Backbone.Router));
var router = new WeatherAggregatorRouter();
Backbone.history.start();
//# sourceMappingURL=WeatherAggregatorRouter.js.map