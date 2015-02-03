window.MyApp = window.MyApp || {};

(function (myApp) {
    ko.applyBindings(myApp.ViewModel);

    myApp.Batch = 24;
    myApp.IsbnToLoad = [];
    myApp.Begin = 0;
    myApp.End = myApp.Batch;
    $('#textArea').keypress(function (event) {
        if (event.keyCode == 13) {
            var keysArray = $('#textArea').val().split('\n');
            $.each(keysArray, function (index, value) {
                if (value !== "") {      //&& $.inArray(value, isbnToLoad) === -1
                    myApp.IsbnToLoad.push(value);
                }
            });

            if (myApp.IsbnToLoad.length > 0) {
                myApp.GetItemsInfo(myApp.IsbnToLoad.slice(myApp.Begin, myApp.End));
            }
        }
        return true;
    });
}(window.MyApp));
