// Función para mostrar u ocultar info y girar flecha
function toggleDetails(btnId, detailsId, arrowClass) {
    document.getElementById(btnId).addEventListener("click", function () {
        var details = document.getElementById(detailsId);
        var arrow = document.querySelector(arrowClass);

        // Si la información está oculta, la mostramos
        if (details.style.display === "none" || details.style.display === "") {
            details.style.display = "block"; // Mostramos los detalles
            arrow.style.transform = "rotate(180deg)"; // Giramos la flecha hacia arriba...
        } else {
            details.style.display = "none"; // Ocultamos los detalles
            arrow.style.transform = "rotate(0deg)"; // Giramos la flecha hacia abajo
        }
    });
}

//estos son los parametros
toggleDetails("toggleBtn", "bookDetails", ".arrow");
toggleDetails("toggleBtn1", "bookDetails1", ".arrow1");
toggleDetails("toggleBtn2", "bookDetails2", ".arrow2");
toggleDetails("toggleBtn3", "bookDetails3", ".arrow3");
toggleDetails("toggleBtn4", "bookDetails4", ".arrow4");
toggleDetails("toggleBtn5", "bookDetails5", ".arrow5");
toggleDetails("toggleBtn6", "bookDetails6", ".arrow6");
toggleDetails("toggleBtn7", "bookDetails7", ".arrow7");
toggleDetails("toggleBtn8", "bookDetails8", ".arrow8");
