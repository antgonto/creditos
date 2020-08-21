(function () {
  "use strict";

  const uri = "https://localhost:44308/api/Persona/1";
  function actualizar() {
    event.preventDefault();
    console.log("Dentro de Actualizar");
    var expRegEmail = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/; //validar una cuenta de correo

    var verificar = true;
    let CelularV = $("#Celular").val();
    let TelefonofijoV = $("#Telefonofijo").val();
    let NacionalidadV = $("#Nacionalidad").val();
    let EstadoCivilV = $("Select[name=EstadoCivil]").val();
    let ProvinciaV = $("Select[name=Provincia]").val();
    let CantonV = $("Select[name=Canton]").val();
    let DistritoV = $("Select[name=Distrito]").val();
    let DireccionV = $("#Direccion").val();
    let CedulaV = sessionStorage.getItem("cedula");
    let primerNombreV = sessionStorage.getItem("PrimerNombre");
    let SegundoNombreV = sessionStorage.getItem("SegundoNombre");
    let PrimerApellidoV = sessionStorage.getItem("PrimerApellido");
    let SegundoApellidoV = sessionStorage.getItem("SegundoApellido");
    let emailV = sessionStorage.getItem("email");
    let passwordV = sessionStorage.getItem("password");

    if (!CelularV || !NacionalidadV || !EstadoCivilV || !DireccionV) {
      alert("Favor llenar todos los datos");
      verificar = false;
    }
    if (isNaN(CelularV)) {
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
    if (emailV && !expRegEmail.exec(emailV)) {
      alert("Formato incorrecto de correo electrónico.");
      verificar = false;
    }

    sessionStorage.setItem("Telefono", CelularV);
    sessionStorage.setItem("Nacion", NacionalidadV);
    sessionStorage.setItem("EstadoC", EstadoCivilV);
    sessionStorage.setItem("Provincia", ProvinciaV);
    sessionStorage.setItem("Canton", CantonV);
    sessionStorage.setItem("Distrito", DistritoV);

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
    console.log(passwordV);

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
          if (response == "Se actualizó  la persona con éxito") {
            alert(response);
            location.href = "Principal.html";
          } else {
            alert(response);
            console.log("No se guardaron los datos, inténtelo de nuevo");
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

  var init = () => {
    console.log("Estoy en el init");
    var btnPut = document.getElementById("GuardarDatos");
    btnPut.onclick = actualizar;
  };

  init();
})();
