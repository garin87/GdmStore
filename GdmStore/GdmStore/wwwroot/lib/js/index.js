var uri = 'api/Products';

var btnPistonRods = document.getElementById("piston-rods");
var bthCylinderTubes = document.getElementById("cylinder-tubes");

function createTable(json) {
    let tableElem, tr, td;

    tableElem = document.createElement('table');
    tableElem.style.border = "1px solid black";
    tableElem.style.borderCollapse = "collapse";

    var namesField = Object.getOwnPropertyNames(json[0]);
    //  console.log(namesField);
    tableElem = document.createElement('table');

    for (let i = 0; i < json.length; i++) {
        tr = document.createElement('tr');
        tr.style.border = "1px solid black";

        for (let j = 0; j < Object.keys(json[0]).length; j++) {

            td = document.createElement('td');
            td.style.border = "1px solid black";
            td.style.padding = "5px";

            if (i === 0) {
                td.appendChild(document.createTextNode(namesField[j]));
            }

            if (i > 0) {
                td.appendChild(document.createTextNode(json[i][namesField[j]]));
            }

            tr.appendChild(td);
        }

        tableElem.appendChild(tr);
    }

    document.body.appendChild(tableElem);

}

// btnPistonRods.addEventListener('click', function () {
function test() {
    getOptions(uri)
        .then(function (json) {
            //tableCreate(json);
            createTable(json);
            //let temp = Object.keys(json[0]);
            // let str = json[1];
            //console.log(str[temp[1]]);
            for (let i = 0; i < json.length; i++) {
                console.log(json[i]);
                formatItem(json, i)
            }
        });
}

test();
// });

function getOptions(uri) {
    let result = fetch(uri)
        .then(function (response) {
            if (!response.ok) {
                throw new Error("HTTP error, status = " + response.status);
            }
            return response.json();
        })
        .catch(function (error) {
            console.log(error);
        });

    return result;
}

function formatItem(item, i) {
    let li = document.createElement('li');
    li.innerHTML = " 'ProductId ('" + item[i].ProductId + "') '" + item[i].Name + " "
        + item[i].Number + " " + item[i].Amount + " " + item[i].PrimeCostEUR;
    document.getElementById("list-group-item").appendChild(li);
}