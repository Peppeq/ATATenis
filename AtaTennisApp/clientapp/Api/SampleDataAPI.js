export default {
    getData: async () => {
        return fetch('/api/Player', {
            method: 'get'
        }).then(function (response) {
            return response.json();
        }).then(function (response) {
            return response;
        });
    }   
}