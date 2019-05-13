import { getOptions } from './getOptions.js';

const uriProduct = 'api/ProductTypes';
const uriParams = "api/Products/GetProducts/1";
//get diameters(parameterId = 4) type steel rod  with type "ТВЧ" 
const uriDiametersRodT = '/api/ProductParameters/GetProductDiameters/4?param=ТВЧ&paramId=2';
//get diameters(parameterId = 4) type steel rod  with type "Стандарт" 
const uriDiametersRodSt = '/api/ProductParameters/GetProductDiameters/4?param=Стандарт&paramId=2';
//get diameters(parameterId = 1003) type tube  with type "H8" 
const uriDiametersTubeH8 = '/api/ProductParameters/GetProductDiameters/1003?param=H8&paramId=1';
//get diameters(parameterId = 1003) type tube  with type "H9" 
const uriDiametersTubeH9 = '/api/ProductParameters/GetProductDiameters/1003?param=H9&paramId=1';
//get products with type "Стандарт" by diameter
const uriProductByDiameters = 'api/ProductParameters/GetProductByDiameter/1?param=Стандарт&paramId=2&paramDiameterId=4&diameter=';
//get products with type "ТВЧ" by diameter
const uriProductByDiametersT = 'api/ProductParameters/GetProductByDiameter/1?param=ТВЧ&paramId=2&paramDiameterId=4&diameter=';
//get products with type "H8" by diameter
const uriDiametersH8 = 'api/ProductParameters/GetProductByDiameter/2?param=H8&paramId=1&paramDiameterId=1003&diameter=';
//get products with type "H9" by diameter
const uriDiametersH9 = 'api/ProductParameters/GetProductByDiameter/2?param=H9&paramId=1&paramDiameterId=1003&diameter=';

viewProducts(uriProduct)

 function viewProducts(uriProduct) {
        getOptions(uriProduct)
            .then(function (json) {
                console.log(json);
                for (let i = 0; i < json.length; i++) {
                    formatProducts(json, i)
                }
         });
}
// show products
document.getElementById("list-products").addEventListener('click', function (evant) {
    const target = event.target; 
    if (document.getElementById("list-types").childNodes.length > 0) {
        let element = document.getElementById("list-types");
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }
    let id = evant.target.id;
    let strId = id.substr(9);
 
    if (target == document.getElementById("ProductId1"))
        ViewRodType('api/ProductParameters/GetProductParameters/' + 2) // do not forget to replace id
    else if (target == document.getElementById("ProductId2"))
        ViewTubeType('api/ProductParameters/GetProductParameters/' + 1) // do not forget to replace id
});
// show types of products
document.getElementById("list-types").addEventListener('click', function (event) {
    const target = event.target;
    if (document.getElementById("list-diameters").childNodes.length > 0) {
        let element = document.getElementById("list-diameters");
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }
    let id = event.target.id; 
    console.log(id);
    let strId = id.substr(7);
    console.log(strId);
    if (target == document.getElementById("TypeRId0")) 
        ViewDiameter(uriDiametersRodSt); // do not forget to replace id
    else if (target == document.getElementById("TypeRId1"))
        ViewDiameterType2(uriDiametersRodT); // do not forget to replace id
    else if (target == document.getElementById("TypeTId0"))
        ViewDiameterTypeTube(uriDiametersTubeH8); // do not forget to replace id
    else if (target == document.getElementById("TypeTId1"))
        ViewDiameterTypeTube2(uriDiametersTubeH9); // do not forget to replace id
});


function ViewDiameter(uriDiameter) {
    getOptions(uriDiameter)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatDiameter(json,i)
            }
        });
}

function ViewDiameterType2(uriDiameter) {
    getOptions(uriDiameter)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatDiameterbytype2(json, i)
            }
        });
}

function ViewDiameterTypeTube(uriDiameter) {
    getOptions(uriDiameter)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatDiameterByTubetype(json, i);
            }
        });
}

function ViewDiameterTypeTube2(uriDiameter) {
    getOptions(uriDiameter)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatDiameterByTubetype2(json, i);
            }
        });
}



function ViewRodType(uriType) {
    getOptions(uriType)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatRodType(json, i)
            }
        });
}

function ViewTubeType(uriType) {
    getOptions(uriType)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatTubeType(json, i)
            }
        });
}

function ViewParams(uriParams) {
    getOptions(uriParams)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatDiameterProducts(json, i)
            }
        });
}

function ViewParamsTube(uriParams) {
    getOptions(uriParams)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatDiameterTube(json, i)
            }
        });
}


