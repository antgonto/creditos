(function () {
  //Para obtener usuario activo
  "use strict";
  let infoUsuario = sessionStorage.getItem("DatosCliArray");
  infoUsuario = JSON.parse(infoUsuario);
  let cedulaUsuario = infoUsuario[0].Id_Persona;
  console.log("La cedula del usuario es " + cedulaUsuario);
  let datosGastosUsuario = [];

  function actualizar() {
    event.preventDefault();
    const uri = "https://localhost:44308/api/CreditCard/2";
    var NombreTarjetaV = $("#NombreTarjeta").val();
    var NumeroCuentaV = $("#NumeroCuenta").val();
    var SaldoV = $("#Saldo").val();

    console.log("dentro de agregar");
    var verificar = true;
    if (!NombreTarjetaV || !NumeroCuentaV || !SaldoV) {
      alert("Espacio de descripción requerido");

      verificar = false;
    }
    console.log(cedulaUsuario);
    console.log(NombreTarjetaV);
    console.log(NumeroCuentaV);
    console.log(SaldoV);

    if (verificar) {
      const item = {
        Id_Persona: cedulaUsuario,
        Nom_CreditCard: NombreTarjetaV,
        NumCuenta_CreditCard: NumeroCuentaV,
        Saldo_CreditCard: SaldoV,
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
          location.href = "FormularioGestion.html";
        })
        .catch((error) => {
          console.log("dentro de catch");
          console.error("Unable to add item.", error);
          alert("No se guardó");
        });
      // $("#formulario").trigger("reset");
    }
  }

  function cargarDatos() {
    let url = "https://localhost:44308/api/CreditCard/" + cedulaUsuario;
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
    $("#NombreTarjeta").val(array[0].Nom_CreditCard);
    $("#NumeroCuenta").val(array[0].NumCuenta_CreditCard);
    $("#Saldo").val(array[0].Saldo_CreditCard);
  }

  var init = () => {
    console.log("Estoy en el init");
    cargarDatos();
    var btnPut = document.getElementById("GuardarDatos");
    btnPut.onclick = actualizar;
  };

  init();
})();
