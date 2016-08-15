var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var LocationView = (function (_super) {
    __extends(LocationView, _super);
    function LocationView(countryName, cityName, stateName) {
        _super.call(this);
        this.inputCountry = countryName;
        this.inputCity = cityName;
        this.inputState = stateName;
    }
    LocationView.prototype.render = function () {
        var countriesCollection = new CountriesCollection();
        $("#wapp-location-countries").append('<select class="selectpicker" data-live-search="true" data-size="7"></select>');
        countriesCollection.fetch({
            success: function (model) {
                _.each(model.models, function (item) {
                    $("#wapp-location-countries .selectpicker").append("<option>" + item.get("CountryName") + "</option>");
                });
            },
            error: function () {
            }
        });
    };
    return LocationView;
}(Backbone.View));
//# sourceMappingURL=LocationView.js.map