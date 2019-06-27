import addProduct from '../js/addProductLogic';

addProduct();
const addProductForm = `
      <div class="col">
            <form id="DataForm">
                <div class="col flex-row wrapper-addProduct">
                    <div class="col-2 form-group input-update">
                        <label>Имя товара</label>
                        <select name="productTypeId" class="form-control control-select" id="TypeProduct">
                            <option value="1">Шток хромированный</option>
                            <option value="2">Труба хонингованная</option>
                        </select>
                    </div>
                    <div class="col input-update">
                        <label>Номер</label>
                        <input name="number" class="form-control" id="number" value="" maxlength="15"/>
                    </div>
                    <div class="col input-update">
                        <label>Диаметр</label>
                        <input name="parameters" class="form-control" id="diameter" value="" maxlength="10" />
                    </div>

                    <div class="col-2 input-update">
                        <label>Производитель</label>
                        <input name="manufacturer" class="form-control" id="manufacturer" value=""  maxlength="30" />
                    </div>
                   
                    <div class="col form-group input-update">
                        <label>Тип</label>
                        <select name="parameters" class="form-control control-select" id="TypeItem">
                            <option value="Стандарт">Стандарт</option>
                            <option value="ТВЧ">ТВЧ</option>
                            <option value="Полый">Полый</option>
                            <option value="H8">H8</option>
                            <option value="H9">H9</option>
                        </select>
                    </div>
                    <div class="col input-update">
                        <label>Grade steel</label>
                        <input name="parameters" class="form-control" id="gradeSteel" value="" maxlength="10" />
                    </div>
                    <div class="col input-update">
                        <label>ЦенаEUR</label>
                        <input name="primeCostEUR"  class="form-control" id="primeCostEUR" min="0" type="number" step="0.001" value="" />
                    </div>
                    <div class="col input-update">
                        <label>Количество</label>
                        <input name="amount" class="form-control" id="amount" min="0" type="number" step="0.001" value="" />
                    </div>
                    <div class="col justify-content-center btn-add">
                        <button class="btn btn-primary  button-add" id="saveProduct">Добавить</button>
                    </div>
                </div>
            </form>
        </div>
`;

export default addProductForm;


