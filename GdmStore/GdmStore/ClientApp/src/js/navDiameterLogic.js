import { getData } from './getData';

export default function diameterHandler(uriProduct) {
    getData(uriProduct)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                renderDiameterOfProducts(json, i)
            }
        });
}

function renderDiameterOfProducts(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col-2 col-sm-2 col-dm-1 col-lg-1"
    button.className = "btn  name-item diameter-item";
    button.setAttribute("data-productTypeId", item[i].productTypeId);
    button.setAttribute("data-paramId", item[i].paramId);
    button.setAttribute("data-param", item[i].param);
    button.setAttribute("data-diameterId", item[i].diameterId);
    button.setAttribute("data-diameterValue", item[i].diameterValue);
    button.innerHTML = item[i].diameterValue;
    div.appendChild(button);

    document.getElementById("listDiameters").appendChild(div);
}
