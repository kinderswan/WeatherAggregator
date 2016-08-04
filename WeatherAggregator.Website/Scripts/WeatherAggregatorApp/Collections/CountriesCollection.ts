class CountriesCollection extends Backbone.Collection<CountryModel> {

	constructor() {
		super();

		this.url = Util.Hostname + Util.CountryApiUrl;
	}

	url: string;
}  