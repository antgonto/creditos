# creditos
Estudiantes:
Karla López Mora,
Oscar Campos Espinoza,
Saeeth Azofeifa Zeledon,
Luis Montecinos Jimenez

Sobre el proyecto

El proyecto consiste en una aplicación para solicitud de créditos donde la idea es que un cliente en un solo lugar pueda enviar su información y su solicitud a múltiples entidades financieras y recibir respuesta de estas sobre la solicitud de crédito.

En la aplicación existe un login para usuario tipo cliente y usuario tipo banco. El usuario cliente puede ingresar sus datos personales y además se le solicitará toda la información que las entidades financieras solicitan para revisar el perfil de un cliente y decidir si se le puede dar el crédito solicitado. El login del banco es solo para aquellas cuentas cuyo tipo de usuario sea bancario. Cuando el banco hace inicio de sesión ve las solicitudes pendientes de clientes y al darle click a ver detalles cliente, puede ver toda la información de ese cliente para así decidir si rechaza o no la solicitud.

El backend de la aplicación se desarrolla con Visual Studio y el lenguaje de programación es C#. Se utiliza un .Net Framework para la creación del API y dos proyectos más tipo librería. Uno de estos es el BLL que es el que tiene la lógica de cada una de las tablas de la base de datos y es lo que le envía información a ésta según lo que recibe del controlador que es quien el front end llama via promesas, mientras que el DAL es un proyecto de librería que es el que nos permite generar los métodos que el BLL utiliza para llamar a la base de datos.

La base de datos se construye con SQL Server y se hacen procedimientos almacenados para realizar las inserciones, actualizaciones y visualizaciones de datos.Por su parte el front end se manejó en Visual Code y se utilizó una plantila (Mamba) como base. Como se mencionó anteriormente, mediante promesas se llaman las diferentes rutas generadas por el API para poder realizar las distintas funciones.

Para poder correr el proyecto se debe primero restaurar la base de datos, se proporciona el .bak de esta. Una vez hecho esto, se debe ir al API y actualizar el Web.config para poner la ruta correspondiente al servidor de su base de datos en la parte de connectionStrings, específicamente el campo de Data Source. 

Al correr el API se debe levantar el proyecto y una vez arriba puede abrir desde Visual Code la página de index.html en el browser. Esta es la página principal del proyecto. Ya con esto la persona puede hacer login como usuario o  banco (hay datos de prueba ya guardados en el .bak), si se quiere ingresar como banco puede usar el usuario 1 con el password 122, si quiere ingresar como un usuario cliente lo puede hacer con usuario 2 y password 122. También puede generar un usuario tipo cliente nuevo y luego hacer login con la información proporcionada para ese usuario (se utiliza la cédula para que la persona haga login y el password que haya ingresado al hacer el registro). Las entidades bancarias no pueden hacer creación de cuenta.

A continuación un desglose más detallado de la estructura de la aplicación.

IDE's:
Visual Studio
Visual Studio Code
SQL Server Management Studio

Estructura del proyecto:
API(BackEnd)
FrontEnd
SQL Database

Contenido del API (BackEnd):
IDE: Visual Studio
BLL:
Banco.cs
CreditCard.cs
Gastos.cs
GestionesPendientes.cs
GestionFormulario.cs
OtrosIngresos.cs
Persona.cs
ReferenciaBancaria.cs
Trabajo.cs
Trabajo_Persona.cs

Proyecto de créditos:
App_Data
App_Start
Areas
Content
Controllers
BancoController.cs
CreditCardController.cs
GastosController.cs
GestionesPendientesController.cs
GestionFormularioController.cs
HomeController.cs
OtrosIngresosController.cs
PersonaController.cs
ReferenciaBancariaController.cs
Trabajo_PersonaController.cs
TrabajoController.cs
ValuesController.cs
Fonts
Models
Scripts
Views
favicon.ico
Global.exe
packages.config
Web.config
DAL library

Contenido del FrontEnd:
IDE usado: Visual Studio Code
Assets
CSS
Forms
IMG
JS
BancoDetalleCliente.js
BancoGestionesPendientes.js
Bancologin.js
Conyuge.js
DatosCli.js
Gastos.js
Gestion.js
Jquery.js
Login.js
OtrosIngresos.js
Persona.js
Personaver.js
Principal.js
Prueba.js
ReferBancaria.js
Tcredito.js
Trabajo.js
TrabajoMedia.js
UpConyuge.js
UpDatosCli.js
UPGastos.js
UPgastosingresos.js
UPReferBancaria.js
UPTcredito.js
UPTrabajo.js
UPTrabajoMedia.js
VerDatos.js
HTMLS:
BancoDetalleCliente.html
FormularioGestion.html
Gastos.html
Index.html
IngresosDatosCLI.html
Login.html
Otrosingresos.html
Popup.html
Principal.html
Prueba.html
Referbancaria.html
Registro.html
Servicios.html
Tcredito.html
TrabajosCLI.html
TrabajosMedia.html
UPConyuge.html
UpGastos.html
UPIngresosDatosCLI.html
UPOtrosingresos.html
UpReferbsncaria.html
UPTcredito.html
UPTrabajosCLI.html
UpTrabajosMedia.html
VerDatosP.html


Nombre de base de datos: Banco2
Tablas de base de datos: 

Credit_card
Gastos
GestionForumlario
Otros_Ingresos
Persona
Referencia bancaria
RespuestaBanco
Trabajo persona
Tipo_persona
Trabajo
Usuario
