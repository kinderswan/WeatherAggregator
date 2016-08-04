/// <reference path="../models/WeatherModel.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var WeatherCollection = (function (_super) {
    __extends(WeatherCollection, _super);
    function WeatherCollection() {
        _super.apply(this, arguments);
        this.model = WeatherModel;
    }
    return WeatherCollection;
}(Backbone.Collection));
//# sourceMappingURL=WeatherCollection.js.map