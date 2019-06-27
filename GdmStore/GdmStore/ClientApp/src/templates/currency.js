import { getData } from '../js/getData';

function getValueCurrency(urlNRB) {
    getData(urlNRB)
        .then(function (json) {
            ValueCurrency(json)
        });
}
const urlNRB = 'https://www.nbrb.by/API/ExRates/Rates?Periodicity=0';
export default getValueCurrency(urlNRB);

function ValueCurrency(data) {
    const USD = 4;
    const EUR = 5;

    document.getElementById('valueUSD').textContent = data[USD].Cur_OfficialRate;
    document.getElementById('valueEUR').textContent = data[EUR].Cur_OfficialRate;
}

function showDateNow() {
    let d = new Date();
    document.getElementById('currencyContent').textContent = (
        d.getFullYear() + "." +
        ("00" + (d.getMonth() + 1)).slice(-2) + "." +
        ("00" + d.getDate()).slice(-2)
    );

}
showDateNow()