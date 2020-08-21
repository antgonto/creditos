(function () {
  //Para obtener usuario activo

  const uri = "https://localhost:44308/api/CreditCard";
  function inserta() {
    event.preventDefault();
    var verificar = true;
    var cedula = sessionStorage.getItem("cedula", cedula);
    var NombreTarjetaV = $("#NombreTarjeta").val();
    var NumeroCuentaV = $("#NumeroCuenta").val();
    var SaldoV = $("#Saldo").val();

    console.log("dentro de agregar");

    if (!NombreTarjetaV || !NumeroCuentaV || !SaldoV) {
      alert("Favor ingresar todos los datos");
      verificar = false;
    } else if (isNaN(NumeroCuentaV)) {
      alert("Formato incorrecto de número de cuenta");
      verificar = false;
    } else if (isNaN(SaldoV)) {
      alert("Formato incorrecto de saldo");
      verificar = false;
    }
    console.log(cedula);
    console.log(NombreTarjetaV);
    console.log(NumeroCuentaV);
    console.log(SaldoV);

    if (verificar) {
      const item = {
        Id_Persona: cedula,
        Nom_CreditCard: NombreTarjetaV,
        NumCuenta_CreditCard: NumeroCuentaV,
        Saldo_CreditCard: SaldoV,
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
          if (response == "Se guardo la tarjeta") {
            alert(response);
            location.href = "FormularioGestion.html";
          } else {
            alert("Error al ingresar los datos");
          }
        })
        .catch((error) => {
          console.log("dentro de catch");
          console.error("Unable to add item.", error);
          alert("No se guardó");
        });
      $("#formulario").trigger("reset");
    }
  }

  var init = () => {
    var btnPost = document.getElementById("GuardarDatos");
    btnPost.onclick = inserta;
  };

  init();
})();
