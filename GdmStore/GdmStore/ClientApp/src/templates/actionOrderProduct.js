import parametersOrderHandler from "../js/orderDashboardLogic";
import { getData } from '../js/getData';

const navOrder = `
    <div class="col order-container " id="orderContainer">
         <h2 class="col order-caption  text-center">Заказы</h2>
         <div class="row align-items-center list-button" id="navOrder">
                <div class="col-12 col-md-7 col-xl-3 col-lg-3 order-buttons">
                    <button class="btn col order-bth" id="showOrders">Показать все заказы</button>
                </div>
                <div class="col-6 col-md-6 col-xl-3 col-lg-3">
                    <label>Поиск заказов по компании </label>
                    <input name="nameCompany" class="form-control" id="nameCompanyOrder" value=""/>
                </div>
                <div class= "col-6 col-md-3 col-xl-2 col-lg-2 order-buttons">
                  <button class="btn col  order-bth"  id="searchOrders">Искать</button>
               </div>
         </div>  
    </div>
    <div class="col order-update" id="orderUpdate"></div>
    `;
export default navOrder;
const signboardOrder = `
<div class="col list-name-parameters table-responsive" id="">
                    <table class="table table-striped table-hover">
                        <thead class="">
                            <tr class="thead-table ">
                                <th>#</th>
                                <th>Товар</th>
                                <th>Производ.</th>
                                <th>Имя компании</th>
                                <th>Номер</th>
                                <th>Длина</th>
                                <th>ЦенаBLR</th>
                                <th>Время</th>
                                <th></th>
                                <th></th>   
                            </tr>
                        </thead>
                        <tbody class="list-orders-parameters" id="listOrderParameters">
                        </tbody
                    </table>
 </div>
`;


function handleActionOrder(event) {
    const id = event.target.id;
    const uriOrder = 'api/Orders/GetOrderProducts';
    if (id === "showOrders") {
        removeAllChild("dashboardContent");
        document.getElementById('dashboardContent').insertAdjacentHTML('beforeend', signboardOrder);
        parametersOrderHandler(uriOrder);
    }
    if (id == 'searchOrders') {
        removeAllChild("dashboardContent");
        document.getElementById('dashboardContent').insertAdjacentHTML('beforeend', signboardOrder);
        let urlOrders = "api/Orders/GetOrderByNameCompany/";
        let nameCompany = document.getElementById('nameCompanyOrder').value.toUpperCase();

        if (nameCompany !== null) {
            let url2 = decodeURI(urlOrders + decodeURIComponent(nameCompany))
            parametersOrderHandler(decodeURIComponent(url2));
        }
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

document.body.addEventListener('click', handleActionOrder);



