/// <reference path="../Util.ts" />

class ImageModel extends Backbone.Model {

	private imageSearchQuery: string;

	constructor(imageSearchQuery: string) {
		super();
		this.url = Util.Hostname + Util.ImageApiUrl + imageSearchQuery;
	}

	defaults(): { ImageUrl: string } {
		return {
			ImageUrl: ""
		}
	}

	url: string;
}


 