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
        LocationView.renderCountries();
    };
    LocationView.renderCountries = function () {
        $("#wapp-location-states").empty();
        $("#wapp-location-cities").empty();
        var countriesCollection = new CountriesCollection();
        var self = this;
        countriesCollection.fetch({
            success: function (model) {
                $("#wapp-location-countries")
                    .empty()
                    .append(self.templateBuilder(model, "CountryName"))
                    .bind("change", model, LocationView.renderStates);
            },
            error: function () {
                alert("Exception");
            }
        });
    };
    LocationView.renderStates = function (model) {
        $("#wapp-location-cities").empty();
        var selectedCountry = $("#wapp-location-countries select").find(":selected").text();
        var result = _.find(model.data.models, function (item) {
            return item.get("CountryName") === selectedCountry;
        });
        if (result.get("States").length !== 0) {
            $("#wapp-location-states")
                .empty()
                .append(LocationView.statesTemplateBuilder(result.get("States")))
                .bind("change", LocationView.renderCities);
        }
        else {
            LocationView.renderCities();
        }
    };
    LocationView.renderCities = function () {
        var selectedCountry = $("#wapp-location-countries select").find(":selected").text();
        var selectedState = $("#wapp-location-states select").find(":selected").text();
        var citiesCollection = new CitiesCollection(selectedCountry, selectedState);
        citiesCollection.fetch({
            success: function (model) {
                $("#wapp-location-cities")
                    .empty()
                    .append(LocationView.templateBuilder(model, "CityName"))
                    .bind("change", LocationView.showWeather);
            },
            error: function () {
                alert("Exception");
            }
        });
    };
    LocationView.showWeather = function () {
        var selectedCountry = $("#wapp-location-countries select").find(":selected").text();
        var selectedState = $("#wapp-location-states select").find(":selected").text();
        var selectedCity = $("#wapp-location-cities select").find(":selected").text();
        if (selectedState !== "") {
            router.navigate(selectedCountry + "/" + selectedState + "/" + selectedCity, { trigger: true });
        }
        else {
            router.navigate(selectedCountry + "/" + selectedCity, { trigger: true });
        }
    };
    LocationView.templateBuilder = function (model, parameterName) {
        var htmlTemplate = '<select class="form-control selectmargin">';
        htmlTemplate += "<option disabled selected value> -- select an option -- </option>";
        _.each(model.models, function (item) {
            htmlTemplate += "<option>" + item.get(parameterName) + "</option>";
        });
        htmlTemplate += "</select>";
        return htmlTemplate;
    };
    LocationView.statesTemplateBuilder = function (model) {
        var htmlTemplate = '<select class="form-control selectmargin">';
        htmlTemplate += "<option disabled selected value> -- select an option -- </option>";
        _.each(model, function (item) {
            htmlTemplate += "<option>" + item.StateName + "</option>";
        });
        htmlTemplate += "</select>";
        return htmlTemplate;
    };
    return LocationView;
}(Backbone.View));
//# sourceMappingURL=LocationView.js.map