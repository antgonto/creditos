////////////////////////////DATOS PERSONALES//////////////////////////////////

(function () {
  let usuario = []; //En este arreglo se almacena el get
  //Para obtener usuario activo

  var MostrarUsuario = () => {
    let cedula = sessionStorage.getItem("cedula");
    console.log(cedula);
    fetch(
      "https://localhost:44308/api/Persona/" + cedula + "?accion=verCliente"
    )
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        usuario = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        mostrar(usuario);
        sessionStorage.setItem("DatosCliArray", JSON.stringify(usuario));

        // var op = document.getElementById("cedula")
      })

      // .then(() => {
      //               mostrar();
      //         })

      .catch((err) => console.log("error", err));
  };

  MostrarUsuario();

  //*******************Trabajo*********************//

  var MostrarTrabajo = () => {
    let cedula = sessionStorage.getItem("cedula");
    console.log(cedula);
    fetch("https://localhost:44308/api/Trabajo/" + cedula + "")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        TrabajoArray = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem("TrabajoArray", JSON.stringify(TrabajoArray));
      })
      .catch((err) => console.log("error", err));
  };
  MostrarTrabajo();

  //*******************Trabajo persona*********************//*
  let TrabajoPersona = [];
  var MostrarTraPer = () => {
    console.log("llamando a trabajo persona");
    let cedula = sessionStorage.getItem("cedula");
    fetch("https://localhost:44308/api/Trabajo_Persona/" + cedula + "")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        TrabajoPersona = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem(
          "TrabajoPersona",
          JSON.stringify(TrabajoPersona)
        );
      })
      .catch((err) => console.log("error", err));
  };
  MostrarTraPer();

  //*******************Conyugue*********************//*

  let ConyugeArray = [];
  var MostrarConyu = () => {
    let cedula = sessionStorage.getItem("cedula");
    console.log(cedula);
    fetch(
      "https://localhost:44308/api/Persona/" + cedula + "?accion=verConyuge"
    )
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        ConyugeArray = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem("ConyugeArray", JSON.stringify(ConyugeArray));
      })
      .catch((err) => console.log("error", err));
  };
  MostrarConyu();

  //*******************Gastos***************************//
  let GastosArray = [];
  var MostrarGastos = () => {
    let cedula = sessionStorage.getItem("cedula");
    console.log(cedula);
    fetch("https://localhost:44308/api/Gastos/" + cedula + "")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        GastosArray = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem("GastosArray", JSON.stringify(GastosArray));
      })
      .catch((err) => console.log("error", err));
  };
  MostrarGastos();
  //***********************Ref Bancaria***********************//
  let ReferBancariaArray = [];

  var RefBancaria = () => {
    let cedula = sessionStorage.getItem("cedula");
    console.log(cedula);
    fetch("https://localhost:44308/api/ReferenciaBancaria/" + cedula + "")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        ReferBancariaArray = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem(
          "ReferBancariaArray",
          JSON.stringify(ReferBancariaArray)
        );
      })
      .catch((err) => console.log("error", err));
  };
  RefBancaria();

  //*********************Tarjeta de credito***********************//
  let TcreditoArray = [];
  var TCredito = () => {
    let cedula = sessionStorage.getItem("cedula");
    console.log(cedula);
    fetch("https://localhost:44308/api/CreditCard/" + cedula + "")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        TcreditoArray = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem("TcreditoArray", JSON.stringify(TcreditoArray));
      })
      .catch((err) => console.log("error", err));
  };
  TCredito();

  //*********************Otros Ingresos***********************//
  let OIngresosArray = [];
  var MostrarOtrosIngresos = () => {
    let cedula = sessionStorage.getItem("cedula");
    console.log(cedula);
    fetch("https://localhost:44308/api/OtrosIngresos/" + cedula + "")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        OIngresosArray = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem(
          "OIngresosArray",
          JSON.stringify(OIngresosArray)
        );
      })
      .catch((err) => console.log("error", err));
  };
  MostrarOtrosIngresos();

  function mostrar(DatosCli) {
    //********************Nombre**************************//*
    //var DatosCli = sessionStorage.getItem("DatosCliArray");
    //DatosCli = JSON.parse(DatosCli);
    //console.log(DatosCli);
    //console.log(DatosCli[0].Id_Persona);

    var Ce = document.getElementById("CedVer");
    Ce.innerText = DatosCli[0].Id_Persona;

    var Nomb = document.getElementById("Nom");
    Nomb.innerText =
      DatosCli[0].Nom1_Persona +
      " " +
      DatosCli[0].Nom2_Persona +
      " " +
      DatosCli[0].Apell1_Persona +
      " " +
      DatosCli[0].Apell2_Persona;

    //********************Telefono******************************//*
    var Te = document.getElementById("Tel");
    Te.innerText = DatosCli[0].Tel1_Persona;

    //********************Correo********************************//*
    var Co = document.getElementById("Correo");
    Co.innerText = DatosCli[0].Email_Persona;

    //********************Nacionalidad**************************//*
    var Na = document.getElementById("Nacio");
    Na.innerText = DatosCli[0].Nacion_Persona;

    //********************Estado Civil**************************//*
    var Es = document.getElementById("Estado");
    Es.innerText = DatosCli[0].EstadoCivil_Persona;

    //********************Residencia****************************//*
    var Re = document.getElementById("Residencia");
    Re.innerText =
      DatosCli[0].Provincia_Persona +
      ", " +
      DatosCli[0].Cantón_Persona +
      ", " +
      DatosCli[0].Distrito_Persona;
  }

  ////////////////////////////FIN DATOS PERSONALES//////////////////////////////////
})();

/*(function () {
  "use strict";
  let infoUsuario = sessionStorage.getItem("DatosCliArray");
  infoUsuario = JSON.parse(infoUsuario);

function cargarInfoPersonaPrin() {
    console.log(infoUsuario);
    
    $("#CedVer").val(infoUsuario[0].Id_Persona);
    $("#Nom").val(infoUsuario[0].Nom1_Persona+ " " +infoUsuario[0].Nom2_Persona + " " + infoUsuario[0].Apell1_Persona + " " + infoUsuario[0].Apell2_Persona);
    $("#Correo").val(infoUsuario[0].Email_Persona);
    $("#Tel").val(infoUsuario[0].Tel1_Persona);
    $("#Nacio").val(infoUsuario[0].Nacion_Persona);
    $("#Estado").val(infoUsuario[0].EstadoCivil_Persona);
    $("#Residencia").val(infoUsuario[0].Provincia_Persona+ " " +infoUsuario[0].Cantón_Persona + " " + infoUsuario[0].Distrito_Persona);
  }
 
   var init = () => {
    console.log("Iniciando");
    cargarInfoPersonaPrin();
  };
 
  init();

})();*/
