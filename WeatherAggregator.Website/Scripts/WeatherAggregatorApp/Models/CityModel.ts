class CityModel extends Backbone.Model {
	defaults(): { CityName: string; CountryName: string; StateName: string } {
		return {
			CityName: "",
			CountryName: "",
			StateName: ""
		}

	}
}