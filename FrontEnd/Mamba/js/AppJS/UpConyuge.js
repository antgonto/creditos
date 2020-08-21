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
    const uri = "https://localhost:44308/api/Persona/1";
    let cedulaConyugeV = $("#cedulaCongu").val();
    let primerNombreV = $("#PrimerNombre").val();
    let segundoNombreV = $("#SegundoNombre").val();
    let primerApellidoV = $("#PrimerApellido").val();
    let segundoApellidoV = $("#SegundoApellido").val();
    let celularV = $("#Celular").val();
    let telefonofijoV = $("#Telefonofijo").val();
    console.log("dentro de agregar");

    var verificar = true;
    if (
      !cedulaConyugeV ||
      !primerNombreV ||
      !primerApellidoV ||
      !segundoApellidoV ||
      !celularV
    ) {
      alert("Recuerde llenar todos los datos");
      verificar = false;
    } else if (isNaN(celularV)) {
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
    console.log(cedulaUsuario);
    console.log(cedulaConyugeV);
    console.log(primerNombreV);
    console.log(segundoNombreV);
    console.log(primerApellidoV);
    console.log(segundoApellidoV);
    console.log(celularV);
    console.log(telefonofijoV);

    if (verificar) {
      const item = {
        idPersona: null,
        idPersonaActualizado: cedulaConyugeV,
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
        id_conyuge: cedulaUsuario,
        accion: "",
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

  function cargarInfoConyuge() {
    let url =
      "https://localhost:44308/api/Persona/" +
      cedulaUsuario +
      "?accion=verConyuge";
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

  function mostrarGastos(arrayConyuge) {
    console.log(arrayConyuge);
    $("#cedulaCongu").val(arrayConyuge[0].Id_Persona);
    $("#PrimerNombre").val(arrayConyuge[0].Nom1_Persona);
    $("#SegundoNombre").val(arrayConyuge[0].Nom2_Persona);
    $("#PrimerApellido").val(arrayConyuge[0].Apell1_Persona);
    $("#SegundoApellido").val(arrayConyuge[0].Apell2_Persona);
    $("#Celular").val(arrayConyuge[0].Tel1_Persona);
    $("#Telefonofijo").val(arrayConyuge[0].Tel2_Persona);
  }

  var init = () => {
    console.log("Estoy en el init");
    cargarInfoConyuge();
    var btnPut = document.getElementById("GuardarDatos");
    btnPut.onclick = actualizar;
  };

  init();
})();
