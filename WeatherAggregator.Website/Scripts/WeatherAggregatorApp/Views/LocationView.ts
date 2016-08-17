class LocationView extends Backbone.View<Backbone.Model> {

	public static inputCountry: string;
	public static inputState: string;
	public static inputCity: string;

	private static defaultOptionValue: string;

	constructor() {
		super();
		LocationView.defaultOptionValue = " -- select an option -- ";
	}

	render(): any {
		LocationView.renderCountries();
	}

	private static renderCountries(): void {
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
	}

	private static renderStates(model): any {
		LocationView.clearAllSelects(false);
		model.stopPropagation();
		var selectedCountry: string = $("#wapp-location-countries select").find(":selected").text();

		if (LocationView.inputCountry !== selectedCountry) {
			LocationView.inputState = "";
		}

		var result = _.find(model.data.models, function (item: any) {
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
		} else {
			LocationView.renderCities(model);
		}
	}

	private static renderCities(model): any {
		model.stopPropagation();
		var selectedCountry: string = $("#wapp-location-countries select").find(":selected").text();
		var selectedState: string = $("#wapp-location-states select").find(":selected").text();

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
		htmlTemplate += "<option disabled selected value>" + LocationView.defaultOptionValue + "</option>";
		_.each(model.models, function (item: any) {
			htmlTemplate += "<option>" + item.get(parameterName) + "</option>";
		});
		htmlTemplate += "</select>";
		return htmlTemplate;
	}

	private static statesTemplateBuilder(model: any): string {
		var htmlTemplate: string = '<select class="form-control selectmargin">';
		htmlTemplate += "<option disabled selected value>" + LocationView.defaultOptionValue + "</option>";
		_.each(model, function (item: any) {
			htmlTemplate += "<option>" + item.StateName + "</option>";
		});
		htmlTemplate += "</select>";
		return htmlTemplate;
	}

	private static clearAllSelects(clearStates: boolean) {
		if (clearStates) {
			$("#wapp-location-states").empty();
		}
		$("#wapp-location-cities").empty();
	}

}