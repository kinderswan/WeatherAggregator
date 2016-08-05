var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var CitiesCollection = (function (_super) {
    __extends(CitiesCollection, _super);
    function CitiesCollection(countryName, stateName) {
        _super.call(this);
        this.url = this.buildUrl(countryName, stateName);
    }
    CitiesCollection.prototype.buildUrl = function (countryName, stateName) {
        return stateName === undefined
            ? UrlConstants.Hostname + UrlConstants.CityApiUrl + countryName
            : UrlConstants.Hostname + UrlConstants.CityApiUrl + countryName + "/" + stateName;
    };
    return CitiesCollection;
}(Backbone.Collection));
//# sourceMappingURL=CitiesCollection.js.map