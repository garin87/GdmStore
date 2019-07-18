
function filterNumber(evt) {

    if (evt.keyCode != 8) {
        var theEvent = evt;
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);

        var regex = /\d{3}|[^\d{2}\.]|^\./;
        var reg = /\d+(\.\d\d\d\d)/;
        if (regex.test(key)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault) {
                theEvent.preventDefault();
            }
        }
        
        if (regex.test(key)) {
            if (reg.test(document.getElementById("amount").value)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) {
                    theEvent.preventDefault();
                }
            }
        }
    }
}

export default function addProduct() {
    document.body.addEventListener('click', addProduct);
   

    function addProduct(ev) {
        if (ev.target.id === 'saveProduct') {
            ev.preventDefault();

            let typeItem;
            let diameterItem;
            let data;

            if (document.getElementById('TypeProduct').value == 1) {
                typeItem = 1;
                diameterItem = 4;
                data = {
                    "productId": 0,
                    "number": document.getElementById('number').value.toUpperCase(),
                    "amount": document.getElementById('amount').value,
                    "primeCostEUR": document.getElementById('primeCostEUR').value,
                    "manufacturer": document.getElementById('manufacturer').value.toUpperCase(),
                    "productTypeId": 1,
                    "parameters": [
                        {
                            "parameterId": typeItem,
                            "value": document.getElementById('TypeItem').value.toUpperCase()
                        },
                        {
                            "parameterId": 3,
                            "value": document.getElementById('gradeSteel').value.toUpperCase()
                        },
                        {
                            "parameterId": diameterItem,
                            "value": document.getElementById('diameter').value
                        }
                    ]
                }
            }
            else if (document.getElementById('TypeProduct').value == 2) {
                typeItem = 2;
                diameterItem = 1003;
                data = {
                    "productId": 0,
                    "number": document.getElementById('number').value.toUpperCase(),
                    "amount": document.getElementById('amount').value,
                    "primeCostEUR": document.getElementById('primeCostEUR').value,
                    "manufacturer": document.getElementById('manufacturer').value.toUpperCase(),
                    "productTypeId": 2,
                    "nameType": null,
                    "parameters": [
                        {

                            "parameterId": typeItem,
                            "value": document.getElementById('TypeItem').value.toUpperCase()
                        },
                        {

                            "parameterId": diameterItem,
                            "value": document.getElementById('diameter').value
                        }
                    ]
                }
            }

            let uri = "api/Products/AddProducts"

            fetch(uri, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data)
            })
            .then(res => {
                    return res.json()
                })
            .then(response => {
                    if (response.status = 200) alert("Добавлен новый продукт")
                    console.log('Success:', JSON.stringify(response))
            })
            .catch((error) => {
                    console.error(error);
            });
        }
    }
} 