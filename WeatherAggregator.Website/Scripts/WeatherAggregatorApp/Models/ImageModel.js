var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
/// <reference path="../UrlConstants.ts" />
var ImageModel = (function (_super) {
    __extends(ImageModel, _super);
    function ImageModel(imageSearchQuery, imageSize) {
        _super.call(this);
        this.url = this.createUrl(imageSearchQuery, imageSize);
    }
    ImageModel.prototype.defaults = function () {
        return {
            ImageUrl: ""
        };
    };
    ImageModel.prototype.createUrl = function (imageSearchQuery, imageSize) {
        if (imageSize === undefined) {
            imageSize = 640;
        }
        return UrlConstants.Hostname + UrlConstants.ImageApiUrl + imageSearchQuery + "/" + imageSize;
    };
    return ImageModel;
}(Backbone.Model));
//# sourceMappingURL=ImageModel.js.map