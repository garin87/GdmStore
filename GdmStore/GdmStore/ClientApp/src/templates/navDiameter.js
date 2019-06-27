import diameterHandler from '../js/navDiameterLogic';

const productDiameter = `
   <h2 class="p-1 diameters-value text-center col-12">
   Диаметры</h2>
   <div class="col list-diameters" id="listDiameters">
   </div>
`

export default function renderDiameterProduct() {
    document.getElementById('signboardDiameters').insertAdjacentHTML('beforeend', productDiameter);

    function removeAllchildren() {
        if (document.getElementById("listDiameters").childNodes.length > 0) {
            let element = document.getElementById("listDiameters");
            while (element.firstChild) {
                element.removeChild(element.firstChild);
            }
        }
    }

    function handleDiameter(event) {
        const target = event.target.hasAttribute("data-ProductType");
        const productId = event.target.getAttribute('data-productid');
        const productType = event.target.getAttribute("data-producttype");
        const rodId = 1;
        const tubeId = 2;
        removeAllchildren();
        if (target && productId == rodId) {
            const uriDiameterRod = `/api/ProductParameters/GetProductDiameters/4?param=${productType}&paramId=${productId}`;
            diameterHandler(uriDiameterRod)
        }
        if (target && productId == tubeId) {
            const uriDiameterTube = `/api/ProductParameters/GetProductDiameters/1003?param=${productType}&paramId=${productId}`;
            diameterHandler(uriDiameterTube)
        }
    }

    document.body.addEventListener('click', handleDiameter(event));
}