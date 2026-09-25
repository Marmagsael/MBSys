window.downloadFile = (fileName, base64) => {
    const link = document.createElement("a");
    link.href =
        "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64," +
        base64;
    link.download = fileName;
    link.click();
};

window.downloadCsvFile = function (filename, content) {
    const blob = new Blob([content], { type: 'text/csv;charset=utf-8;' });
    const url  = URL.createObjectURL(blob);
    const a    = document.createElement('a');
    a.href     = url;
    a.download = filename;
    a.click();
    URL.revokeObjectURL(url);
};