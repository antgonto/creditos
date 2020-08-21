(function () {
  //Para obtener usuario activo

  const uri = "https://localhost:44308/api/ReferenciaBancaria";
  function inserta() {
    event.preventDefault();
    var verificar = true;
    var cedula = sessionStorage.getItem("cedula", cedula);
    var InstitucionBancariaV = $("#InstitucionBancaria").val();
    var CuentaCorrienteV = $("#CuentaCorriente").val();
    var CajaAhorrosV = $("#CajaAhorros").val();
    var PrestamoV = $("#Prestamo").val();
    var SaldoPrestamoV = $("#SaldoPrestamo").val();
    var DireccionV = $("#Direccion").val();
    var TelefonoV = $("#Telefono").val();
    console.log("dentro de agregar");
    if (
      !InstitucionBancariaV ||
      !CuentaCorrienteV ||
      !TelefonoV ||
      !CajaAhorrosV ||
      !PrestamoV ||
      !SaldoPrestamoV
    ) {
      alert(
        "Institución Bancaria, Cuenta Corriente y teléfono son campos obligatorios"
      );
      verificar = false;
    }

    console.log(cedula);
    console.log(InstitucionBancariaV);
    console.log(CuentaCorrienteV);
    console.log(CajaAhorrosV);
    console.log(PrestamoV);
    console.log(SaldoPrestamoV);
    console.log(DireccionV);
    console.log(TelefonoV);
    if (verificar) {
      const item = {
        idPersona: cedula,
        NomInst_ReferBan: InstitucionBancariaV,
        CuentaCorriente_ReferBan: CuentaCorrienteV,
        CajaAhorros_ReferBan: CajaAhorrosV,
        Prestamo_ReferBan: PrestamoV,
        SaldoPrestamo_ReferBan: SaldoPrestamoV,
        Direc_ReferBan: DireccionV,
        Tel_ReferBan: TelefonoV,
      };

      fetch(uri, {
        method: "POST",
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
          if (response == "Se guardó la referencia bancaria") {
            alert(response);
            location.href = "Tcredito.html";
          } else {
            alert("Error al ingresar los datos");
          }
        })
        .catch((error) => {
          console.log("dentro de catch");
          console.error("Unable to add item.", error);
          alert("No se guardó");
        });
      // $("#formulario").trigger("reset");
    }
  }

  var init = () => {
    var btnPost = document.getElementById("GuardarDatos");
    btnPost.onclick = inserta;
  };

  init();
})();
