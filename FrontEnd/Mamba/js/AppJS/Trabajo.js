(function () {
  //Para obtener usuario activo

  const uri = "https://localhost:44308/api/Trabajo";
  function inserta() {
    event.preventDefault();
    var verificar = true;
    var cedula = sessionStorage.getItem("cedula");
    var expRegEmail = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/; //validar una cuenta de correo

    var NombreTrabajoV = $("#NombreTrabajo").val();
    var lugarTrabajo = $("#lugarTrabajo").val();
    var TelefonoV = $("#Telefono").val();
    var EmailCompañiaV = $("#EmailCompañia").val();
    var ProvinciaV = $("select[name=Provincia]").val();
    var CantonV = $("select[name=Canton]").val();
    var DistritoV = $("select[name=Distrito]").val();
    var DireccionV = $("#Direccion").val();
    var CodPostalV = $("#CodPostal").val();
    console.log("dentro de agregar");

    if (
      !NombreTrabajoV ||
      !lugarTrabajo ||
      !TelefonoV ||
      !EmailCompañiaV ||
      !CodPostalV
    ) {
      alert("Favor ingresar todos los campos");
      verificar = false;
    } else if (TelefonoV && isNaN(TelefonoV)) {
      alert("Solo se aceptan dígitos en el teléfono");
      verificar = false;
    } else if (TelefonoV && TelefonoV.length < 8) {
      alert("Formato incorrecto de teléfono");
      verificar = false;
    } else if (EmailCompañiaV && !expRegEmail.exec(EmailCompañiaV)) {
      alert("Formato incorrecto de correo electrónico.");
      verificar = false;
    } else if (CodPostalV && isNaN(CodPostalV)) {
      alert("Solo se aceptan dígitos en el código postal");
      verificar = false;
    }

    console.log(cedula);
    console.log(NombreTrabajoV);
    console.log(lugarTrabajo);
    console.log(TelefonoV);
    console.log(EmailCompañiaV);
    console.log(ProvinciaV);
    console.log(CantonV);
    console.log(DistritoV);
    console.log(DireccionV);
    console.log(CodPostalV);
    if (verificar) {
      const item = {
        Nom_Trabajo: NombreTrabajoV,
        Lugar_Trabajo: lugarTrabajo,
        Provincia_Trabajo: ProvinciaV,
        Canton_Trabajo: CantonV,
        Distrito_Trabajo: DistritoV,
        Dirección_Trabajo: DireccionV,
        Tel_Trabajo: TelefonoV,
        Email_Trabajo: EmailCompañiaV,
        CodPostal_Trabajo: CodPostalV,
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
          if (response == "Se guardó trabajo") {
            alert("Se guardó trabajo");
            location.href = "TrabajosMedia.html";
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
