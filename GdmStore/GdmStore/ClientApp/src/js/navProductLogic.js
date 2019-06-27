import { getData } from './getData';
//const uriProduct = 'api/ProductTypes';
//export default productsHandler;
 //productsHandler(uriProduct);

export default function productsHandler(uriProduct) {
    getData(uriProduct)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                renderNamesOfProducts(json, i)
            }
        });
}

function renderNamesOfProducts(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col-3"
    button.className = "btn name-item";
    button.setAttribute("data-NameProductId", item[i].id);
    button.innerHTML = item[i].nameType;
    div.appendChild(button);

    document.getElementById("listNameProducts").appendChild(div);
}
