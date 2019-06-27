import { getOptions } from './getOptions.js';
const uriOrder = 'http://localhost:5000/api/Orders/GetOrderProducts';
const urlNRB = 'https://www.nbrb.by/API/ExRates/Rates?Periodicity=0';
//////////////////////////////////////////////////////////////////////////////
let getUrl = location.search;
let uri = getUrl.slice(1).toString();
var url = uri.split('/');

console.log(url[3]);

///////////////////////////////////////////////////////////////////////////
function getDubleOptions() {
    let result = Promise.all([
        fetch("http://localhost:5000/api/Products/GetParamForOrder/" + url[3]),
        fetch("https://www.nbrb.by/API/ExRates/Rates?Periodicity=0")
    ]).then(async ([items, valueCurrency]) => {
        const a = await items.json();
        const b = await valueCurrency.json();
        return [a, b];
    }).catch(function (error) {
        console.log(error);
    });

    return result;
}

function ValueOrder(item, i, valueBLR) {

    document.getElementById('orderID').value = url[3];
    document.getElementById('numberProduct').value = item[0].number;
    document.getElementById('priceProductBLR').value = (item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate).toFixed(2);
    //document.getElementById('nameCompany').value = item[i].nameCompany;
    //document.getElementById('amountProduct').value = item[i].manufacturer;
    //document.getElementById('priceProduct').value = item[i].parameters[0].value;
    document.getElementById('price10').value = ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.1).toFixed(2);
    document.getElementById('price15').value = ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.15).toFixed(2);
    document.getElementById('price20').value = ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.2).toFixed(2);

}


function viewPriceBLR() {
    getDubleOptions().then(function (json) {
        console.log(json);
        for (let i = 0; i < json[0].length; i++) {
            formatPriceBLR(json[0], i, json[1])
            ValueOrder(json[0], i, json[1])
        }
    });
}

viewPriceBLR();

function formatPriceBLR(item, i, valueBLR) {
    let productPrice = item[i].price * valueBLR[4].Cur_OfficialRate;
    //console.log(productPrice)
}


function ViewOrders(uriOrder) {
    getOptions(uriOrder)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatOptionOrder(json, i)
            }
        });
}

function getValueCurrency(urlNRB ) {
    getOptions(urlNRB)
        .then(function (json) {
            ValueCurrency(json) 
        });
}

getValueCurrency(urlNRB);

function ValueCurrency(data) {
    const USD = 4;
    const EUR = 5;

    document.getElementById('valueUSD').textContent = data[USD].Cur_OfficialRate;
    document.getElementById('valueEUR').textContent = data[EUR].Cur_OfficialRate;
}

////////////////////////// view orders 
document.getElementById('showOrders').addEventListener('click', function (ev) {

    if (document.getElementById("listOrdersContent").childNodes.length > 0) {
        let element = document.getElementById("listOrdersContent");
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }

    ViewOrders(uriOrder);

});


function formatOptionOrder(item, i) {
    let row = document.createElement('div');
    let col = document.createElement('div');
    let productOrders = null;
    let orderProducts = null;
    let number = null;
    let amount = null;
    let manufacturer = null;
    let nameType = null;

    if (item[i].productOrders[0] !== undefined) {
        productOrders = item[i].productOrders[0];
        number = productOrders.number;
        manufacturer = productOrders.manufacturer;
        nameType = productOrders.nameType;
    }

    if (item[i].orderProducts[0] !== undefined) {
        orderProducts = item[i].orderProducts[0];
        amount = orderProducts.amount;
    }

    row.className = "row text-left list-params text-center";
    col.className = "col";
    console.log(item[i].productOrders[i]);
    row.innerHTML = '<div class="col ">' + item[i].id + '</div>' +
        '<div class="col">' + nameType + '</div>' +
        '<div class="col">' + item[i].nameCompany + '</div>' +
        '<div class="col">' + number + '</div>' +
        '<div class="col">' + amount + '</div>' +
        '<div class="col">' + manufacturer + '</div>' +
        '<div class="col">' + item[i].price + '</div>' +
        '<div class="col">' + item[i].dateTime + '</div>' +
        '<button type="submit" data-button-type="Edit" class="btn btn-outline-primary" id="Edit' + item[i].id + '">' + 'Изменить' + '</button>' +
        '<button type="submit" data-button-type="Remove" class="btn btn-outline-danger" id="Remove' + item[i].id + '">' + 'Удал' + '</button>' 

    document.getElementById("listOrdersContent").appendChild(row);

}

function showDateNow() {
    let d = new Date();
    document.getElementById('currencyContent').textContent = (
        d.getFullYear() + "." +
        ("00" + (d.getMonth() + 1)).slice(-2) + "." +
        ("00" + d.getDate()).slice(-2)
    );

}
 showDateNow()
///////////////////////add order
document.getElementById('saveOrder').addEventListener('click', function (ev) {
    ev.preventDefault();

    let data = {
         "id": 0,
         "nameCompany": (document.getElementById('nameCompany')).value.toUpperCase(),
         "price": (document.getElementById('priceProduct')).value,
         "productId": +url[3],
         "amount": (document.getElementById('amountProduct')).value
    }

    let uri = "http://localhost:5000/api/Orders/addOrderProduct";
    console.log(uri);

    fetch(uri, {
        method: 'POST',
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

///////////////////////delete order
document.getElementById('listOrdersContent').addEventListener('click', function (event) {

    let id = event.target.id;
    if (document.getElementById(id).getAttribute("data-button-type") == "Remove") {
        let OrderId = id.substr(6);
        let uriType = "http://localhost:5000/api/Orders/" + OrderId;
        deleteData(uriType);
    }

    function deleteData(uriType) {
        return fetch(uriType, {
            method: 'delete'
        }).then(response => response.json()
            .then(json => {
                if (json.status = 200) alert("Продукт удален")
                return json;
            })
        );
    }

});

///////////////////////view orders by nameCompany
function ViewOrdersByCompany(uriOrder) {
    getOptions(uriOrder)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatOptionOrder(json, i)
            }
        });
}

document.getElementById('searchOrders').addEventListener('click', function () {

    if (document.getElementById("listOrdersContent").childNodes.length > 0) {
        let element = document.getElementById("listOrdersContent");
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }

    let urlOrders = "http://localhost:5000/api/Orders/GetOrderByNameCompany/";
    let nameCompany = document.getElementById('nameCompanyOrder').value.toUpperCase();

    if (nameCompany !== null) {
        let url2 = decodeURI(urlOrders + decodeURIComponent(nameCompany))
        ViewOrdersByCompany(decodeURIComponent(url2));
    }
   
});
