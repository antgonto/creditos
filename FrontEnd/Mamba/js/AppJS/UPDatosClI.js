(function () {
  //Para obtener usuario activo
  "use strict";
  let infoUsuario = sessionStorage.getItem("DatosCliArray");
  infoUsuario = JSON.parse(infoUsuario);
  let cedulaUsuario = infoUsuario[0].Id_Persona;
  console.log("La cedula del usuario es " + cedulaUsuario);
  let datosGastosUsuario = [];

  const uri = "https://localhost:44308/api/Persona/1";
  function actualizar() {
    event.preventDefault();
    var verificar = true;
    var expRegEmail = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/; //validar una cuenta de correo

    var CedulaV = $("#cedula").val();
    var primerNombreV = $("#PrimerNombre").val();
    var SegundoNombreV = $("#SegundoNombre").val();
    var PrimerApellidoV = $("#PrimerApellido").val();
    var SegundoApellidoV = $("#SegundoApellido").val();
    var emailV = $("#email").val();

    let CelularV = $("#Celular").val();
    let TelefonofijoV = $("#Telefonofijo").val();
    let NacionalidadV = $("#Nacionalidad").val();
    let EstadoCivilV = $("Select[name=EstadoCivil]").val();
    let ProvinciaV = $("Select[name=Provincia]").val();
    let CantonV = $("Select[name=Canton]").val();
    let DistritoV = $("Select[name=Distrito]").val();
    let DireccionV = $("#Direccion").val();

    if (
      !primerNombreV ||
      !PrimerApellidoV ||
      !SegundoApellidoV ||
      !emailV ||
      !CelularV ||
      !NacionalidadV ||
      !EstadoCivilV ||
      !ProvinciaV ||
      !CantonV ||
      !DistritoV ||
      !DireccionV
    ) {
      alert("No puede dejar espacios en blanco");
      verificar = false;
    } else if (emailV && !expRegEmail.exec(emailV)) {
      alert("Formato incorrecto de correo electrónico.");
      verificar = false;
    } else if (isNaN(CelularV)) {
      alert("Solo se aceptan dígitos en el teléfono");
      verificar = false;
    } else if (CelularV && CelularV.length < 8) {
      alert("Formato incorrecto de celular");
      verificar = false;
    }
    if (TelefonofijoV && isNaN(TelefonofijoV)) {
      alert("Solo se aceptan dígitos en el teléfono");

      verificar = false;
    } else if (TelefonofijoV && TelefonofijoV.length < 8) {
      alert("Formato incorrecto de teléfono fijo");
      verificar = false;
    }
    console.log("Dentro de Actualizar");

    console.log(CedulaV);
    console.log(primerNombreV);
    console.log(SegundoNombreV);
    console.log(PrimerApellidoV);
    console.log(SegundoApellidoV);
    console.log(EstadoCivilV);
    console.log(CelularV);
    console.log(TelefonofijoV);
    console.log(emailV);
    console.log(NacionalidadV);
    console.log(ProvinciaV);
    console.log(CantonV);
    console.log(DistritoV);
    console.log(DireccionV);

    if (verificar) {
      const item = {
        idPersona: CedulaV,
        idPersonaActualizado: CedulaV,
        nombre1: primerNombreV,
        nombre2: SegundoNombreV,
        apellido1: PrimerApellidoV,
        apellido2: SegundoApellidoV,
        estadoCivil: EstadoCivilV,
        telefono1: CelularV,
        telefono2: TelefonofijoV,
        email: emailV,
        nacionalidad: NacionalidadV,
        provincia: ProvinciaV,
        canton: CantonV,
        distrito: DistritoV,
        direccion: DireccionV,
        clave: "",
        codTipoPersona: 1,
        accion: "datos",
        id_conyuge: null,
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
          if ((response = "Se actualizó  la persona con éxito")) {
            alert(response);
            location.href = "Principal.html";
          } else {
            alert("Error al actualizar los datos");
          }
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

  function cargarCliente() {
    let url =
      "https://localhost:44308/api/Persona/" +
      cedulaUsuario +
      "?accion=verCliente";
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

  function mostrarGastos(infoUsuario) {
    console.log(infoUsuario);
    console.log(infoUsuario);
    $("#cedula").val(infoUsuario[0].Id_Persona);
    $("#PrimerNombre").val(infoUsuario[0].Nom1_Persona);
    $("#SegundoNombre").val(infoUsuario[0].Nom2_Persona);
    $("#PrimerApellido").val(infoUsuario[0].Apell1_Persona);
    $("#SegundoApellido").val(infoUsuario[0].Apell2_Persona);
    $("#email").val(infoUsuario[0].Email_Persona);
    $("#Celular").val(infoUsuario[0].Tel1_Persona);
    $("#Telefonofijo").val(infoUsuario[0].Tel2_Persona);
    $("#Nacionalidad").val(infoUsuario[0].Nacion_Persona);
    $("#EstadoCivil").val(infoUsuario[0].EstadoCivil_Persona);
    $("#Provincia").val(infoUsuario[0].Provincia_Persona);
    $("#Canton").val(infoUsuario[0].Cantón_Persona);
    $("#Distrito").val(infoUsuario[0].Distrito_Persona);
    $("#Direccion").val(infoUsuario[0].Dirección_Persona);
  }

  var init = () => {
    console.log("Estoy en el init");
    cargarCliente();
    var btnPut = document.getElementById("GuardarDatos");
    btnPut.onclick = actualizar;
  };

  init();
})();
