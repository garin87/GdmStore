
export default function initDeleteProduct(ProductId) {
    deleteProduct('http://localhost:5000/api/Products/DeleteProducts/' + ProductId)
    function deleteProduct(url) {

        deleteData(url)

        function deleteData(url) {
            return fetch(url, {
                method: 'delete'
            }).then(response => response.json()
                .then(json => {
                    if (json.status = 200) alert("Продукт удален")
                    return json;
                })
            );
        }

    }

}

