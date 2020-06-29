var testing = () => {

    var cargaUsuarios = (success) => {
        fetch('https://localhost:44308/Api/Usuarios')
            .then(res => res.json())
            .then(data => {
                success(data);                
            })
            .catch(err => console.log('error', err))
    }

    return {
        loadUser: cargaUsuarios
    }
}






var login = () => {

    usuarios = [];
    var cargaUsuarios = () => {
        fetch('https://localhost:44308/Api/Usuarios')
            .then(res => res.json())
            .then(data => {
                const json_data = JSON.parse(data);
                usuarios = json_data;
                localStorage.setItem('users', JSON.stringify(usuarios));//envio arrelgo de datos
                ingresar(json_data);

            })
            .catch(err => console.log('error', err))
    }



    var ingresar = (usuarios) => {
        var token = false;
        for (cont = 0; cont < usuarios.length; cont++) {
            if (usuarios[cont].nom_usu == $('#usuario').val()) {
                if (usuarios[cont].contrasena == $('#password').val()) {
                    token = true
                    localStorage.setItem('userID', cont);//Indice por editar
                }
            }
        }
        if (token) {
            abrir('index.html');
            window.close();
        } else {
            $('#mensaje').text('Usuario o contraseña incorrecto');
        }

    }

    function abrir(url) {
        var a = document.createElement("a");
        a.target = "_blank";
        a.href = url;
        a.click();
    }

    var init = () => {
        var btnIngresar = document.getElementById('ingresar');
        btnIngresar.onclick = cargaUsuarios;
    }
    init();

}