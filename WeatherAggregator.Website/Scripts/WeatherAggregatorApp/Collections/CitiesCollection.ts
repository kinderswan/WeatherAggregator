class CitiesCollection extends Backbone.Collection<CityModel> {

	constructor(countryName: string, stateName?: string) {
		super();
		this.url = this.buildUrl(countryName, stateName);
	}

	url: string;

	private buildUrl(countryName: string, stateName?: string): string {
		return stateName === undefined
			? UrlConstants.Hostname + UrlConstants.CityApiUrl + countryName
			: UrlConstants.Hostname + UrlConstants.CityApiUrl + countryName + "/" + stateName;
	}
}