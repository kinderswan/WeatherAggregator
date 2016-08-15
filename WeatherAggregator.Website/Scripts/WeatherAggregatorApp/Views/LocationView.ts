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
		var countriesCollection = new CountriesCollection();
		$("#wapp-location-countries").append('<select class="selectpicker" data-live-search="true" data-size="7"></select>');
		countriesCollection.fetch({
			success: function (model) {
				_.each(model.models, function (item: CountryModel) {
					$("#wapp-location-countries .selectpicker").append("<option>" + item.get("CountryName") + "</option>");
				});
			},
			error: function () {

			}
		});

	}
}