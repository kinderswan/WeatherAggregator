var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var CityModel = (function (_super) {
    __extends(CityModel, _super);
    function CityModel() {
        _super.apply(this, arguments);
    }
    CityModel.prototype.defaults = function () {
        return {
            CityName: "",
            CountryName: "",
            StateName: ""
        };
    };
    return CityModel;
}(Backbone.Model));
//# sourceMappingURL=CityModel.js.map