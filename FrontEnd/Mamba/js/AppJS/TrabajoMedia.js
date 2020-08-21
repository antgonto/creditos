(function () {
  //Para obtener usuario activo

  const uri = "https://localhost:44308/api/Trabajo_Persona";
  function inserta() {
    event.preventDefault();
    var verificar = true;
    var cedulaV = sessionStorage.getItem("cedula");
    var SueldoV = $("#Sueldo").val();
    var FechaIngresoV = $("#FechaIngreso").val();
    var PuestoTrabajoV = $("#PuestoTrabajo").val();

    console.log("dentro de agregar");

    if (!SueldoV || !FechaIngresoV || !PuestoTrabajoV) {
      alert("Favor ingresar todos los datos.");
      verificar = false;
    } else if (isNaN(SueldoV)) {
      alert("Formato incorrecto de sueldo.");
      verificar = false;
    }

    console.log(cedulaV);
    console.log(SueldoV);
    console.log(FechaIngresoV);
    console.log(PuestoTrabajoV);

    if (verificar) {
      const item = {
        Id_Persona: cedulaV,
        SueldoMen_Trabajo: SueldoV,
        FechaIngrso_Trabajo: FechaIngresoV, //en la base dice  FechaIngrso
        Puesto_Trabajo: PuestoTrabajoV,
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
          if (response == "Se guardó el trabajo para esa persona") {
            alert("Trabajo ingresado correctamente");
            location.href = "OtrosIngresos2.html";
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
