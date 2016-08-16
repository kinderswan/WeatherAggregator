class LocationView extends Backbone.View<Backbone.Model> {

	private inputCountry: any;
	private inputState: any;
	private inputCity: any;

	constructor(countryName?: string, cityName?: string, stateName?: string) {
		super();
		this.inputCountry = countryName;
		this.inputCity = cityName;
		this.inputState = stateName;
	}

	render(): any {
		LocationView.renderCountries();
	}

	private static renderCountries(): void {
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
	}

	private static renderStates(model): any {
		$("#wapp-location-cities").empty();
		var selectedCountry: string = $("#wapp-location-countries select").find(":selected").text();
		var result = _.find(model.data.models, function (item: any) {
			return item.get("CountryName") === selectedCountry;
		});

		if (result.get("States").length !== 0) {
			$("#wapp-location-states")
				.empty()
				.append(LocationView.statesTemplateBuilder(result.get("States")))
				.bind("change", LocationView.renderCities);
		} else {
			LocationView.renderCities();
		}
	}

	private static renderCities(): any {
		var selectedCountry: string = $("#wapp-location-countries select").find(":selected").text();
		var selectedState: string = $("#wapp-location-states select").find(":selected").text();

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
	}

	private static showWeather() {
		var selectedCountry: string = $("#wapp-location-countries select").find(":selected").text();
		var selectedState: string = $("#wapp-location-states select").find(":selected").text();
		var selectedCity: string = $("#wapp-location-cities select").find(":selected").text();

		if (selectedState !== "") {
			router.navigate(selectedCountry + "/" + selectedState + "/" + selectedCity, { trigger: true });
		} else {
			router.navigate(selectedCountry + "/" + selectedCity, { trigger: true });
		}
	}

	private static templateBuilder(model: any, parameterName: string): string {
		var htmlTemplate: string = '<select class="form-control selectmargin">';
		htmlTemplate += "<option disabled selected value> -- select an option -- </option>";
		_.each(model.models, function (item: any) {
			htmlTemplate += "<option>" + item.get(parameterName) + "</option>";
		});
		htmlTemplate += "</select>";
		return htmlTemplate;
	}

	private static statesTemplateBuilder(model: any): string {
		var htmlTemplate: string = '<select class="form-control selectmargin">';
		htmlTemplate += "<option disabled selected value> -- select an option -- </option>";
		_.each(model, function (item: any) {
			htmlTemplate += "<option>" + item.StateName + "</option>";
		});
		htmlTemplate += "</select>";
		return htmlTemplate;
	}
}