import { getData } from './getData';

 function parametersHandler(uriProduct) {
    getData(uriProduct)
        .then(function (json) {
            console.log(json);
            let old_element = document.getElementById("wrapperPagination");
            let new_element = old_element.cloneNode(true);
            old_element.parentNode.replaceChild(new_element, old_element);
            handlePagination(json, formatParameters, "listProductsParameters");
        });
}

function handlePagination(json, viewTable, idContainerTable) {

    const pagination = document.querySelector('#pagination');

    

    const onPage = 30;
    const countPage = Math.ceil(json.length / onPage);

    document.getElementById("pagination").innerHTML = '';
  //  removeAllchildren("pagination");
    let items = [];

    for (let i = 1; i <= countPage; i++) {
        let li = document.createElement('li');
        li.innerHTML = i;
        li.className = 'page-item page-number p-2';
        li.setAttribute("data-numPage", i);
        pagination.appendChild(li);
        items.push(li);
    }
     //let firstLi = document.createElement('li');
    //firstLi.innerHTML = 'Пред';
    //firstLi.className = 'page-item p-2';
    //firstLi.setAttribute("data-prev", -1);
    //pagination.appendChild(firstLi);

    //let lastLi = document.createElement('li');
    //lastLi.innerHTML = 'След.';
    //lastLi.className = 'page-item p-2';
    //lastLi.setAttribute("data-next", +1);
    //pagination.appendChild(lastLi);

     // showContent(items[0]);

    //for (let elem of items) {
    //    elem.addEventListener('click', function (e) {
    //        showContent(this, e);
    //    });
    //}

    showContent(undefined, items[0]);

    pagination.addEventListener('click', showContent);

    function classActiveSwitcher(event) {
        const targetTool = event.target.getAttribute('data-numPage');
        const listTools = document.querySelectorAll('.page-number');

        if (targetTool) {
            listTools.forEach((activeclass) => {
                activeclass.classList.remove('activePage');
            });
            event.target.classList.add('activePage');
        }
    }
   

    function showContent(e, li) {

        let item = document.querySelector('#pagination li[data-numPage]');
        let pageNum;

        if (e === undefined) {
            pageNum = li.getAttribute('data-numPage');
            li.classList.add('activePage');
        }
        else {
            if (!e.target.getAttribute('data-numPage')) {
                return false;
            }
            pageNum = e.target.getAttribute('data-numPage');
            classActiveSwitcher(e);
        } 

        let pagePrev = item.getAttribute("data-prev");
        let pageNext = item.getAttribute("data-next");

        let start;
        let countPage = 0;

        if (pageNum) {
            start = (pageNum - 1) * onPage;  
        }

        //countPage = pageNum;
        //if (e.target.getAttribute('data-prev')) {
        //    start = (countPage - 2) * onPage;
        //    pageNum--;
        //}

        //if (e.target.getAttribute('data-next')) {
        //    start = countPage + 1 * onPage;
        //    countPage++;
        //    pageNum++;
        //}

        let end = start + onPage;
        let notes = json.slice(start, end);
        let countItem = (pageNum - 1) * onPage;
        
        removeAllchildren(idContainerTable);
        if (viewTable === null) {
            return false;            
        }

        for (let i = 0; i < notes.length; i++) {
            viewTable(notes, i, countItem + i);
        }
    }
}

function removeAllchildren(id) {
    if (document.getElementById(id) === null) return false;
    if (document.getElementById(id).childNodes.length > 0) {
        let element = document.getElementById(id);
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }
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


function formatParameters(item, i, count) {
    let paramDiameter;
    let paramSteel;
    let paramType;

    let typeId = item[i].nameType;

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
         <th scope="row">${ count + 1}</th>
         <th>${ item[i].nameType }</th>
         <th>${ item[i].number }</th>
         <th>${ item[i].manufacturer }</th>
         <th>${ item[i].parameters[0].value }</th>
         <th>${ paramSteel }</th>
         <th>${ paramDiameter } &#8960;</th>
         <th>${ item[i].primeCostEUR }</th>
         <th>${ (item[i].amount).toFixed(2) } м.</th>
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

function getDubleOptions(uriFirst, uriSecond) {

    const result = Promise.all([
        fetch(uriFirst),
        fetch(uriSecond)
    ]).then(async ([items, valueCurrency]) => {
        const a = await items.json();
        const b = await valueCurrency.json();
        return [a, b];
    }).catch(function (error) {
        console.log(error);
    });

    return result;
}

function statisticsHandler(uriGetSum, uriGetSumPrice) {
    getDubleOptions(uriGetSum, uriGetSumPrice)
        .then(function (json) {
        console.log(json);
        formatStatistics(json[0], json[1])
    });
}

function formatStatistics( valueSum, valuePrice) {
    const statisticsRow = `
   <tr class="">
         <th scope="row" colspan="3">Общая длинна в м. : ${valueSum}</th>
         <th scope="row" colspan="3">Oбщая стоймость EUR: ${valuePrice}</th>
         <th></th>
         <th></th>
         <th></th>
         <th></th>
         <th></th>
         <th></th>
         <th></th>
     </tr>
     `;

    document.getElementById('headerTable').insertAdjacentHTML('beforeend', statisticsRow);    
}

export { statisticsHandler, parametersHandler }
export { handlePagination }
// /////////////////// 
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
