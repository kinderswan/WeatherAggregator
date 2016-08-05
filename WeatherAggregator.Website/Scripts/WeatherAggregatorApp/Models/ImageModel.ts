/// <reference path="../UrlConstants.ts" />
class ImageModel extends Backbone.Model {

	private imageSearchQuery: string;

	constructor(imageSearchQuery: string) {
		super();
		this.url = UrlConstants.Hostname + UrlConstants.ImageApiUrl + imageSearchQuery;
	}

	defaults(): { ImageUrl: string } {
		return {
			ImageUrl: ""
		}
	}

	url: string;
}


 