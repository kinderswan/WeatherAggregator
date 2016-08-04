class StateModel extends Backbone.Model {
	defaults(): { StateCode: string; StateName: string } {
		return {
			StateCode: "",
			StateName: ""
		}
	}
} 