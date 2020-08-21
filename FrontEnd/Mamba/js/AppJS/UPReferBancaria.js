(function () {
  //Para obtener usuario activo
  "use strict";
  let infoUsuario = sessionStorage.getItem("DatosCliArray");
  infoUsuario = JSON.parse(infoUsuario);
  let cedulaUsuario = infoUsuario[0].Id_Persona;
  console.log("La cedula del usuario es " + cedulaUsuario);
  let datosGastosUsuario = [];

  function actualizar() {
    const uri = "https://localhost:44308/api/ReferenciaBancaria/1";
    event.preventDefault();
    var InstitucionBancariaV = $("#InstitucionBancaria").val();
    var CuentaCorrienteV = $("#CuentaCorriente").val();
    var CajaAhorrosV = $("#CajaAhorros").val();
    var PrestamoV = $("#Prestamo").val();
    var SaldoPrestamoV = $("#SaldoPrestamo").val();
    var DireccionV = $("#Direccion").val();
    var TelefonoV = $("#Telefono").val();
    console.log("dentro de agregar");

    var verificar = true;

    if (
      !InstitucionBancariaV ||
      !CuentaCorrienteV ||
      !CajaAhorrosV ||
      !PrestamoV ||
      !SaldoPrestamoV ||
      !DireccionV ||
      !TelefonoV
    ) {
      console.log("No puede dejar espacios en blanco");
      verificar = false;
    }
    console.log(cedulaUsuario);
    console.log(InstitucionBancariaV);
    console.log(CuentaCorrienteV);
    console.log(CajaAhorrosV);
    console.log(PrestamoV);
    console.log(SaldoPrestamoV);
    console.log(DireccionV);
    console.log(TelefonoV);
    if (verificar) {
      const item = {
        idPersona: cedulaUsuario,
        NomInst_ReferBan: InstitucionBancariaV,
        CuentaCorriente_ReferBan: CuentaCorrienteV,
        CajaAhorros_ReferBan: CajaAhorrosV,
        Prestamo_ReferBan: PrestamoV,
        SaldoPrestamo_ReferBan: SaldoPrestamoV,
        Direc_ReferBan: DireccionV,
        Tel_ReferBan: TelefonoV,
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
    let url = "https://localhost:44308/api/ReferenciaBancaria/" + cedulaUsuario;
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
    $("#InstitucionBancaria").val(array[0].Nominst_ReferBan);
    $("#CuentaCorriente").val(array[0].CuentaCorriente_ReferBan);
    $("#CajaAhorros").val(array[0].CajaAhorros_ReferBan);
    $("#Prestamo").val(array[0].Prestamo_ReferBan);
    $("#SaldoPrestamo").val(array[0].SaldoPrestamo_ReferBan);
    $("#Direccion").val(array[0].Direc_ReferBan);
    $("#Telefono").val(array[0].Tel_ReferBan);
  }

  var init = () => {
    console.log("Estoy en el init");
    cargarDatos();
    var btnPut = document.getElementById("GuardarDatos");
    btnPut.onclick = actualizar;
  };

  init();
})();
