class CountriesCollection extends Backbone.Collection<CountryModel> {

	constructor() {
		super();
		this.url = UrlConstants.Hostname + UrlConstants.CountryApiUrl;
	}

	url: string;
}  