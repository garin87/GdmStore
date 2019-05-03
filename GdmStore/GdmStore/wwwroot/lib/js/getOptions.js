
export function getOptions(url) {
    let result = fetch(url)
        .then(function (response) {
            if (!response.ok) {
                throw new Error("HTTP error, status = " + response.status);
            }
            return response.json();
        })
        .catch(function (error) {
            console.log(error);
        });
    return result;
}

