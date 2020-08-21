(function () {
  //Para obtener usuario activo
  "use strict";
  let infoUsuario = sessionStorage.getItem("DatosCliArray");
  infoUsuario = JSON.parse(infoUsuario);
  let cedulaUsuario = infoUsuario[0].Id_Persona;
  console.log("La cedula del usuario es " + cedulaUsuario);
  let datosGastosUsuario = [];

  function actualizar() {
    const uri = "https://localhost:44308/api/OtrosIngresos/1";
    event.preventDefault();

    var OtrosueldoV = $("#OtroSueldo").val();
    var BonosComisionesV = $("#BonosComisiones").val();
    var RentasV = $("#Rentas").val();
    var InversionesV = $("#Inversiones").val();
    var OtrosIngresos = $("#OtrosIngresos").val();
    console.log("dentro de agregar");
    var verificar = true;
    if (
      !OtrosueldoV ||
      !BonosComisionesV ||
      !RentasV ||
      !InversionesV ||
      !OtrosIngresos
    ) {
      alert("No puede dejar espacios en blanco");
      verificar = false;
    }
    console.log(cedulaUsuario);
    console.log(OtrosueldoV);
    console.log(BonosComisionesV);
    console.log(RentasV);
    console.log(InversionesV);
    console.log(OtrosIngresos);

    if (verificar) {
      const item = {
        idPersona: cedulaUsuario,
        Sueldo_OtrosIngree: OtrosueldoV,
        BonosComision_OtrosIngree: BonosComisionesV,
        Rentas_OtrosIngree: RentasV,
        Inversión_OtrosIngree: InversionesV,
        Otros_OtrosIngree: OtrosIngresos,
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
    let url = "https://localhost:44308/api/OtrosIngresos/" + cedulaUsuario;
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
    $("#OtroSueldo").val(array[0].Sueldo_OtrosIngree);
    $("#BonosComisiones").val(array[0].BonosComision_OtrosIngree);
    $("#Rentas").val(array[0].Rentas_OtrosIngree);
    $("#Inversiones").val(array[0].Inversión_OtrosIngree);
    $("#OtrosIngresos").val(array[0].Otros_OtrosIngree);
  }

  var init = () => {
    console.log("Estoy en el init");
    cargarDatos();
    var btnPut = document.getElementById("GuardarDatos");
    btnPut.onclick = actualizar;
  };

  init();
})();
