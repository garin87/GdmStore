import { getOptions } from './getOptions.js';


let get = location.search;
let uri = get.slice(1).toString();
var url = uri.split('/');
let uriId = url[3];

console.log(url[3]);

ViewValueProduct("http://localhost:5000/api/Products/GetProductParam/" + url[3]);

function ValueProductsUpdate(item, i) {

    let typeItem;
    let diameterItem;

    if (item[i].productTypeId == 1) {
        typeItem = 2;
        diameterItem = 4;
    }
    else if (item[i].productTypeId == 2) {
        typeItem = 1;
        diameterItem = 1003;
    }
    productID
    document.getElementById('productID').value = item[i].productId;
    document.getElementById('TypeProductUpdate').value = item[i].productTypeId;
    document.getElementById('numberUpdate').value = item[i].number;
    document.getElementById('diameterUpdate').value = item[i].parameters[2].value;
    document.getElementById('manufacturerUpdate').value = item[i].manufacturer;
    document.getElementById('typeUpdate').value = item[i].parameters[0].value;
    document.getElementById('gradeSteelUpdate').value = item[i].parameters[1].value;
    document.getElementById('primeCostEURUpdate').value = item[i].primeCostEUR;
    document.getElementById('amountUpdate').value = item[i].amount;

}

function ViewValueProduct(uriType) {
    getOptions(uriType)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                ValueProductsUpdate(json, i)
            }
            
        });
}

//update product
document.getElementById('updateProduct').addEventListener('submit', function (ev) {
    ev.preventDefault();
    let typeItem;
    let diameterItem;

    if (document.getElementById('TypeProductUpdate').value == 1) {
        typeItem = 2;
        diameterItem = 4;
    }
    else if (document.getElementById('TypeProductUpdate').value == 2) {
        typeItem = 1;
        diameterItem = 1003;
    }

    let data = {
        "productId": document.getElementById('productID').value,
        "number": document.getElementById('numberUpdate').value,
        "amount": document.getElementById('amountUpdate').value,
        "primeCostEUR": document.getElementById('primeCostEURUpdate').value,
        "manufacturer": document.getElementById('manufacturerUpdate').value,
        "productTypeId": document.getElementById('TypeProductUpdate').value,
        "parameters": [
            {
                "parameterId": typeItem,
                "value": document.getElementById('typeUpdate').value
            },
            {
                "parameterId": 3,
                "value": document.getElementById('gradeSteelUpdate').value
            },
            {
                "parameterId": diameterItem,
                "value": document.getElementById('diameterUpdate').value
            }
        ]
    }

    let ur = "http://localhost:5000/api/Products/UpdateProducts/" + document.getElementById('productID').value;
    console.log(ur);

    fetch(ur, {
        method: 'PUT',
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    })
        .then(res => {
            return res.json()
        })
        .then(response => {
            if (response.status = 200) alert("Добавлен новый продукт")
            console.log('Success:', JSON.stringify(response))
        }

        )
        .catch((error) => {
            console.error(error);
        });

    ev.preventDefault();
});
