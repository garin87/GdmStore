export default function getDubleOptions(uriFirst, uriSecond) {

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