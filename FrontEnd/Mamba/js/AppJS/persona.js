(function () {
  //Para obtener usuario activo

  const uri = "https://localhost:44308/api/Persona";
  function inserta() {
    event.preventDefault();
    var verificar = true;
    var cedula = $("#cedula").val();
    var primerNombreV = $("#PrimerNombre").val();
    var segundoNombreV = $("#SegundoNombre").val();
    var primerApellidoV = $("#PrimerApellido").val();
    var segundoApellidoV = $("#SegundoApellido").val();
    var emailV = $("#email").val();
    var contrasenaV = $("#password").val();
    var contrasenaConfirma = $("#confirm_password").val();
    var expRegEmail = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/; //validar una cuenta de correo

    if (
      !cedula ||
      !primerNombreV ||
      !primerApellidoV ||
      !segundoApellidoV ||
      !emailV ||
      !contrasenaV ||
      !contrasenaConfirma
    ) {
      alert("Recuerde llenar todos los campos");
      verificar = false;
    } else if (emailV && !expRegEmail.exec(emailV)) {
      alert("Formato incorrecto de correo electrónico.");
      verificar = false;
    } else if (contrasenaV != contrasenaConfirma) {
      alert("Las contraseñas no son iguales");
      verificar = false;
    }

    sessionStorage.setItem("cedula", cedula);
    sessionStorage.setItem("PrimerNombre", primerNombreV);
    sessionStorage.setItem("SegundoNombre", segundoNombreV);
    sessionStorage.setItem("PrimerApellido", primerApellidoV);
    sessionStorage.setItem("SegundoApellido", segundoApellidoV);
    sessionStorage.setItem("email", emailV);

    console.log("dentro de agregar");

    console.log(cedula);
    console.log(primerNombreV);
    console.log(segundoNombreV);
    console.log(primerApellidoV);
    console.log(segundoApellidoV);
    console.log(emailV);
    console.log(contrasenaV);
    console.log(contrasenaConfirma);

    if (verificar) {
      const item = {
        idPersona: cedula,
        nombre1: primerNombreV,
        nombre2: segundoNombreV,
        apellido1: primerApellidoV,
        apellido2: segundoApellidoV,
        estadoCivil: "",
        telefono1: null,
        telefono2: null,
        email: emailV,
        nacionalidad: "",
        provincia: "",
        canton: "",
        distrito: "",
        direccion: "",
        clave: contrasenaV,
        codTipoPersona: 1,
        id_conyuge: null,
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
            alert(response);
            console.log("dentro de se guardó");
            location.href = "IngresoDatosCLI.html";
          } else {
            alert(response);
            console.log("No se guardaron los datos, inténtelo de nuevo");
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
    var btnPost = document.getElementById("registrar");
    btnPost.onclick = inserta;
  };

  init();
})();
