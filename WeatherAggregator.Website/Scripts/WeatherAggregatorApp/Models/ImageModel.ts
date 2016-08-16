/// <reference path="../UrlConstants.ts" />
class ImageModel extends Backbone.Model {

	constructor(imageSearchQuery: string, imageSize?: number) {
		super();
		this.url = this.createUrl(imageSearchQuery, imageSize);
	}

	defaults(): { ImageUrl: string } {
		return {
			ImageUrl: ""
		}
	}

	url: string;

	private createUrl(imageSearchQuery: string, imageSize: number): string {
		if (imageSize === undefined) {
			imageSize = 640;
		}

		return UrlConstants.Hostname + UrlConstants.ImageApiUrl + imageSearchQuery + "/" + imageSize;
	}
}


 