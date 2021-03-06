﻿import { getData } from './getData';


///////////////////////////////////////////////////////////////////////////
export default function orderHandler(targetProductId) {

    const uriGetParamOrder = 'api/Products/GetParamForOrder/';
    const urlNRB = 'https://www.nbrb.by/API/ExRates/Rates?Periodicity=0';

    viewPriceBLR(uriGetParamOrder + targetProductId, urlNRB);

    function getDubleOptions(uriGetParamOrder, urlNRB) {
        const result = Promise.all([
            fetch(uriGetParamOrder),
            fetch(urlNRB)
        ]).then(async ([items, valueCurrency]) => {
            const a = await items.json();
            const b = await valueCurrency.json();
            return [a, b];
        }).catch(function (error) {
            console.log(error);
        });

        return result;
    }

    function viewPriceBLR(uriGetParamOrder, urlNRB) {
        getDubleOptions(uriGetParamOrder, urlNRB).then(function (json) {
            console.log(json);
            for (let i = 0; i < json[0].length; i++) {
                formatPriceBLR(json[0], i, json[1])
                ValueOrder(json[0], i, json[1])
            }
        });
    }

    function ValueOrder(item, i, valueBLR) {
        document.getElementById('numberProduct').value = item[0].number;
        document.getElementById('priceProductBLR').value = (item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate).toFixed(2);
        document.getElementById('price15').value = ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.15).toFixed(2);
        document.getElementById('price15').setAttribute('data-selling-price', ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.15).toFixed(2));
        document.getElementById('price20').value = ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.20).toFixed(2);
        document.getElementById('price20').setAttribute('data-selling-price', ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.20).toFixed(2));
        document.getElementById('price25').value = ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.25).toFixed(2);
        document.getElementById('price25').setAttribute('data-selling-price', ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.25).toFixed(2));
        document.getElementById('price30').value = ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.30).toFixed(2);
        document.getElementById('price30').setAttribute('data-selling-price', ((item[0].primeCostEUR * valueBLR[5].Cur_OfficialRate) * 1.30).toFixed(2));
        
    }

    function formatPriceBLR(item, i, valueBLR) {
        let productPrice = item[i].price * valueBLR[4].Cur_OfficialRate;
    }
    document.getElementById('orderSave').addEventListener('click', function (e) {
        const targetPrice = e.target.getAttribute("data-selling-price");
        if (!targetPrice) { return false; }

        if (targetPrice) {
            document.getElementById('priceProduct').value = targetPrice;
        }

    });
    /////////////////////////add order
    document.getElementById('saveOrder').addEventListener('click', function (ev) {
        ev.preventDefault();

        let data = {
            "id": 0,
            "nameCompany": (document.getElementById('nameCompany')).value.toUpperCase(),
            "price": (document.getElementById('priceProduct')).value,
            "productId": targetProductId,
            "amount": (document.getElementById('amountProduct')).value
        }

        const uri = "api/Orders/addOrderProduct";

        fetch(uri, {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        })
            .then(res => {
                return res.json()
            })
            .then(response => {
                if (response.status = 200) alert("Добавлен новый заказ")
                console.log('Success:', JSON.stringify(response))
            }

            )
            .catch((error) => {
                console.error(error);
            });
    });
}

