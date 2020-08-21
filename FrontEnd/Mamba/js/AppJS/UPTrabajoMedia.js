(function () {
  //Para obtener usuario activo
  "use strict";
  let infoUsuario = sessionStorage.getItem("DatosCliArray");
  infoUsuario = JSON.parse(infoUsuario);
  let cedulaUsuario = infoUsuario[0].Id_Persona;
  console.log("La cedula del usuario es " + cedulaUsuario);
  let datosGastosUsuario = [];
  let codigoTrabjo;

  const uri = "https://localhost:44308/api/Trabajo_Persona/1";
  function actualizar() {
    event.preventDefault();
    var SueldoV = $("#Sueldo").val();
    var FechaIngresoV = $("#FechaIngreso").val();
    var PuestoTrabajoV = $("#PuestoTrabajo").val();

    console.log("dentro de agregar");
    var verificar = true;
    if (!SueldoV || !FechaIngresoV || !PuestoTrabajoV) {
      alert("Espacio de descripción requerido");
      verificar = false;
    }

    console.log(SueldoV);
    console.log(FechaIngresoV);
    console.log(PuestoTrabajoV);
    if (verificar) {
      const item = {
        Cod_Trabajo: codigoTrabjo,
        Id_Persona: cedulaUsuario,
        SueldoMen_Trabajo: SueldoV,
        FechaIngrso_Trabajo: FechaIngresoV, //en la base dice  FechaIngrso
        Puesto_Trabajo: PuestoTrabajoV,
      };

      fetch(uri, {
        method: "PUT",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(item),
      })
        .then((response) => response.json())
        .then((response) => {
          console.log(response);
          console.log("dentro de then");
          alert(response);
          location.href = "Principal.html";
        })
        .catch((error) => {
          console.log("dentro de catch");
          console.error("Unable to add item.", error);
          alert("No se guardó");
          //location.href = "Principal.html";
        });
      // $("#formulario").trigger("reset");
    }
  }
  function cargarDatos() {
    let url = "https://localhost:44308/api/Trabajo_Persona/" + cedulaUsuario;
    fetch(url)
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        console.log(json_data);
        datosGastosUsuario = json_data;
        mostrarDatos(datosGastosUsuario);
      })
      .catch((err) => console.log("error", err));
  }

  function mostrarDatos(array) {
    console.log(array);
    $("#Sueldo").val(array[0].SueldoMen_Trabajo);
    $("#FechaIngreso").val(array[0].FechaIngrso_Trabajo);
    $("#PuestoTrabajo").val(array[0].Puesto_Trabajo);
    codigoTrabjo = array[0].CodTrabajo;
  }

  var init = () => {
    console.log("Estoy en el init");
    cargarDatos();
    var btnPut = document.getElementById("GuardarDatos");
    btnPut.onclick = actualizar;
  };

  init();
})();
