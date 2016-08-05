class CountryModel extends Backbone.Model {
	defaults() {
		return {
			CountryCode: "",
			CountryName: "",
			States: new StateModel()
		}
	}
} 