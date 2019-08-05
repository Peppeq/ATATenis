export default {
    getData: async () => {
        return fetch("/api/Player", {
            method: "get"
        // tslint:disable-next-line:typedef
        }).then(function (response) {
            return response.json();
        // tslint:disable-next-line:typedef
        }).then(function (response) {
            return response;
        });
    }
};