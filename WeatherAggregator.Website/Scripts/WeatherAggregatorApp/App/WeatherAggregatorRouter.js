/// <reference path="../../typings/backbone/backbone.d.ts" />
/// <reference path="../views/IndexPageView.ts" />
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
            "index": "indexRoute"
        };
        Backbone.Router.apply(this, arguments);
    }
    WeatherAggregatorRouter.prototype.indexRoute = function () {
        new IndexPageView();
    };
    return WeatherAggregatorRouter;
}(Backbone.Router));
var router = new WeatherAggregatorRouter();
Backbone.history.start();
//# sourceMappingURL=WeatherAggregatorRouter.js.map