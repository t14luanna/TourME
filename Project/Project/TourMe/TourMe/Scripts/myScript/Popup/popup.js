function popup(div,close) {
    window.onclick = function (event) {
        if (event.target == div) {
            div.style.display = "none";
        }
    }

    close.onclick = function () {
        div.style.display = "none";
    }
}

