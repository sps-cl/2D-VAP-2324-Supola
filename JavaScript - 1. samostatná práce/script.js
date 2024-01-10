function vytvoritTabulku() {
    var table = document.getElementById("myTable");

    while (table.firstChild) {
        table.removeChild(table.firstChild);
    }

    var rows = document.getElementById("pocet-radku").value;
    var columns = document.getElementById("pocet-sloupcu").value;

    var tbody = document.createElement("tbody");

    for (var i = 0; i < rows; i++) {
        var row = document.createElement("tr");

        for (var j = 0; j < columns; j++) {
            var cell = document.createElement("td");
            var cellText = document.createTextNode(i * columns + j + 1);
            cell.appendChild(cellText);
            row.appendChild(cell);
        }

        tbody.appendChild(row);
    }

    table.appendChild(tbody);
}
