import { getData } from './getData';

export default function productsTypeHandler(uriProduct) {
    getData(uriProduct)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                renderTypeOfProducts(json, i)
            }
        });
}

function renderTypeOfProducts(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col-6 col-sm-3 col-md-2 col-lg-2"
    button.className = "btn  type-item name-item";
    button.setAttribute("data-ProductId", item[i].parameterId); // productTypeId == parameterId
    button.setAttribute("data-ProductType", item[i].value);
    button.innerHTML = item[i].value;

    div.appendChild(button);
    document.getElementById("listTypes").appendChild(div);
}

