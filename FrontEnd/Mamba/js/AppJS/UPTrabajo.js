(function () {
  //Para obtener usuario activo
  "use strict";
  let infoUsuario = sessionStorage.getItem("DatosCliArray");
  infoUsuario = JSON.parse(infoUsuario);
  let cedulaUsuario = infoUsuario[0].Id_Persona;
  console.log("La cedula del usuario es " + cedulaUsuario);
  let datosGastosUsuario = [];
  let codigoTrabjo;

  function actualizar() {
    event.preventDefault();
    const uri = "https://localhost:44308/api/Trabajo/1";
    var NombreTrabajoV = $("#NombreTrabajo").val();
    var NomCompañiaV = $("#NomCompañia").val();
    var TelefonoV = $("#Telefono").val();
    var EmailCompañiaV = $("#EmailCompañia").val();
    var ProvinciaV = $("select[name=Provincia]").val();
    var CantonV = $("select[name=Canton]").val();
    var DistritoV = $("select[name=Distrito]").val();
    var DireccionV = $("#Direccion").val();
    var CodPostalV = $("#CodPostal").val();

    console.log("dentro de agregar");
    var verificar = true;
    if (
      !NombreTrabajoV ||
      !NomCompañiaV ||
      !TelefonoV ||
      !EmailCompañiaV ||
      !ProvinciaV ||
      !CantonV ||
      !DistritoV ||
      !DireccionV ||
      !CodPostalV
    ) {
      alert("Favor llenar todos los campos");
      verificar = false;
    }

    console.log(NombreTrabajoV);
    console.log(NomCompañiaV);
    console.log(TelefonoV);
    console.log(EmailCompañiaV);
    console.log(ProvinciaV);
    console.log(CantonV);
    console.log(DistritoV);
    console.log(DireccionV);
    console.log(CodPostalV);
    if (verificar) {
      const item = {
        Cod_Trabajo: codigoTrabjo,
        Nom_Trabajo: NombreTrabajoV,
        Lugar_Trabajo: NomCompañiaV,
        Provincia_Trabajo: ProvinciaV,
        Canton_Trabajo: CantonV,
        Distrito_Trabajo: DistritoV,
        Dirección_Trabajo: DireccionV,
        Tel_Trabajo: TelefonoV,
        Email_Trabajo: EmailCompañiaV,
        CodPostal_Trabajo: CodPostalV,
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

  function cargarDatos() {
    let url = "https://localhost:44308/api/Trabajo/" + cedulaUsuario;
    fetch(url)
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        console.log(json_data);
        datosGastosUsuario = json_data;
        mostrarDatos(datosGastosUsuario);
      })
      .catch((err) => console.log("error", err));
  }

  function mostrarDatos(array) {
    console.log(array);
    $("#NombreTrabajo").val(array[0].Nom_Trabajo);
    $("#NomCompañia").val(array[0].Lugar_Trabajo);
    $("#Telefono").val(array[0].Tel_Trabajo);
    $("#EmailCompañia").val(array[0].Email_Trabajo);
    $("#Provincia").val(array[0].Provincia_Trabajo);
    $("#Canton").val(array[0].Canton_Trabajo);
    $("#distrito").val(array[0].Distrito_Trabajo);
    $("#Direccion").val(array[0].Dirección_Trabajo);
    $("#CodPostal").val(array[0].CodPostal_Trabajo);
    codigoTrabjo = array[0].Cod_Trabajo;
  }

  var init = () => {
    console.log("Estoy en el init");
    cargarDatos();
    var btnPut = document.getElementById("GuardarDatos");
    btnPut.onclick = actualizar;
  };

  init();
})();
