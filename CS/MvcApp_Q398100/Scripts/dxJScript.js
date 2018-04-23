var param = "";
function SelectGroupedRows(index, isSelect) {
    param =  index + "|" + isSelect;
    dxGridView.PerformCallback();
}

function onBeginCallback(s, e) {
    e.customArgs["parameters"] = param;
}