// show products of all diameters
document.getElementById('allDeametr').addEventListener('click', function (event) {
    if (document.getElementById("list-param-products").childNodes.length > 0) {
        let element = document.getElementById("list-param-products");
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }

    ViewParams(uriParams);
});

// show products of single diameter
document.getElementById('list-diameters').addEventListener('click', function (event) {
    if (document.getElementById("list-param-products").childNodes.length > 0) {
        let element = document.getElementById("list-param-products");
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }

    let id = event.target.id;
    let strId = id.substr(6);
    let tubeId = id.substr(14);

    if (event.target == document.getElementById("TypeId" + strId)) {
        ViewParams(uriProductByDiameters + strId); // do not forget to replace id
    }
    else if(event.target == document.getElementById("Typ2Id" + strId)) {
        ViewParams(uriProductByDiametersT + strId); // do not forget to replace id
    }
    else if (event.target == document.getElementById("DiamterType1Id" + tubeId)) {
        ViewParamsTube(uriDiametersH8 + tubeId); // do not forget to replace id
    }
    else if (event.target == document.getElementById("DiamterType2Id" + tubeId)) {
        ViewParamsTube(uriDiametersH9 + tubeId); // do not forget to replace id
    }

    console.log(uriDiametersH9 + strId);
    console.log(id);
    console.log(tubeId);

});

//sort diameters
document.getElementById('sortDeametr').addEventListener('click', function (ev) {

    //ViewParams('api/Products/SortProducts/4')
    if (document.getElementById("list-param-products").childNodes.length > 0) {
        let element = document.getElementById("list-param-products");
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }

    getOptions('api/Products/SortProducts/1')
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatDiameterProducts(json, i)
            }
        });



});

function formatProducts(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col-2"
    button.className = "btn btn-success text-white";
    button.id = "ProductId" + item[i].id;
    button.innerHTML =  item[i].nameType;
    div.appendChild(button);
    
    document.getElementById("list-products").appendChild(div);
   
}

function formatRodType(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col-2"
    button.className = "btn btn-success text-white";
    button.id = "TypeRId" + i;
    button.innerHTML = item[i].value;
    div.appendChild(button);

    document.getElementById("list-types").appendChild(div);
}

function formatTubeType(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col-2"
    button.className = "btn btn-success text-white";
    button.id = "TypeTId" + i;
    button.innerHTML = item[i].value;
    div.appendChild(button);

    document.getElementById("list-types").appendChild(div);
}
///////////////////////////////////////////////////
function formatDiameter(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col"

    button.className = "btn btn-success text-white";

    button.id = "TypeId" + item[i];
    button.innerHTML = item[i];
    div.appendChild(button);

    document.getElementById("list-diameters").appendChild(div);
}

function formatDiameterbytype2(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col"

    button.className = "btn btn-success text-white";

    button.id = "Typ2Id" + item[i];
    button.innerHTML = item[i];
    div.appendChild(button);

    document.getElementById("list-diameters").appendChild(div);
}

function formatDiameterByTubetype(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col"

    button.className = "btn btn-success text-white";

    button.id = "DiamterType1Id" + item[i];
    button.innerHTML = item[i];
    div.appendChild(button);

    document.getElementById("list-diameters").appendChild(div);
}

function formatDiameterByTubetype2(item, i) {
    let div = document.createElement('div');
    let button = document.createElement('button');

    div.className = "col"

    button.className = "btn btn-success text-white";

    button.id = "DiamterType2Id" + item[i];
    button.innerHTML = item[i];
    div.appendChild(button);

    document.getElementById("list-diameters").appendChild(div);
}


