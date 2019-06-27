import productsHandler from '../js/navProductLogic';
import renderProductType from './navProductType';
import renderDiameterProduct from './navDiameter';
import renderParammeters from './productsDashboard';
import initUpdateProduct from './UpdateProduct';
import initDeleteProduct from './deleteProduct';
import initOrderProduct from './orderProduct';

const uriProduct = 'api/ProductTypes';
const signboardProduct = `
<div class="col list-name-parameters table-responsive" id="">
                    <table class="table table-striped table-hover">
                        <thead class="">
                            <tr class="thead-table">
                                <th>#</th>
                                <th>Имя товара</th>
                                <th>Номер</th>
                                <th>Производ.</th>
                                <th>Тип</th>
                                <th>Сталь</th>
                                <th>Диаметр</th>
                                <th>Зав. ЦенаEUR</th>
                                <th>Длина</th>
                                <th></th>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody class="list-products-parameters" id="listProductsParameters">
                        </tbody
                    </table>
                </div>
          <div class="row products-parameters-container" id="productsParametersContainer">
          </div>
`;
const navProduct = `<div class="col product-container" id="productContainer">
    <div class="row  signboard-product nav-product-container flex-column" id="signboardProduct">
         <h2 class="col text-black text-center">Товары</h2>
         <div class="row text-left list-name-products  flex-row" id="listNameProducts">
         </div>
    </div>
       <div class="row  signboard-type nav-product-container flex-column" id="signboardType"></div>
        <div class="row  signboard-diameters nav-product-container flex-column" id="signboardDiameters"></div>     
    </div>
  `;


productsHandler(uriProduct);

document.body.addEventListener('click', function (event) {
    const id = event.target.id;
    const nameProduct = event.target.getAttribute('data-NameProductId');
    const ProductType = event.target.getAttribute('data-ProductType');
    const ProductDiameter = event.target.getAttribute('data-diameterValue');
    const targetTypeButton = event.target.getAttribute('data-button-type');


    function handlerAction() {
        if (targetTypeButton === "Edit") {
            var targetProductId = event.target.getAttribute('data-diameter-product');
            removeAllChild("content") 
            initUpdateProduct(targetProductId);
            console.log(targetProductId);
        }
        if (targetTypeButton === "Remove") {
            var targetProductId = event.target.getAttribute('data-diameter-product');
            initDeleteProduct(targetProductId)
            console.log(targetProductId);
        }
        if (targetTypeButton === "Order") {
            var targetProductId = event.target.getAttribute('data-diameter-product');
            removeAllChild("content") 
            initOrderProduct(targetProductId)
            console.log(targetProductId);
        }
    }

    handlerAction();


    if (id == 'product') {
       productsHandler(uriProduct)
    }

    if (nameProduct) {
        removeAllChild("signboardType") 
        removeAllChild("signboardDiameters") 
        renderProductType();
    }

    if (ProductType) {
        removeAllChild("signboardDiameters") 
        renderDiameterProduct();
    }

    if (ProductDiameter) {
        renderParammeters();
        removeAllChild("dashboardContent")
        document.getElementById('dashboardContent').insertAdjacentHTML('beforeend', signboardProduct);  
    }

    function removeAllChild(id) {
        if (document.getElementById(id).childNodes.length > 0) {
            let element = document.getElementById(id);
            while (element.firstChild) {
                element.removeChild(element.firstChild);
            }
        }
    }
});

export default navProduct;