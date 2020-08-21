(function () {
  //Para obtener usuario activo
  "use strict";
  function salir() {
    localStorage.clear();
    location.href = "index.html";
  }

  var init = () => {
    let btnSalir = document.getElementById("salirBanco");
    btnSalir.onclick = salir;
  };

  init();
})();
