(function () {
  let usuario = []; //En este arreglo se almacena el get
  //Para obtener usuario activo

  var MostrarUsuario = () => {
    event.preventDefault();
    let cedula = document.getElementById('user').value;
    console.log(cedula);
    sessionStorage.setItem("cedula", cedula);
    fetch("https://localhost:44308/api/Persona/"+cedula+"?accion=verCliente")
      .then((res) => res.json())
      .then((data) => {
        const json_data = JSON.parse(data);
        usuario = json_data;
        console.log("Dentro de mostrar");
        console.log(json_data);
        ingresar();

       // var op = document.getElementById("cedula")
      })
      .catch((err) => console.log("error", err));
  };


var init = () => {
        console.log("Imprimiendo el array desde el inicio");
        
        var btnPut = document.getElementById('button');
        btnPut.onclick = MostrarUsuario;
       
    }

 

    init();
  var ingresar = () => {

    console.log("dentro de ingresar");
    console.log(usuario);

    var permiso = false;
  
    for(cont =0; cont< usuario.length;cont++){

      if (usuario[0].Id_Persona == $('#user').val()){
      console.log("cedula ya");


        if (usuario[0].Clave_Persona == $('#pass').val()){
        console.log("clave ya");
         
          permiso =true

          var cedula = $("#user").val();
          sessionStorage.setItem("DatosCliArray",JSON.stringify(usuario));

          break;
        }
      }
    }

    if(permiso){
      location.href = "Principal.html";

    }else{
      alert("Usuario o contraseña incorrecto");
    }

  };
})()


