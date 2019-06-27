import { getData } from './getData';

export default function parametersHandler(uriProduct) {
    getData(uriProduct)
        .then(function (json) {
            console.log(json);
            for (let i = 0; i < json.length; i++) {
                formatParameters(json, i)
            }
        });
}

function extractProductParameters(item, i) {
    const productName = item[i].nameType;
    const productNumber = item[i].number;
    const manufacturer = item[i].manufacturer;
    const productType = item[i].parameters[0].value;
    const steelGrade = item[i].parameters[1].value;
    const deameter = item[i].parameters[2].value;
    const primeСost = item[i].primeCostEUR;
    const productAmount = item[i].amount;
    const count = i + 1;
}


function formatParameters(item, i) {
    let paramDiameter;
    let paramSteel;
    let paramType;

    let typeId = item[i].nameType;

    if (typeId === 2) {

    }

    if (item[i].parameters[2] !== undefined) {
        paramDiameter = item[i].parameters[2].value;
        paramSteel = item[i].parameters[1].value
    }
    else {
        paramDiameter = item[i].parameters[1].value;
        paramSteel = '';
    } 

    const parametersRow = `
     <tr class="">
         <th scope="row">${ i + 1 }</th>
         <th>${ item[i].nameType }</th>
         <th>${ item[i].number }</th>
         <th>${ item[i].manufacturer }</th>
         <th>${ item[i].parameters[0].value }</th>
         <th>${ paramSteel }</th>
         <th>${ paramDiameter }</th>
         <th>${ item[i].primeCostEUR }</th>
         <th>${ (item[i].amount).toFixed(2) }</th>
         <th><button  data-button-type="Order" data-diameter-product="${item[i].productId}" class="btn btn-outline-primary">
            Заказ</button>
         </th>
         <th>
            <button data-button-type="Edit" data-diameter-product="${item[i].productId}" class="btn btn-outline-primary" >
            Изменить</button>
         </th>
         <th><button  data-button-type="Remove" data-diameter-product="${item[i].productId}" class="btn btn-outline-danger" >
            Удалить</button>
         </th>
        
     </tr>
   `;
        
    document.getElementById('listProductsParameters').insertAdjacentHTML('beforeend', parametersRow);    
}