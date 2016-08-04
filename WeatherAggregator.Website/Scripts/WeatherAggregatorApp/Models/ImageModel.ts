/// <reference path="../Util.ts" />

class ImageModel extends Backbone.Model {

	private imageSearchQuery: string;
	private util: Util;

	constructor(imageSearchQuery: string) {
		super();
		this.url = Util.Hostname + Util.ImageApiUrl + imageSearchQuery;
	}

	defaults(): { ImageUrl: string } {
		return {
			ImageUrl: ""
		}
	}

	initialize(): void {
		this.util = new Util();
	}

	url: string;
}


 