var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var LocationView = (function (_super) {
    __extends(LocationView, _super);
    function LocationView() {
        _super.call(this);
        LocationView.defaultOptionValue = " -- select an option -- ";
    }
    LocationView.prototype.render = function () {
        LocationView.renderCountries();
    };
    LocationView.renderCountries = function () {
        LocationView.clearAllSelects(true);
        var countriesCollection = new CountriesCollection();
        var self = this;
        countriesCollection.fetch({
            success: function (model) {
                $("#wapp-location-countries")
                    .empty()
                    .append(self.templateBuilder(model, "CountryName"));
                $("#wapp-location-countries select").bind("change", model, LocationView.renderStates);
                if (LocationView.inputCountry !== "" || LocationView.inputCity !== LocationView.defaultOptionValue) {
                    $("#wapp-location-countries select").val(LocationView.inputCountry);
                    $("#wapp-location-countries select").trigger("change", model);
                }
            },
            error: function () {
                alert("Exception");
            }
        });
    };
    LocationView.renderStates = function (model) {
        LocationView.clearAllSelects(false);
        model.stopPropagation();
        var selectedCountry = $("#wapp-location-countries select").find(":selected").text();
        if (LocationView.inputCountry !== selectedCountry) {
            LocationView.inputState = "";
        }
        var result = _.find(model.data.models, function (item) {
            return item.get("CountryName") === selectedCountry;
        });
        if (result.get("States").length !== 0) {
            $("#wapp-location-states")
                .empty()
                .append(LocationView.statesTemplateBuilder(result.get("States")));
            $("#wapp-location-states select").bind("change", model, LocationView.renderCities);
            if (LocationView.inputState) {
                $("#wapp-location-states select").val(LocationView.inputState);
                $("#wapp-location-states select").trigger("change", model);
            }
        }
        else {
            LocationView.renderCities(model);
        }
    };
    LocationView.renderCities = function (model) {
        model.stopPropagation();
        var selectedCountry = $("#wapp-location-countries select").find(":selected").text();
        var selectedState = $("#wapp-location-states select").find(":selected").text();
        if (LocationView.inputCountry !== selectedCountry) {
            LocationView.inputCity = "";
        }
        if (LocationView.inputState !== selectedState && LocationView.inputState) {
            LocationView.inputCity = "";
        }
        var citiesCollection = new CitiesCollection(selectedCountry, selectedState);
        citiesCollection.fetch({
            success: function (model) {
                $("#wapp-location-cities")
                    .empty()
                    .append(LocationView.templateBuilder(model, "CityName"));
                $("#wapp-location-cities select").bind("change", LocationView.showWeather);
                if (LocationView.inputCity) {
                    $("#wapp-location-cities select").val(LocationView.inputCity);
                    $("#wapp-location-cities select").trigger("change");
                }
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
        htmlTemplate += "<option disabled selected value>" + LocationView.defaultOptionValue + "</option>";
        _.each(model.models, function (item) {
            htmlTemplate += "<option>" + item.get(parameterName) + "</option>";
        });
        htmlTemplate += "</select>";
        return htmlTemplate;
    };
    LocationView.statesTemplateBuilder = function (model) {
        var htmlTemplate = '<select class="form-control selectmargin">';
        htmlTemplate += "<option disabled selected value>" + LocationView.defaultOptionValue + "</option>";
        _.each(model, function (item) {
            htmlTemplate += "<option>" + item.StateName + "</option>";
        });
        htmlTemplate += "</select>";
        return htmlTemplate;
    };
    LocationView.clearAllSelects = function (clearStates) {
        if (clearStates) {
            $("#wapp-location-states").empty();
        }
        $("#wapp-location-cities").empty();
    };
    return LocationView;
}(Backbone.View));
//# sourceMappingURL=LocationView.js.map