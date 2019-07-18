import { statisticsHandler, parametersHandler } from '../js/productsDashboardLogic';


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
        const uriStatistics = `api/ProductParameters/GetSumAmountByParam/${productTypeId}?param=${productParam}&paramId=${productParamId}&paramDiameterId=${paramDiameterId}&diameter=${DiameterValue}`;
        const uriSumPrice = `api/ProductParameters/GetSumPriceByParam/${productTypeId}?param=${productParam}&paramId=${productParamId}&paramDiameterId=${paramDiameterId}&diameter=${DiameterValue}`;
        if (target && productTypeId == rodId) {
   
            statisticsHandler(uriStatistics, uriSumPrice);
            parametersHandler(uriParameters); 
           // testPagination();  
        }
        if (target && productTypeId == tubeId) {
            statisticsHandler(uriStatistics, uriSumPrice);
            parametersHandler(uriParameters);
        }

        
        function testPagination() {
            const pagination = `
<nav aria-label="Page navigation">
  <ul class="pagination justify-content-end" id="pagination">
    <li class="page-item disabled">Previous
    </li>
    <li class="page-item">1</li>
    <li class="page-item">2</li>
    <li class="page-item">3</li>
    <li class="page-item">Next
    </li>
  </ul>
</nav>
`;
            document.getElementById('dashboardContent').insertAdjacentHTML('beforeend', pagination);
        }
    }

    document.body.addEventListener('click', handleParameters(event));
}