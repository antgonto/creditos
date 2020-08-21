(function () {
  //Para obtener usuario activo
  "use strict";
  let infoUsuario = sessionStorage.getItem("DatosCliArray");
  infoUsuario = JSON.parse(infoUsuario);
  let cedulaUsuario = infoUsuario[0].Id_Persona;
  console.log("La cedula del usuario es " + cedulaUsuario);
  let datosGastosUsuario = [];

  const uri = "https://localhost:44308/api/Gastos/1";
  function actualizar() {
    event.preventDefault();
    var PrestasmosV = $("#Prestasmos").val();
    var FacturacionMensualV = $("#FacturacionMensual").val();
    var HipotecasV = $("#Hipotecas").val();
    var OtrosGastosV = $("#OtrosGastos").val();
    console.log("dentro de agregar");
    var verificar = true;
    if (!PrestasmosV || !FacturacionMensualV || !HipotecasV || !OtrosGastosV) {
      alert("No puede dejar espacios en blanco");
      verificar = false;
    }
    console.log(cedulaUsuario);
    console.log(PrestasmosV);
    console.log(FacturacionMensualV);
    console.log(HipotecasV);
    console.log(OtrosGastosV);

    if (verificar) {
      const item = {
        idPersona: cedulaUsuario,
        prestamo_Gasto: PrestasmosV,
        factuMensu_Gasto: FacturacionMensualV,
        Hipotecas_Gasto: HipotecasV,
        Otros_Gasto: OtrosGastosV,
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

  function cargarInfoGastos() {
    let url = "https://localhost:44308/api/Gastos/" + cedulaUsuario;
    fetch(url)
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        console.log(json_data);
        datosGastosUsuario = json_data;
        mostrarGastos(datosGastosUsuario);
      })
      .catch((err) => console.log("error", err));
  }

  function mostrarGastos(arrayGastosUsuario) {
    console.log(arrayGastosUsuario);
    $("#Prestasmos").val(arrayGastosUsuario[0].Prestamo_Gasto);
    $("#FacturacionMensual").val(arrayGastosUsuario[0].FactuMensu_Gasto);
    $("#Hipotecas").val(arrayGastosUsuario[0].Hipotecas_Gasto);
    $("#OtrosGastos").val(arrayGastosUsuario[0].Otros_Gasto);
  }

  var init = () => {
    console.log("Estoy en el init");
    cargarInfoGastos();
    var btnPut = document.getElementById("GuardarDatos");
    btnPut.onclick = actualizar;
  };

  init();
})();