//////////////////////////////////////////////////
function formatDiameterProducts(item, i) {
    let row = document.createElement('div');
    let col = document.createElement('div');

    row.className = "row text-left list-params text-center";
    col.className = "col";

    row.innerHTML = '<div class="col ">' + item[i].productId + '</div>' +
        '<div class="col">' +  item[i].nameType + '</div>' +
        '<div class="col">' + item[i].number + '</div>' +
        '<div class="col">' + item[i].manufacturer + '</div>' +
        '<div class="col">' + item[i].parameters[0].value + '</div>' +
        '<div class="col">' + item[i].parameters[1].value + '</div>' +
        '<div class="col">' + item[i].parameters[2].value + '</div>' +
        '<div class="col">' + item[i].primeCostEUR + '</div>' +
        '<div class="col">' + item[i].amount + '</div>' + 
        '<button type="submit" data-button-type="Edit" class="btn btn-outline-primary" id="Edit' + item[i].productId + '">' + 'Изменить' + '</button>' +
        '<button type="submit" data-button-type="Remove" class="btn btn-outline-danger" id="Remove' + item[i].productId + '">' + 'Удал' + '</button>' +
        '<button type="submit" data-button-type="Order" class="btn btn-outline-primary " id="Order' + item[i].productId + '">' +  'Заказ' + '</button>'
 
   // console.log(item[i].parameters[1].value);
    document.getElementById("list-param-products").appendChild(row);

}
function formatDiameterTube(item, i) {
    let row = document.createElement('div');
    let col = document.createElement('div');

    row.className = "row text-left list-params text-center";
    col.className = "col";

    row.innerHTML = '<div class="col ">' + item[i].productId + '</div>' +
        '<div class="col">' + item[i].nameType + '</div>' +
        '<div class="col">' + item[i].number + '</div>' +

        '<div class="col">' + item[i].manufacturer + '</div>' +
        '<div class="col">' + item[i].parameters[0].value + '</div>' +
        '<div class="col">' + item[i].parameters[1].value + '</div>' +
        '<div class="col">' + item[i].primeCostEUR + '</div>' +
        '<div class="col">' + item[i].amount + '</div>' +
        '<button type="submit" data-button-type="Edit" class="btn btn-outline-primary" id="Edit' + item[i].productId + '">' + 'Изменить' + '</button>' +
        '<button type="submit" data-button-type="Remove" class="btn btn-outline-danger" id="Remove' + item[i].productId + '">' + 'Удал' + '</button>' +
        '<button type="submit" data-button-type="Order" class="btn btn-outline-primary " id="Order' + item[i].productId + '">' + 'Заказ' + '</button>'

    // console.log(item[i].parameters[1].value);
    document.getElementById("list-param-products").appendChild(row);

}
// add products
document.getElementById('DataForm').addEventListener('submit', function (ev) {

    let typeItem;
    let diameterItem;

    if (document.getElementById('TypeProduct').value == 1) {
        typeItem = 2;
        diameterItem = 4;
    }
    else if (document.getElementById('TypeProduct').value == 2) {
        typeItem = 1;
        diameterItem = 1003;
    }

   let data = {
        "productId": 0,
        "number": document.getElementById('number').value,
        "amount": document.getElementById('amount').value,
        "primeCostEUR": document.getElementById('primeCostEUR').value,
        "manufacturer": document.getElementById('manufacturer').value,
        "productTypeId": document.getElementById('TypeProduct').value,
        "parameters": [
            {
                "parameterId": typeItem,
                "value": document.getElementById('TypeItem').value
            },
            {
                "parameterId": 3,
                "value": document.getElementById('GradeSteel').value
            },
            {
                "parameterId": diameterItem,
                "value": document.getElementById('diametr').value
            }
        ]
    } 

    fetch( "api/Products/AddProducts", {
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
// delete products
document.getElementById('list-param-products').addEventListener('click', function (evant) {

    let url = 'api/Products/DeleteProducts'
    const target = event.target;
    let id = evant.target.id;
    let ProductId = id.substr(6);
    console.log(ProductId);

    if (target == document.getElementById("Remove" + ProductId)) {
        deleteData(url, ProductId)
    }

    function deleteData(url, ProductId) {
        return fetch(url + '/' + ProductId, {
            method: 'delete'
        }).then(response => response.json()
            .then(json => {
                if (json.status = 200) alert("Продукт удален")
                return json;
            })
        );
    }

});
// update parameters product
document.getElementById('list-param-products').addEventListener('click', function (event) {
    let id = event.target.id;
    if (document.getElementById(id).getAttribute("data-button-type") == "Edit") {
        let ProductId = id.substr(4);
        let uriType = "api/Products/GetProductParam/" + ProductId;
        redirectToUpdate(uriType);
    }

    function redirectToUpdate(uriType) {
        document.location.href = 'http://localhost:5000/lib/pages/updatePage.html?' + uriType
    }

});

// order parameters product
document.getElementById('list-param-products').addEventListener('click', function (event) {

    let id = event.target.id;

    if (document.getElementById(id).getAttribute("data-button-type") == "Order") {
        let ProductId = id.substr(5);
        let uriType = "api/Products/GetProductParam/" + ProductId;
        redirectToUpdate(uriType);
    }

    function redirectToUpdate(uriType) {
        document.location.href = 'http://localhost:5000/lib/pages/orders.html?' + uriType
    }

});

/////////////////////////////////////////////////////////////// js for order page


