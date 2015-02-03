window.MyApp = window.MyApp || {};

(function (myApp) {

    myApp.GetItemsInfo = function (keys) {
        $.ajax({
                type: "POST",
                url: "/Home/GetItems",
                data: { keys: keys },
                success: function (result) {
                    var items = JSON.parse(result);

                    var newModels = items.map(function(item) {
                        return new MyApp.Book(item);
                    });

                    MyApp.ViewModel.books(MyApp.ViewModel.books().concat(newModels));
                }
            });
        };

        myApp.ViewModel = {
            books: ko.observableArray([]),

            scrolled: function (data, event) {
                var elem = event.target;
                if (elem.scrollTop > (elem.scrollHeight - elem.offsetHeight - 200)) {
                    myApp.Begin += myApp.Batch;
                    myApp.End += myApp.Batch;
                    var keys = myApp.IsbnToLoad.slice(myApp.Begin, myApp.End);
                    if (keys.length > 0) {
                        myApp.GetItemsInfo(keys);
                    }
                }
            },

            onChange: function (el, event) {
                debugger;
                var key = el.Isbn();
                var checked = event.target.checked;
                $.ajax({
                    type: "POST",
                    url: "/Home/UpadeItem",
                    data: { key: key, value: checked }
                });
            }
        };

}(window.MyApp));