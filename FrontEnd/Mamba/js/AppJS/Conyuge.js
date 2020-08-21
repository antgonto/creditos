(function () {
  //Para obtener usuario activo

  const uri = "https://localhost:44308/api/Persona";
  function inserta() {
    event.preventDefault();
    var verificar = true;
    var cedula = sessionStorage.getItem("cedula", cedula);
    var cedulaConyugeV = $("#cedulaCongu").val();
    var primerNombreV = $("#PrimerNombre").val();
    var segundoNombreV = $("#SegundoNombre").val();
    var primerApellidoV = $("#PrimerApellido").val();
    var segundoApellidoV = $("#SegundoApellido").val();
    var celularV = $("#Celular").val();
    var telefonofijoV = $("#Telefonofijo").val();
    console.log("dentro de agregar");

    if (
      !cedulaConyugeV ||
      !primerNombreV ||
      !primerApellidoV ||
      !segundoApellidoV ||
      !celularV
    ) {
      alert("Recuerde llenar todos los datos");
      verificar = false;
    }
    if (isNaN(celularV)) {
      alert("Solo se aceptan dígitos en el teléfono");
      verificar = false;
    } else if (celularV && celularV.length < 8) {
      alert("Formato incorrecto de celular");
      verificar = false;
    }
    if (telefonofijoV && isNaN(telefonofijoV)) {
      alert("Solo se aceptan dígitos en el teléfono");
      verificar = false;
    } else if (telefonofijoV && telefonofijoV.length < 8) {
      alert("Formato incorrecto de teléfono fijo");
      verificar = false;
    }

    console.log(cedula);
    console.log(cedulaConyugeV);
    console.log(primerNombreV);
    console.log(segundoNombreV);
    console.log(primerApellidoV);
    console.log(segundoApellidoV);
    console.log(celularV);
    console.log(telefonofijoV);

    if (verificar) {
      const item = {
        idPersona: cedulaConyugeV,
        nombre1: primerNombreV,
        nombre2: segundoNombreV,
        apellido1: primerApellidoV,
        apellido2: segundoApellidoV,
        estadoCivil: "casado",
        telefono1: celularV,
        telefono2: telefonofijoV,
        email: "",
        nacionalidad: "",
        provincia: "",
        canton: "",
        distrito: "",
        direccion: "",
        clave: "",
        codTipoPersona: 3,
        id_conyuge: cedula,
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
          if (response == "Se guardó con éxito la persona") {
            alert("Datos de cónyuge ingresados correctamente");
            location.href = "TrabajosCLI.html";
          } else {
            alert("Error al ingresar datos de cónyuge. ");
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

  function sinConyuge() {
    location.href = "TrabajosCLI.html";
  }
  var init = () => {
    var btnPost = document.getElementById("GuardarDatos");
    btnPost.onclick = inserta;
    var btnPost = document.getElementById("sinConyuge");
    btnPost.onclick = sinConyuge;
  };

  init();
})();
