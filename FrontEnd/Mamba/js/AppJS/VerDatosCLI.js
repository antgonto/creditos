(function () {
  //********************Nombre**************************//*
  var DatosCli = sessionStorage.getItem("DatosCliArray");
  DatosCli = JSON.parse(DatosCli);
  console.log(DatosCli);
  console.log(DatosCli[0].Id_Persona);

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

  var Di = document.getElementById("Direccion");
  Di.innerText = DatosCli[0].Dirección_Persona;
  ////////////////////////////FIN DATOS PERSONALES//////////////////////////////////

  ////////////////////////////CONYUGE//////////////////////////////////
  var Conyuge = sessionStorage.getItem("ConyugeArray");
  Conyuge = JSON.parse(Conyuge);
  console.log(Conyuge);
  console.log(Conyuge[0].Id_Persona);

  var CedConyu = document.getElementById("CedConyu");
  CedConyu.innerText = Conyuge[0].Id_Persona;

  var NombConyu = document.getElementById("NomConyu");
  NombConyu.innerText =
    Conyuge[0].Nom1_Persona +
    " " +
    Conyuge[0].Nom2_Persona +
    " " +
    Conyuge[0].Apell1_Persona +
    " " +
    Conyuge[0].Apell2_Persona;

  var CelConyu = document.getElementById("CelConyu");
  CelConyu.innerText = Conyuge[0].Tel1_Persona;

  var TelConyu = document.getElementById("TelConyu");
  TelConyu.innerText = Conyuge[0].Tel2_Persona;
  ////////////////////////////FIN CONYUGE//////////////////////////////////

  //////////////////////////INFORMACION TRABAJO////////////////////////////////////
  var Inf_trabajo = sessionStorage.getItem("TrabajoArray");
  Inf_trabajo = JSON.parse(Inf_trabajo);
  console.log(Inf_trabajo);

  var codTrabajo = Inf_trabajo[0].Cod_Trabajo;

  var NomTrabajo = document.getElementById("NombreTrabajo");
  NomTrabajo.innerText = Inf_trabajo[0].Nom_Trabajo;

  var NomCompania = document.getElementById("NombreCompañia");
  NomCompania.innerText = Inf_trabajo[0].Lugar_Trabajo;

  var TelTrabajo = document.getElementById("TelTrabajo");
  TelTrabajo.innerText = Inf_trabajo[0].Tel_Trabajo;

  var TrabajoEmail = document.getElementById("EmailTrabajo");
  TrabajoEmail.innerText = Inf_trabajo[0].Email_Trabajo;

  var TrabajoResi = document.getElementById("ResidenciaTraba");
  TrabajoResi.innerText =
    Inf_trabajo[0].Provincia_Trabajo +
    ", " +
    Inf_trabajo[0].Canton_Trabajo +
    ", " +
    Inf_trabajo[0].Distrito_Trabajo;

  ////////////////////////////FIN INFORMACION TRABAJO//////////////////////////////////

  //////////////////////////INFORMACION DE OTROS INGRESOS////////////////////////////////////
  var Oingresos = sessionStorage.getItem("OIngresosArray");
  Oingresos = JSON.parse(Oingresos);
  console.log(Oingresos);

  var OtroSueldo = document.getElementById("OtroSueldo");
  OtroSueldo.innerText = Oingresos[0].Sueldo_OtrosIngree;

  var BonosComisiones = document.getElementById("BonosComisiones");
  BonosComisiones.innerText = Oingresos[0].BonosComision_OtrosIngree;

  var Renta = document.getElementById("Renta");
  Renta.innerText = Oingresos[0].Rentas_OtrosIngree;

  var Inversiones = document.getElementById("Inversiones");
  Inversiones.innerText = Oingresos[0].Inversión_OtrosIngree;

  var OtrosIngresos = document.getElementById("OtrosIngresos");
  OtrosIngresos.innerText = Oingresos[0].Otros_OtrosIngree;
  //////////////////////////FIN INFORMACION DE OTROS INGRESOS/////////////////////////////////

  //////////////////////////INFORMACION GASTOS////////////////////////////////////
  var Gastos = sessionStorage.getItem("GastosArray");
  Gastos = JSON.parse(Gastos);
  console.log(Gastos);

  var PrestamoG = document.getElementById("Prestamos");
  PrestamoG.innerText = Gastos[0].Prestamo_Gasto;

  var FacturacionMensualG = document.getElementById("FacturacionMensual");
  FacturacionMensualG.innerText = Gastos[0].FactuMensu_Gasto;

  var HipotecasG = document.getElementById("Hipotecas");
  HipotecasG.innerText = Gastos[0].Hipotecas_Gasto;

  var OtrosGastosG = document.getElementById("OtrosGastos");
  OtrosGastosG.innerText = Gastos[0].Otros_Gasto;

  //////////////////////////INFORMACION GASTOS/////////////////////////////////

  //////////////////////////INFORMACION REFERENCIA BANCARIA////////////////////////////////////
  var ReferBancaria = sessionStorage.getItem("ReferBancariaArray");
  ReferBancaria = JSON.parse(ReferBancaria);
  console.log(ReferBancaria);

  var RInstitucionBancaria = document.getElementById("InstitucionBancaria");
  RInstitucionBancaria.innerText = ReferBancaria[0].Nominst_ReferBan;

  var RCuentaCorriente = document.getElementById("CuentaCorriente");
  RCuentaCorriente.innerText = ReferBancaria[0].CuentaCorriente_ReferBan;

  var RCajaAhorros = document.getElementById("CajaAhorros");
  RCajaAhorros.innerText = ReferBancaria[0].CajaAhorros_ReferBan;

  var RPrestamo = document.getElementById("Prestamo");
  RPrestamo.innerText = ReferBancaria[0].Prestamo_ReferBan;

  var RSaldoPrestamo = document.getElementById("SaldoPrestamo");
  RSaldoPrestamo.innerText = ReferBancaria[0].SaldoPrestamo_ReferBan;

  var RDirecRefer = document.getElementById("DirecRefer");
  RDirecRefer.innerText = ReferBancaria[0].Direc_ReferBan;

  var RTelRefer = document.getElementById("TelRefer");
  RTelRefer.innerText = ReferBancaria[0].Tel_ReferBan;

  //////////////////////////FIN INFORMACION REFERENCIA BANCARIA////////////////////////////////////

  //////////////////////////INFORMACION TARJETAS DE CREDITO////////////////////////////////////
  var Credito = sessionStorage.getItem("TcreditoArray");
  Credito = JSON.parse(Credito);
  console.log(Credito);

  var CNomTarjeta = document.getElementById("NomTarjeta");
  CNomTarjeta.innerText = Credito[0].Nom_CreditCard;

  var CNumCuentaTC = document.getElementById("NumCuentaTC");
  CNumCuentaTC.innerText = Credito[0].NumCuenta_CreditCard;

  var CSaldoTC = document.getElementById("SaldoTC");
  CSaldoTC.innerText = Credito[0].Saldo_CreditCard;

  //////////////////////////FIN INFORMACION TARJETAS DE CREDITO////////////////////////////////////
  /*

//////////////////////////Trabajos////////////////////////////////////

//////////////////////////FIN INFORMACION TARJETAS DE CREDITO////////////////////////////////////
*/

  var TMedia = sessionStorage.getItem("TrabajoPersona");
  TMedia = JSON.parse(TMedia);
  console.log(TMedia);
  console.log(TMedia[0].ced);

  var MSueldoPT = document.getElementById("SueldoPT");
  MSueldoPT.innerText = TMedia[0].SueldoMen_Trabajo;

  var MFechaIngresoPT = document.getElementById("FechaIngresoPT");
  MFechaIngresoPT.innerText = TMedia[0].FechaIngrso_Trabajo;

  var MPuestoTrabajoPT = document.getElementById("PuestoTrabajoPT");
  MPuestoTrabajoPT.innerText = TMedia[0].Puesto_Trabajo;
})();
