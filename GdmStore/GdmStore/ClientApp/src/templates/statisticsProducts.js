import handlerStatistics from '../js/statisticsLogic';

//function initStatistics() {
//    handlerStatistics
//}
//initStatistics();
const navStatisticsProducts = `
    <div class="row order-container " id="orderContainer">
         <h2 class="col bg-primary text-white text-center">Статистика товаров</h2>
         <div class="row align-items-center list-button" id="navOrder">
               <div class="col-2 form-group input-update">
                    <label>Имя товара</label>
                    <select name="product" class="form-control" id="Product">
                         <option value="1">Шток хромированный</option>
                         <option value="2">Труба хонингованная</option>
                    </select>
               </div>
               <div class="col-2 form-group input-update" id="productType">
                    <label>Типы товара</label>
                    <select name="type" class="form-control" id="type">
                         <option value="Стандарт">Стандарт</option>
                         <option value="ТВЧ">ТВЧ</option>
                         <option value="ПОЛЫЙ">ПОЛЫЙ</option>
                         <option value="H8">H8</option>
                         <option value="H9">H9</option>
                    </select>
               </div>
               <div class="col-2 form-group input-update" id="productType">
                    <label>Диаметры</label>
                    <select name="diameters" class="form-control" id="diameters">
                         <option value="20">20</option>
                         <option value="25">35</option>
                         <option value="30">30</option>
                         <option value="40">40</option>
                         <option value="50">50</option>
                    </select>
               </div>
                <div class= "col-2 order-buttons">
                  <button class="btn col btn-success text-white  "  id="searchOrders">Сумма</button>
               </div>
         </div>  
    </div>
 `;

export default navStatisticsProducts;

