(function () {
  //Para obtener usuario activo
  "use strict";
  let indiceGestion = sessionStorage.getItem("idLC");
  let arrayGestiones = sessionStorage.getItem("datosGestion");
  console.log("Indice " + indiceGestion);
  arrayGestiones = JSON.parse(arrayGestiones);
  console.log(arrayGestiones);
  let gestionUsuario = arrayGestiones[indiceGestion].id;
  let infoUsuario = arrayGestiones[indiceGestion].Id_Persona;
  console.log("La cedula del usuario es " + infoUsuario);
  let datosGastosUsuario = [];
  let cedulaUsuario;

  let infoBanco = sessionStorage.getItem("DatosCliArray");
  infoBanco = JSON.parse(infoBanco);
  let nombreBanco = infoBanco[0].Nom1_Persona;

  let idGestionV;

  function cargarDatos() {
    let url = "https://localhost:44308/api/GestionesPendientes/" + infoUsuario;
    fetch(url)
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        console.log(json_data);
        datosGastosUsuario = json_data;
        cedulaUsuario = datosGastosUsuario[0].Id_Persona;
        console.log("Imprimiendo cedula" + cedulaUsuario);
        mostrarDatos(datosGastosUsuario);
      })
      .catch((err) => console.log("error", err));
  }

  function mostrarDatos(array) {
    console.log("dentro de mostrar datos");
    console.log(array);
    var ced = document.getElementById("CedVer");
    var nombre = document.getElementById("Nom");
    var apellido1 = document.getElementById("apellido1");
    var apellido2 = document.getElementById("apellido2");
    var estadoCi = document.getElementById("Estado");

    var nombreTrabajo = document.getElementById("NombreTrabajo");
    var puesto = document.getElementById("puesto");
    var saldo = document.getElementById("salario");
    var ingreso = document.getElementById("fechaIng");

    var otroSueldo = document.getElementById("OtroSueldo");
    var bonos = document.getElementById("BonosComisiones");
    var renta = document.getElementById("Renta");
    var inversiones = document.getElementById("Inversiones");
    var otroIngreso = document.getElementById("OtrosIngresos");

    var prestamos = document.getElementById("Prestamos");
    var facturaMen = document.getElementById("FacturacionMensual");
    var Hipoteca = document.getElementById("Hipotecas");
    var OtrosGastos = document.getElementById("OtrosGastos");

    var institucionB = document.getElementById("InstitucionBancaria");
    var cuentaC = document.getElementById("CuentaCorriente");
    var cajaAho = document.getElementById("CajaAhorros");
    var prestamoRF = document.getElementById("Prestamo");
    var saldoPres = document.getElementById("SaldoPrestamo");

    /*Personal */

    ced.innerHTML = array[0].Id_Persona;
    nombre.innerHTML = array[0].Nom1_Persona;
    estadoCi.innerHTML = array[0].EstadoCivil_Persona;
    apellido1.innerHTML = array[0].Apell1_Persona;
    apellido2.innerHTML = array[0].Apell2_Persona;

    /**Trabajo */

    nombreTrabajo.innerHTML = array[0].Nom_Trabajo;
    saldo.innerHTML = array[0].SueldoMen_Trabajo;
    puesto.innerHTML = array[0].Puesto_Trabajo;
    ingreso.innerHTML = array[0].FechaIngrso_Trabajo;

    /*Sueldo */
    otroSueldo.innerHTML = array[0].Sueldo_OtrosIngree;
    bonos.innerHTML = array[0].BonosComision_OtrosIngree;
    renta.innerHTML = array[0].Rentas_OtrosIngree;
    inversiones.innerHTML = array[0].Inversión_OtrosIngree;
    otroIngreso.innerHTML = array[0].Otros_OtrosIngree;

    /*Otros gastos */
    prestamos.innerHTML = array[0].Prestamo_Gasto;
    facturaMen.innerHTML = array[0].FactuMensu_Gasto;
    Hipoteca.innerHTML = array[0].Hipotecas_Gasto;
    OtrosGastos.innerHTML = array[0].Otros_Gasto;

    /*Referencia Bancaria */
    institucionB.innerHTML = array[0].NomInst_ReferBan;
    cuentaC.innerHTML = array[0].CuentaCorriente_ReferBan;
    cajaAho.innerHTML = array[0].CajaAhorros_ReferBan;
    prestamoRF.innerHTML = array[0].Prestamo_ReferBan;
    saldoPres.innerHTML = array[0].SaldoPrestamo_ReferBan;
  }

  function Aceptar() {
    event.preventDefault();
    let url = " https://localhost:44308/api/Banco";
    var cedula = sessionStorage.getItem("cedula");
    var Banco;
    console.log("dentro de agregar");

    var verificar = true;
    console.log("Valores para aceptar");
    console.log(gestionUsuario);

    if (verificar) {
      const item = {
        idGestion: gestionUsuario,
        nombreEnditdad: nombreBanco,
        respuesta: "Aceptada",
      };

      fetch(url, {
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
          alert(response);
          location.href = "BancoPrincipal.html";
        })
        .catch((error) => {
          console.log("dentro de catch");
          console.error("Unable to add item.", error);
          alert("No se guardó");
        });
      // $("#formulario").trigger("reset");
    }
  }

  function Rechazar() {
    event.preventDefault();
    let url = " https://localhost:44308/api/Banco";
    var cedula = sessionStorage.getItem("cedula");
    var Banco;
    console.log("dentro de agregar");

    var verificar = true;
    console.log("Valores para aceptar");
    console.log(gestionUsuario);

    if (verificar) {
      const item = {
        idGestion: gestionUsuario,
        nombreEnditdad: nombreBanco,
        respuesta: "Rechazada",
      };

      fetch(url, {
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
          alert(response);
          location.href = "BancoPrincipal.html";
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
    console.log("Estoy en el init");
    cargarDatos();

    var btnAceptar = document.getElementById("Aceptar");
    btnAceptar.onclick = Aceptar;
    var btnRechazar = document.getElementById("rechazar");
    btnRechazar.onclick = Rechazar;
  };

  init();
})();
