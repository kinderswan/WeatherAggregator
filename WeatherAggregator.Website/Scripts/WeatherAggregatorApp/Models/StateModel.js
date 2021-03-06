var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var StateModel = (function (_super) {
    __extends(StateModel, _super);
    function StateModel() {
        _super.apply(this, arguments);
    }
    StateModel.prototype.defaults = function () {
        return {
            StateCode: "",
            StateName: ""
        };
    };
    return StateModel;
}(Backbone.Model));
//# sourceMappingURL=StateModel.js.map