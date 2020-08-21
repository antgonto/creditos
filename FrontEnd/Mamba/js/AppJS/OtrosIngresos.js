(function () {
  //Para obtener usuario activo

  const uri = "https://localhost:44308/api/OtrosIngresos";
  function inserta() {
    event.preventDefault();
    var verificar = true;
    var cedula = sessionStorage.getItem("cedula", cedula);
    var OtrosueldoV = $("#OtroSueldo").val();
    var BonosComisionesV = $("#BonosComisiones").val();
    var RentasV = $("#Rentas").val();
    var InversionesV = $("#Inversiones").val();
    var OtrosIngresos = $("#OtrosIngresos").val();

    console.log("dentro de agregar");
    if (
      !OtrosueldoV ||
      !BonosComisionesV ||
      !RentasV ||
      !InversionesV ||
      !OtrosIngresos
    ) {
      alert(
        "Favor llenar todos los campos, poner 0 en caso de no tener datos en un rubro"
      );
      verificar = false;
    }

    console.log(cedula);
    console.log(OtrosueldoV);
    console.log(BonosComisionesV);
    console.log(RentasV);
    console.log(InversionesV);
    console.log(OtrosIngresos);

    if (verificar) {
      const item = {
        idPersona: cedula,
        Sueldo_OtrosIngree: OtrosueldoV,
        BonosComision_OtrosIngree: BonosComisionesV,
        Rentas_OtrosIngree: RentasV,
        Inversion_OtrosIngree: InversionesV,
        OtrosOtrosIngree: OtrosIngresos,
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
          if ((response = "Se guardaron los ingresos")) {
            alert(response);
            location.href = "Gastos.html";
          } else {
            console.log("Error al ingresar los datos");
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
    console.log("dentro de otros ingresos");
    var btnPost = document.getElementById("GuardarDatos");
    btnPost.onclick = inserta;
  };

  init();
})();
