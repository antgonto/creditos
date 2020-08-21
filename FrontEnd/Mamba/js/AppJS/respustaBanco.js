(function () {
  //Para obtener usuario activo
  "use strict";

  let datosGastosUsuario = [];
  let codigoGestion = sessionStorage.getItem("idGestion");

  function cargarDatos() {
    console.log("id gestion " + codigoGestion);
    let url = "https://localhost:44308/api/Banco/" + codigoGestion;
    fetch(url)
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        console.log(json_data);
        datosGastosUsuario = json_data;
        generarTabla(datosGastosUsuario);
      })
      .catch((err) => console.log("error", err));
  }

  function generarTabla(datos) {
    var contenido = document.querySelector("#contenido");
    console.log("Dentro de generar tabla");
    console.log(datos);
    contenido.innerHTML = "";
    for (let valor of datos) {
      contenido.innerHTML += `
        <tr>
                        <td>${valor.id_Gestion}</td>
                        <td>${valor.nombreEntidad}</td>
                        <td>${valor.respuesta}</td>                              
                      
                      </tr>
        `;
    }
  }

  var init = () => {
    console.log("Estoy en el init");
    cargarDatos();
  };

  init();
})();
