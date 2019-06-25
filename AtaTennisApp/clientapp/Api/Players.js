export class Players {
    async getData() {
        return fetch('/api/Player', {
            method: 'get'
        }).then(function (response) {
            return response.json();
        }).then(function (response) {
            return response;
        });
    }

    sayHello() {
        alert("hello")
    }
}
