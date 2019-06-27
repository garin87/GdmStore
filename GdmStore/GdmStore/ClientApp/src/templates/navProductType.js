import productsTypeHandler from '../js/navProductTypeLogic';
const productType = `
   <h2 class="col  text-center type-captions">Типы товаров</h2>
   <div class="col list-types text-left flex-row list-type" id="listTypes">
   </div>
`
export default function renderProductType() {
    document.getElementById('signboardType').insertAdjacentHTML('beforeend', productType);
    function removeAllchildren() {
        if (document.getElementById("listTypes").childNodes.length > 0) {
            let element = document.getElementById("listTypes");
            while (element.firstChild) {
                element.removeChild(element.firstChild);
            }
        }
    }

    function getType(event) {
        const target = event.target.hasAttribute("data-NameProductId");
        const ProductId = event.target.getAttribute('data-NameProductId');
        const uriType = "api/ProductParameters/GetProductParameters/";
        removeAllchildren();
        if (target) {
            productsTypeHandler(uriType + ProductId)
        }
    }

    document.body.addEventListener('click', getType(event));
}
