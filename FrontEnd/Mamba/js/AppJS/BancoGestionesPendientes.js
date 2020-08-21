(function () {
  //Para obtener usuario activo
  "use strict";

  let datosGastosUsuario = [];
  let codigoTrabjo;
  let datosGestion = [];

  function cargarDatos() {
    let url = "https://localhost:44308/api/GestionesPendientes";
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
    let cont = 0;
    for (let valor of datos) {
      contenido.innerHTML += `
        <tr>
                        <td>${valor.Id_Persona}</td>
                        <td>${valor.ValorCredito}</td>
                        <td>${valor.PlazoCredito}</td>
                        <td>${valor.Descripcion}</td>
                        <td><a  id="${cont}" style="color: dimgrey;" href='BancoDetalleCliente.html'>Ver datos cliente</a></td>
                      </tr>
        `;

      cont = cont + 1;
      datosGestion.push(valor);
    }
    console.log("datos gestion");
    console.log(datosGestion);
  }
  $("#contenido").on("click", "a", function () {
    var id = $(this).attr("id");
    sessionStorage.setItem("idLC", id); //Indice seleccionado que se va a editar
    sessionStorage.setItem("datosGestion", JSON.stringify(datosGestion));
  });

  var init = () => {
    console.log("Estoy en el init");
    cargarDatos();
  };

  init();
})();
