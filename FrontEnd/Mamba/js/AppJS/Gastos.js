(function () {
  //Para obtener usuario activo

  const uri = "https://localhost:44308/api/Gastos";
  function inserta() {
    event.preventDefault();
    var verificar = true;
    var cedula = sessionStorage.getItem("cedula");
    var PrestasmosV = $("#Prestasmos").val();
    var FacturacionMensualV = $("#FacturacionMensual").val();
    var HipotecasV = $("#Hipotecas").val();
    var OtrosGastosV = $("#OtrosGastos").val();
    console.log("dentro de agregar");

    if (!FacturacionMensualV || !PrestasmosV || !HipotecasV || !OtrosGastosV) {
      alert(
        "Favor ingresar todos los campos, ingresar 0 si no tiene gasto en un rubro"
      );
      verificar = false;
    } else if (
      isNaN(FacturacionMensualV) ||
      isNaN(PrestasmosV) ||
      isNaN(HipotecasV) ||
      isNaN(OtrosGastosV)
    ) {
      alert("Formato incorrecto de los datos");
      verificar = false;
    }
    console.log(cedula);
    console.log(PrestasmosV);
    console.log(FacturacionMensualV);
    console.log(HipotecasV);
    console.log(OtrosGastosV);

    if (verificar) {
      const item = {
        idPersona: cedula,
        prestasmo_Gasto: PrestasmosV,
        factuMensu_Gasto: FacturacionMensualV,
        Hipotecas_Gasto: HipotecasV,
        Otros_Gasto: OtrosGastosV,
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
          if ((response = "Se guardaron los gastos")) {
            alert(response);
            location.href = "ReferBancaria.html";
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
