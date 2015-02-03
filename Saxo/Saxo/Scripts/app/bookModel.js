window.MyApp = window.MyApp || {};

(function (myAppp) {
    myAppp.Book = function book(b) {
        var self = this;
        self.Isbn = ko.observable(b.Isbn);
        self.ImageUrl = ko.observable(b.ImageUrl);
        self.IsChecked = ko.observable(b.IsChecked);
        self.Title = ko.observable(b.Title);
        self.RatingCount = ko.observable(b.RatingCount);
        self.Label = ko.observable(b.Label);
        self.Url = ko.observable(b.Url);
    };
}(window.MyApp));