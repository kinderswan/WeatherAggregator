class CitiesCollection extends Backbone.Collection<CityModel> {

	constructor(countryName: string, stateName?: string) {
		super();
		this.url = this.createUrl(countryName, stateName);

	}

	defaults() {
		return {
			Cities: typeof CityModel
		}
	}

	url: string;


	private createUrl(countryName: string, stateName?: string) {
		return stateName === undefined
			? Util.Hostname + Util.CityApiUrl + countryName
			: Util.Hostname + Util.CityApiUrl + countryName + "/" + stateName;
	}
}

(function () {
	var col = new CitiesCollection("Belarus");
	col.fetch({
		success: function(x) {
			console.log(x);
		}
	});

})()