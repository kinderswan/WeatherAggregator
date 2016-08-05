var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
/// <reference path="../UrlConstants.ts" />
var ImageModel = (function (_super) {
    __extends(ImageModel, _super);
    function ImageModel(imageSearchQuery) {
        _super.call(this);
        this.url = UrlConstants.Hostname + UrlConstants.ImageApiUrl + imageSearchQuery;
    }
    ImageModel.prototype.defaults = function () {
        return {
            ImageUrl: ""
        };
    };
    return ImageModel;
}(Backbone.Model));
//# sourceMappingURL=ImageModel.js.map