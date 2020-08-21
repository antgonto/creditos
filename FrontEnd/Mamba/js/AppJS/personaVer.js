(function () {
  var arreglo = []; //En este arreglo se almacena el get
  //Para obtener usuario activo

  var obtenerRoles = () => {
    fetch("https://localhost:44308/api/Persona/112345678?accion=verCliente")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        arreglo = json_data;
        console.log(arreglo);
        // load();
      })
      .catch((err) => console.log("error", err));
  };

  var init = () => {
    obtenerRoles();
  };

  init();
})();
