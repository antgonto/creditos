(function () {
  //Para obtener usuario activo

  function inserta() {
    event.preventDefault();
    var cedula = sessionStorage.getItem("cedula");
    const uri = "https://localhost:44308/api/GestionFormulario/" + cedula;
    var montoCrediV = document.getElementById("montoCredi").value;
    var PLazoV = document.getElementById("PLazo").value;
    var DescripCrediV = document.getElementById("DescripCredi").value;
    var PlanillaV = document.getElementById("planilla");
    let planillaRespuesta;
    console.log("dentro de agregar");
    if (PlanillaV.checked) {
      planillaRespuesta = "si";
    } else {
      planillaRespuesta = "no";
    }
    var verificar = true;
    if (!montoCrediV || !DescripCrediV) {
      alert("No puede dejar espacios en blanco");
      verificar = false;
    }
    console.log(cedula);
    console.log(montoCrediV);
    console.log(PLazoV);
    console.log(DescripCrediV);
    console.log(planillaRespuesta);

    if (verificar) {
      const item = {
        Valor_Credito: montoCrediV,
        Plazo_Credito: PLazoV,
        Descripcion: DescripCrediV,
        Planilla: planillaRespuesta,
        Estado: "pendiente",
        Id_Persona: cedula,
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
          console.log(response);
          alert(response);
          if (response == "Se guardo el formulario") {
            console.log("sin ingrespo");
            location.href = "Principal.html";
          }
        })
        .catch((error) => {
          console.log("dentro de catch");
          console.error("Unable to add item.", error);
          alert("No se guardó");
          // location.href = "IngresoDatosCLI.html";
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
