import { getData } from './getData';
export default viewValueProduct;
var targetProductId;
function viewValueProduct(ProductId) {
    const uriProduct = "api/Products/GetProductParam/" + ProductId;
     getData(uriProduct)
            .then(function (json) {
                console.log(json);
                for (let i = 0; i < json.length; i++) {
                    ValueProductsUpdate(json, i)
                }
         });

    targetProductId = ProductId;
}


function ValueProductsUpdate(item, i) {

    let typeItem;
    let diameterItem;

    if (item[i].productTypeId == 1) {
        typeItem = item[i].parameters[1].value;
        diameterItem = item[i].parameters[2].value;
    }
    else if (item[i].productTypeId == 2) {
        typeItem = '';
        diameterItem = item[i].parameters[1].value;
    }

    document.getElementById('TypeProductUpdate').value = item[i].productTypeId;
    document.getElementById('numberUpdate').value = item[i].number;
    document.getElementById('diameterUpdate').value = diameterItem;
    document.getElementById('manufacturerUpdate').value = item[i].manufacturer;
    document.getElementById('typeUpdate').value = item[i].parameters[0].value;
    document.getElementById('gradeSteelUpdate').value = typeItem;
    document.getElementById('primeCostEURUpdate').value = item[i].primeCostEUR;
    document.getElementById('amountUpdate').value = item[i].amount;

    let paramId;
    if (item[i].parameters[2] === undefined) {
        paramId = "";
    }
    else {
        paramId = item[i].parameters[2].id;
    }

    document.getElementById('parametrId').setAttribute("data-parametrId1", item[i].parameters[0].id);
    document.getElementById('parametrId').setAttribute("data-parametrId2", item[i].parameters[1].id);
    document.getElementById('parametrId').setAttribute("data-parametrId3", paramId);
}

function update(ev) {
    if (ev.target.id === 'saveUpdate') {
        ev.preventDefault();

        let typeItem;
        let diameterItem;
        let data;
        if (document.getElementById('TypeProductUpdate').value == 1) {
            typeItem = 1;
            diameterItem = 4;
            data = {
                "productId": targetProductId,
                 "number": document.getElementById('numberUpdate').value.toUpperCase(),
                "amount": document.getElementById('amountUpdate').value,
                "primeCostEUR": document.getElementById('primeCostEURUpdate').value,
                 "manufacturer": document.getElementById('manufacturerUpdate').value.toUpperCase(),
                "productTypeId": 1,
                "parameters": [
                    {
                        "id": document.getElementById('parametrId').getAttribute("data-parametrId1"),
                        "parameterId": typeItem,
                        "value": document.getElementById('typeUpdate').value.toUpperCase()
                    },
                    {
                        "id": document.getElementById('parametrId').getAttribute("data-parametrId2"),
                        "parameterId": 3,
                        "value": document.getElementById('gradeSteelUpdate').value.toUpperCase()
                    },
                    {
                        "id": document.getElementById('parametrId').getAttribute("data-parametrId3"),
                        "parameterId": diameterItem,
                        "value": document.getElementById('diameterUpdate').value
                    }
                ]
            }
        }
        else if (document.getElementById('TypeProductUpdate').value == 2) {
            typeItem = 2;
            diameterItem = 1003;
            data = {
                "productId": targetProductId,
                "number": document.getElementById('numberUpdate').value.toUpperCase(),
                "amount": document.getElementById('amountUpdate').value,
                "primeCostEUR": document.getElementById('primeCostEURUpdate').value,
                "manufacturer": document.getElementById('manufacturerUpdate').value.toUpperCase(),
                "productTypeId": 2,
                "nameType": null,
                "parameters": [
                    {
                        "id": document.getElementById('parametrId').getAttribute("data-parametrId1"),
                        "parameterId": typeItem,
                        "value": document.getElementById('typeUpdate').value.toUpperCase()
                    },
                    {
                        "id": document.getElementById('parametrId').getAttribute("data-parametrId2"),
                        "parameterId": diameterItem,
                        "value": document.getElementById('diameterUpdate').value
                    }
                ]
            }
        }

       
        let uri = "api/Products/UpdateProducts/" + targetProductId;

          fetch(uri, {
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
                if (response.status = 200) alert("продукт обновлен")
                console.log('Success:', JSON.stringify(response))
            })
            .catch((error) => {
                console.error(error);
            });
    }
}

document.body.addEventListener('click', update);

