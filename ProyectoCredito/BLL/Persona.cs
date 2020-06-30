using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Newtonsoft.Json;

namespace BLL
{
    public class Persona
    {
        #region propiedades

        private int _idPersona;
        public int idPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
        }

        private int _idPersonaActualizado;
        public int idPersonaActualizado
        {
            get { return _idPersonaActualizado; }
            set { _idPersonaActualizado = value; }
        }

        private string _nombre1;
        public string nombre1
        {
            get { return _nombre1; }
            set { _nombre1 = value; }
        }

        private string _nombre2;
        public string nombre2
        {
            get { return _nombre2; }
            set { _nombre2 = value; }
        }
        private string _apellido1;
        public string apellido1
        {
            get { return _apellido1; }
            set { _apellido1 = value; }
        }
        private string _apellido2;
        public string apellido2
        {
            get { return _apellido2; }
            set { _apellido2 = value; }
        }

        private string _estadoCivil;
        public string estadoCivil
        {
            get { return _estadoCivil; }
            set { _estadoCivil = value; }
        }

        private int _telefono1;
        public int telefono1
        {
            get { return _telefono1; }
            set { _telefono1 = value; }
        }

        private int _telefono2;
        public int telefono2
        {
            get { return _telefono2; }
            set { _telefono2 = value; }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _nacionalidad;
        public string nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        private string _provincia;
        public string provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }
        private string _canton;
        public string canton
        {
            get { return _canton; }
            set { _canton= value; }
        }
        private string _distrito;
        public string distrito
        {
            get { return _distrito; }
            set { _distrito = value; }
        }
        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private string _clave;
        public string clave
        {
            get { return _clave; }
            set { _clave = value; }

        }
        private int _codTipoPersona;
        public int codTipoPersona
        {
            get { return _codTipoPersona; }
            set { _codTipoPersona = value; }
        }

        private int _id_conyuge;
        public int id_conyuge
        {
            get { return _id_conyuge; }
            set { _id_conyuge = value; }
        }
        private string _accion;
        public string accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        #endregion

        #region variables privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
        public string carga_Persona(int id,string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "Ver_Persona";
                ParamStruct[] parametros = new ParamStruct[2];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@idPersona", SqlDbType.Int, id);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@accion", SqlDbType.VarChar, accion);
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    //HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    return null;
                }
                else
                {
                    return JsonConvert.SerializeObject(ds.Tables[0]);
                }
            }

        }

        public bool agregar_persona(string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                 return false;
            }
            else
            {
                if (accion.Equals("Insertar"))
                {
                    sql = "Insertar_Persona";
                }
                ParamStruct[] parametros = new ParamStruct[17];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Id_Persona", SqlDbType.Int, _idPersona );
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nom1_Persona", SqlDbType.VarChar, _nombre1);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Nom2_Persona", SqlDbType.VarChar,_nombre2 );
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Apell1_Persona", SqlDbType.VarChar, _apellido1 );
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Apell2_Persona", SqlDbType.VarChar, _apellido2);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@EstadoCivil_Persona", SqlDbType.VarChar, _estadoCivil);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Tel1_Persona", SqlDbType.Int, _telefono1);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Tel2_Persona", SqlDbType.Int, _telefono2);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Email_Persona", SqlDbType.VarChar, _email);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Nacion_Persona", SqlDbType.VarChar, _nacionalidad);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 10, "@Provincia_Persona", SqlDbType.VarChar, _provincia);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 11, "@Cantón_Persona", SqlDbType.VarChar, _canton);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 12, "@Distrito_Persona", SqlDbType.VarChar, _distrito);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 13, "@Dirección_Persona", SqlDbType.VarChar, _direccion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 14, "@Clave_Persona", SqlDbType.VarChar, _clave);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 15, "@Cod_Tipo_Per", SqlDbType.Int, _codTipoPersona );
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 16, "@Id_Conyuge", SqlDbType.Int, _id_conyuge);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    //HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return false;
                }
                else
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return true;
                }
            }
        }

        //public bool eliminar_producto(string cod_planta)
        //{
        //    conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
        //    if (conexion == null)
        //    {
        //        //insertar en la table de errores
        //        //HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
        //        return false;
        //    }
        //    else
        //    {
        //        sql = "stp_producto_eliminar";
        //        ParamStruct[] parametros = new ParamStruct[2];
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_prod", SqlDbType.VarChar, _cod_prod);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@usuario_ejecutor", SqlDbType.VarChar, _usuario_nom_usu);
        //        cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
        //        cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        //        if (numero_error != 0)
        //        {
        //            //insertar en la table de errores
        //         //   HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
        //            cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
        //            return false;
        //        }
        //        else
        //        {
        //            cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
        //            return true;
        //        }
        //    }
        //}
        public bool modificarPersona(string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {              
                return false;
            }
            else
            {
                if (accion.Equals("Actualizar"))
                {
                    sql = "Modificar_Persona";
                }
                ParamStruct[] parametros = new ParamStruct[19];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Id_Persona_Viejo", SqlDbType.Int, _idPersona);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Id_Actualizado", SqlDbType.Int, _idPersonaActualizado);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Nom1_Persona", SqlDbType.VarChar, _nombre1);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Nom2_Persona", SqlDbType.VarChar, _nombre2);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Apell1_Persona", SqlDbType.VarChar, _apellido1);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Apell2_Persona", SqlDbType.VarChar, _apellido2);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@EstadoCivil_Persona", SqlDbType.VarChar, _estadoCivil);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Tel1_Persona", SqlDbType.Int, _telefono1);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Tel2_Persona", SqlDbType.Int, _telefono2);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Email_Persona", SqlDbType.VarChar, _email);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 10, "@Nacion_Persona", SqlDbType.VarChar, _nacionalidad);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 11, "@Provincia_Persona", SqlDbType.VarChar, _provincia);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 12, "@Cantón_Persona", SqlDbType.VarChar, _canton);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 13, "@Distrito_Persona", SqlDbType.VarChar, _distrito);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 14, "@Dirección_Persona", SqlDbType.VarChar, _direccion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 15, "@Clave_Persona", SqlDbType.VarChar, _clave);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 16, "@Cod_Tipo_Per", SqlDbType.Int, _codTipoPersona);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 17, "@accion", SqlDbType.VarChar, _accion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 18, "@Id_Conyuge", SqlDbType.Int, _id_conyuge);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {                
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return false;
                }
                else
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return true;
                }
            }
        }
        #endregion
    }
}
