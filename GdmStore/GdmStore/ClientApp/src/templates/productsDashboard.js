import parametersHandler from '../js/productsDashboardLogic';

//function initRenderParammeters() {
//    parametersHandler
//}

//export default initRenderParammeters();

export default function renderParammeters() {
    function removeAllchildren() {
        if (document.getElementById("dashboardContent").childNodes.length > 0) {
            let element = document.getElementById("dashboardContent");
            while (element.firstChild) {
                element.removeChild(element.firstChild);
            }
        }
    }

    function handleParameters(event) {
        const target = event.target.hasAttribute("data-diameterValue");
        const productTypeId = event.target.getAttribute('data-productTypeId');
        const productParam = event.target.getAttribute("data-param");
        const productParamId = event.target.getAttribute("data-paramId");
        const paramDiameterId = event.target.getAttribute("data-diameterId");
        const DiameterValue = event.target.getAttribute("data-diameterValue");
        const rodId = 1;
        const tubeId = 2;
        removeAllchildren();

        const uriParameters = `api/ProductParameters/GetProductByDiameter/${productTypeId}?param=${productParam}&paramId=${productParamId}&paramDiameterId=${paramDiameterId}&diameter=${DiameterValue}`;
       // const uriParametersRod = `api/ProductParameters/GetProductByDiameter/${productTypeId}?param=${productParam}&paramId=${productParamId}&paramDiameterId=${paramDiameterId}&diameter=${DiameterValue}`;

        if (target && productTypeId == rodId) {
            parametersHandler(uriParameters)
        }
        if (target && productTypeId == tubeId) {
            parametersHandler(uriParameters)
        }
    }

    document.body.addEventListener('click', handleParameters(event));
}