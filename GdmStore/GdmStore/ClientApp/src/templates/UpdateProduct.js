import  viewValueProduct  from '../js/UpdateProductLogic';

//viewValueProduct();

export default function initUpdateProduct(targetProductId) {
    renderUpdateProduct();
    viewValueProduct(targetProductId);
    
}


 function renderUpdateProduct(){
    const updateForm = ` <form id="updateProduct" method="put">
                <div class="col wrapper-list-update">
                    <div data-parametrId1="" data-parametrId2="" data-parametrId3=""  id="parametrId"></div>
                    <div class="col-2 input-update form-group">
                        <label>Имя товара</label>
                        <select class="form-control" id="TypeProductUpdate">
                            <option value="1">Штоки</option>
                            <option value="2">Трубы</option>
                        </select>
                    </div>
                    <div class="col input-update">
                        <label>Номер</label>
                        <input name="Number" class="form-control" id="numberUpdate" maxlength="15"/>
                    </div>
                    <div class="col input-update">
                        <label>Производитель</label>
                        <input name="manufacturer" class="form-control" id="manufacturerUpdate" maxlength="25" />
                    </div>
                    <div class="col input-update">
                        <label>Тип</label>
                        <input name="Type" class="form-control" id="typeUpdate"  maxlength="10"/>
                    </div>
                    <div class="col input-update">
                        <label>Сталь</label>
                        <input name="parameters[]" class="form-control" id="gradeSteelUpdate" maxlength="10"/>
                    </div>
                    <div class="col input-update">
                        <label>Диаметр</label>
                        <input name="Diameter" class="form-control" id="diameterUpdate" maxlength="10"/>
                    </div>
                    <div class="col input-update">
                        <label>Зав. ЦенаEUR</label>
                        <input name="PrimeCostEUR" class="form-control" id="primeCostEURUpdate" min="0" type="number" step="0.001" />
                    </div>
                    <div class="col input-update">
                        <label>Длина</label>
                        <input name="Amount" class="form-control" id="amountUpdate" min="0" type="number" step="0.001" />
                    </div>
                    <div class="col justify-content-center btn-add">
                        <button  class="btn btn-primary  button-add" id="saveUpdate">Сохранить</button>
                    </div>
                </div>
            </form>
`;

  document.getElementById('content').insertAdjacentHTML('beforeend', updateForm); 

}
  





