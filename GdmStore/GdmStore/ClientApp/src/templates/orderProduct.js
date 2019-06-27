import orderHandler from '../js/orderProductLogic';

export default function initOrderProduct(targetProductId) {
    renderOrderProduct();
    orderHandler(targetProductId);
    console.log(targetProductId)
}


function renderOrderProduct() {
    const orderForm = `      <form id="orderSave" method="post">
                <div class="col wrapper-list-order">
                    <div class="col input-update">
                        <label>Номер</label>
                        <input name="Number" class="form-control" id="numberProduct" disabled />
                    </div>
                    <div class="col input-update">
                        <label>ЦенаBLR 1м.</label>
                        <input name="priceProduct" class="form-control" id="priceProductBLR" disabled />
                    </div>
                    <div class="col-2 input-update">
                        <label>Имя компания</label>
                        <input name="nameCompany" class="form-control" id="nameCompany" />
                    </div>
                    <div class="col-1 input-update">
                        <label>Длинна</label>
                        <input name="amount" class="form-control" id="amountProduct" />
                    </div>
                    <div class="col-1 input-update">
                        <label>Цена</label>
                        <input name="price" class="form-control" id="priceProduct" />
                    </div>
                    <div class="col-1 input-update">
                        <label>Цена10%</label>
                        <input name="amount10" class="form-control" id="price10" value="" disabled />
                    </div>
                    <div class="col-1 input-update">
                        <label>Цена15%</label>
                        <input name="amount15" class="form-control" id="price15" value="" disabled />
                    </div>
                    <div class="col-1 input-update">
                        <label>Цена20%</label>
                        <input name="amount20" class="form-control" id="price20" value="" disabled />
                    </div>
                    <div class="col-1 input-update">
                        <label>Цена25%</label>
                        <input name="amount25" class="form-control" id="price25" value="" disabled />
                    </div>
                    <div class="col justify-content-center btn-add order-save">
                        <button type="submit" class="btn btn-primary  button-add" id="saveOrder">Сохранить</button>
                    </div>
                </div>
            </form>
`;

    document.getElementById('content').insertAdjacentHTML('beforeend', orderForm);

}
