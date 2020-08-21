(function () {
  //Para obtener usuario activo
  "use strict";

  let datosGastosUsuario = [];
  let codigoTrabjo;

  function cargarDatos() {
    let cedula = sessionStorage.getItem("cedula");
    let url = "https://localhost:44308/api/GestionFormulario/" + cedula;
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
    var cont = 0; //se utiliza para obtener indice por editar
    for (let valor of datos) {
      contenido.innerHTML += `
        <tr>
                        <td>${valor.id}</td>
                        <td>${valor.ValorCredito}</td>
                        <td>${valor.PlazoCredito}</td>
                        <td>${valor.Descripcion}</td>                       
                       <td><a  id="${valor.id}" style="color: dimgrey;" href='respuestaBanco.html'>Ver 
                      </tr>
        `;
      cont = cont + 1;
      //  ArrLC.push(valor);
    }
  }
  $("#contenido").on("click", "a", function () {
    var id = $(this).attr("id");
    sessionStorage.setItem("idGestion", id); //Indice seleccionado que se va a editar
  });

  var init = () => {
    console.log("Estoy en el init");
    cargarDatos();
  };

  init();
})();
