class CitiesCollection extends Backbone.Collection<CityModel> {

	constructor(countryName: string, stateName?: string) {
		super();
		this.url = this.buildUrl(countryName, stateName);
	}

	url: string;

	private buildUrl(countryName: string, stateName?: string): string {
		return stateName === undefined
			? Util.Hostname + Util.CityApiUrl + countryName
			: Util.Hostname + Util.CityApiUrl + countryName + "/" + stateName;
	}
}