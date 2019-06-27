
export default function handlerStatistics() {
    const choices = ["one", "two"];

    function addInput() {
        var newDiv = document.createElement('div');
        var selectHTML = "";
        selectHTML = "<select>";
        for (let i = 0; i < choices.length; i = i + 1) {
            selectHTML += "<option value='" + choices[i] + "'>" + choices[i] + "</option>";
        }
        selectHTML += "</select>";
        newDiv.innerHTML = selectHTML;
        document.getElementById("productType").appendChild(newDiv);
    }

    let body = document.getElementsByTagName("body")[0];
    body.addEventListener("DOMContentLoaded", addInput);
}
