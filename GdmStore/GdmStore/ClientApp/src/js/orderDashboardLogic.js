import { getData } from './getData';
import { handlePagination } from './productsDashboardLogic';

export default function parametersOrderHandler(uriProduct) {
    getData(uriProduct)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                let old_element = document.getElementById("wrapperPagination");
                let new_element = old_element.cloneNode(true);
                old_element.parentNode.replaceChild(new_element, old_element);
                handlePagination(json, formatParametersOrder, 'listOrderParameters'); 
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
    //<th>
    //    <button data-button-type="EditOrder" data-diameter-productId="${item[i].id }" class="btn btn-outline-primary" >
    //        Изменить</button>
    //</th>
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
      
         <th><button data-button-type="RemoveOrder" data-diameter-productId="${item[i].id }" class="btn btn-outline-danger" >
            Удалить</button>
         </th>
        
     </tr>
     `;
    document.getElementById('listOrderParameters').insertAdjacentHTML('beforeend', parametersOrderRow);
}
// ////////////////////delete order

function deleteOrder(event) {
    const productId = event.target.getAttribute("data-diameter-productId");
    const buttonType = event.target.getAttribute("data-button-type");

    if (buttonType === "RemoveOrder") {
        let uriOrderDelete = "api/Orders/" + productId;
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

}
document.body.addEventListener('click', deleteOrder);

// /////////////////////// update order

function viewValueOrder(orderId) {
    const uriOrder = "api/OrderProducts/GetOrderByOrderId/" + orderId;
    getData(uriOrder)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                valueOrderUpdate(json, i)
            }
        });
}


function valueOrderUpdate(item, i) {

    document.getElementById('TypeProductUpdate').setAttribute('data-productId', item[i].orderProducts[0].productId);
    document.getElementById('TypeProductUpdate').setAttribute('data-orderProductId', item[i].orderProducts[0].orderProductId);
    document.getElementById('TypeProductUpdate').setAttribute('data-orderId', item[i].orderProducts[0].orderId);


    document.getElementById('TypeProductUpdate').value = item[i].productOrders[0].nameType;
    document.getElementById('companyOrderUpdate').value = item[i].nameCompany;
    document.getElementById('numberOrderUpdate').value = item[i].productOrders[0].number;
    document.getElementById('manufacturerOrderUpdate').value = item[i].productOrders[0].manufacturer;
    
    document.getElementById('sellingPriceOrderUpdate').value = item[i].price;
    document.getElementById('amountOrderUpdate').value = item[i].orderProducts[0].amount;
    document.getElementById('dateOrderUpdate').value = item[i].dateTime;


}


function updateOrder() {
    const productId = event.target.getAttribute("data-diameter-productId");
    const buttonType = event.target.getAttribute("data-button-type");
    if (buttonType === "EditOrder") {
        removeAllChild("orderUpdate")
        viewValueOrder(productId);
        formatUpdateOrder(productId);
       
    }

    function removeAllChild(id) {
        if (document.getElementById(id).childNodes.length > 0) {
            let element = document.getElementById(id);
            while (element.firstChild) {
                element.removeChild(element.firstChild);
            }
        }
    }
}
function formatUpdateOrder() {
   
    
const updateOrderRow = `
<form class="update-product" id="updateProduct" method="put">
                <div class="row flex-xl-row flex-lg-row  flex-md-column">
                    <div class="col col-lg-2 col-xl-2 form-group">
                        <label>Имя товара</label>
                       <input name="typeProduct" data-productId=""  data-orderProductId=""  data-orderId=""  class="form-control" 
                        id="TypeProductUpdate" value="" disabled/>
                    </div>
                    <div class="col">
                        <label>Номер</label>
                        <input name="number" class="form-control" id="numberOrderUpdate" value="" disabled/>
                    </div>
                    <div class="col">
                        <label>Производ.</label>
                        <input name="manufacturer" class="form-control" id="manufacturerOrderUpdate" value="" disabled/>
                    </div>
                    <div class="col col-lg-2 col-xl-2">
                        <label>Компания</label>
                        <input name="company" class="form-control" id="companyOrderUpdate" value=""/>
                    </div>
                    <div class="col">
                        <label>ЦенаBLR</label>
                        <input name="sellingPrice" class="form-control" id="sellingPriceOrderUpdate" value="" />
                    </div>
                    <div class="col">
                        <label>Количество</label>
                        <input name="Amount" class="form-control" id="amountOrderUpdate" value="" />
                    </div>
                    <div class="col">
                        <label>Время</label>
                        <input name="dateOrder" class="form-control" id="dateOrderUpdate" value="" disabled/>
                    </div>
                    <div class="col justify-content-center btn-add">
                        <button type="submit" class="btn btn-primary data-order-id =""  button-order-add" id="saveOrderUpdate">Сохранить</button>
                    </div>
                </div>
            </form>
`;

    document.getElementById('orderUpdate').insertAdjacentHTML('beforeend', updateOrderRow);
}

document.body.addEventListener('click', updateOrder);


function updateOrderValue(e) {
    if (e.target.id === 'saveOrderUpdate') {
        e.preventDefault();

        const data = {
               'id': 0,
               "nameCompany": document.getElementById('companyOrderUpdate').value.toUpperCase(),
               "price": document.getElementById('sellingPriceOrderUpdate').value,
               "amount": document.getElementById('amountOrderUpdate').value,
               "dateTime": document.getElementById('dateOrderUpdate').value,

            "orderProductId": document.getElementById('TypeProductUpdate').getAttribute('data-orderProductId'),
            "orderId": document.getElementById('TypeProductUpdate').getAttribute('data-orderId'),
            "productId": document.getElementById('TypeProductUpdate').getAttribute('data-productId'),
            }
        

        let uri = "api/OrderProducts/UpdateOrderP";

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
                if (response.status = 200) alert("заказ обновлен")
                console.log('Success:', JSON.stringify(response))
            })
            .catch((error) => {
                console.error(error);
            });
    }
}

document.body.addEventListener('click', updateOrderValue);
