var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var CitiesCollection = (function (_super) {
    __extends(CitiesCollection, _super);
    function CitiesCollection(countryName, stateName) {
        _super.call(this);
        this.url = this.createUrl(countryName, stateName);
    }
    CitiesCollection.prototype.defaults = function () {
        return {
            Cities: typeof CityModel
        };
    };
    CitiesCollection.prototype.createUrl = function (countryName, stateName) {
        return stateName === undefined
            ? Util.Hostname + Util.CityApiUrl + countryName
            : Util.Hostname + Util.CityApiUrl + countryName + "/" + stateName;
    };
    return CitiesCollection;
}(Backbone.Collection));
(function () {
    var col = new CitiesCollection("Belarus");
    col.fetch({
        success: function (x) {
            console.log(x);
        }
    });
})();
//# sourceMappingURL=CitiesCollection.js.map