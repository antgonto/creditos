//localStorage.removeItem('cedula');
//localStorage.removeItem('PrimerNombre');
//localStorage.removeItem('SegundoNombre');
//localStorage.removeItem('PrimerApellido');
//localStorage.removeItem('SegundoApellido');
//localStorage.removeItem('email');
//localStorage.removeItem('password');

(function () {
  let DatosCliArray = []; //En este arreglo se almacena el get
  //Para obtener usuario activo

  var MostrarUsuario = () => {
    event.preventDefault();

    let Datos = sessionStorage.getItem('DatosCliArray');
    console.log(Datos);
    fetch("https://localhost:44308/api/Persona/"+Datos+"?accion=verCliente")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        DatosCliArray = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem("DatosCliArray",JSON.stringify(DatosCliArray));

      })
      .catch((err) => console.log("error", err));
	
	  };
	    MostrarUsuario();
   })()



   (function () {
  let ConyugeArray = []; //En este arreglo se almacena el get
  //Para obtener usuario activo

 

    (function () {
  let ConyugeArray = []; //En este arreglo se almacena el get
  //Para obtener usuario activo

  var MostrarTrabajo = () => {
    event.preventDefault();

    let Trabajo = sessionStorage.getItem('TrabajoArray');
    console.log(Trabajo);
    fetch("https://localhost:44308/api/Persona/"+Trabajo+"?accion=verCliente")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        TrabajoArray = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem("TrabajoArray",JSON.stringify(TrabajoArray));

      })
      .catch((err) => console.log("error", err));
	
	  };
	    MostrarTrabajo();
   })()


       (function () {
  let ConyugeArray = []; //En este arreglo se almacena el get
  //Para obtener usuario activo

  var MostrarTrabajo = () => {
    event.preventDefault();

    let Trabajo = sessionStorage.getItem('TrabajoArray');
    console.log(Trabajo);
    fetch("https://localhost:44308/api/Persona/"+Trabajo+"?accion=verCliente")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        TrabajoArray = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        sessionStorage.setItem("TrabajoArray",JSON.stringify(TrabajoArray));

      })
      .catch((err) => console.log("error", err));
	
	  };
	    MostrarTrabajo();
   })()