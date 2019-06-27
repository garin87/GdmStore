import { getData } from './getData';

export default function parametersOrderHandler(uriProduct) {
    getData(uriProduct)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatParametersOrder(json, i) 
            }
        });
}

function formatParametersOrder(item, i) {

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

    const parametersOrderRow = `
     <tr class="">
         <th scope="row">${ i + 1}</th>
         <th>${ nameType }</th>
         <th>${ manufacturer }</th>
         <th>${item[i].nameCompany }</th>
         <th>${ number }</th>
         <th>${ amount   }</th>
         <th>${ item[i].price }</th>
         <th>${ item[i].dateTime }</th>
         <th>
            <button data-button-type="EditOrder" data-diameter-productId="${item[i].id }" class="btn btn-outline-primary" >
            Изменить</button>
         </th>
         <th><button data-button-type="RemoveOrder" data-diameter-productId="${item[i].id }" class="btn btn-outline-danger" >
            Удалить</button>
         </th>
        
     </tr>
     `;
    document.getElementById('listOrderParameters').insertAdjacentHTML('beforeend', parametersOrderRow);
}
// ////////////////////delete order
document.body.addEventListener('click', function (event) {
    const productId = event.target.getAttribute("data-diameter-productId");
    const buttonType = event.target.getAttribute("data-button-type");

    if (buttonType === "RemoveOrder") {
        let uriOrderDelete = "http://localhost:5000/api/Orders/" + productId;
        deleteData(uriOrderDelete);
    }

    function deleteData(uriOrderDelete) {
        return fetch(uriOrderDelete, {
            method: 'delete'
            }).then(response => response.json()
            .then(json => {
                if (json.status = 200) alert("Заказ удален")
                return json;
            })
        );
    }

});
