var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var CountryModel = (function (_super) {
    __extends(CountryModel, _super);
    function CountryModel() {
        _super.apply(this, arguments);
    }
    CountryModel.prototype.defaults = function () {
        return {
            CountryCode: "",
            CountryName: "",
            States: new StateModel()
        };
    };
    return CountryModel;
}(Backbone.Model));
//# sourceMappingURL=CountryModel.js.map