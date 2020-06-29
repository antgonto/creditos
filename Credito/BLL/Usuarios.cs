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
    public class Usuarios
    {
        #region propiedades
        private string _nom_usu;
        public string nom_usu
        {
            get { return _nom_usu; }
            set { _nom_usu = value; }
        }
        private string _contrasena;
        public string contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        private string _correo;
        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        private string _pregunta_seg;

        public string pregunta_seg
        {
            get { return _pregunta_seg; }
            set { _pregunta_seg = value; }
        }

        private string _respuesta_seg;
        public string respuesta_seg
        {
            get { return _respuesta_seg; }
            set { _respuesta_seg = value; }
        }

        private string _estado;
        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _usuario_creador;
        public string usuario_creador
        {
            get { return _usuario_creador; }
            set { _usuario_creador = value; }
        }
        private string _usuario_ejecutor;
        public string usuario_ejecutor
        {
            get { return _usuario_ejecutor; }
            set { _usuario_ejecutor = value; }
        }

        private string _contrasenavieja;
        public string contrasenavieja
        {
            get { return _contrasenavieja; }
            set { _contrasenavieja = value; }
        }

        private string _contrasenanueva;
        public string contrasenanueva
        {
            get { return _contrasenanueva; }
            set { _contrasenanueva = value; }
        }

        private string _nom_usuario_modificador;
        public string nom_usuario_modificador
        {
            get { return _nom_usuario_modificador; }
            set { _nom_usuario_modificador = value; }
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
        public string carga_lista_usuarios()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "stp_usuario_verNombre";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return JsonConvert.SerializeObject(ds.Tables[0]);
                }
            }

        }

        public bool agregar_usuario(string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                //    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return false;
            }
            else
            {
                if (accion.Equals("Insertar"))
                {
                    sql = "stp_usuario_crear";
                }
                ParamStruct[] parametros = new ParamStruct[7];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@nom_usu", SqlDbType.VarChar, _nom_usu);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@contrasena", SqlDbType.VarChar, _contrasena);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@correo", SqlDbType.VarChar, _correo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@pregunta_seg", SqlDbType.VarChar, _pregunta_seg);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@respuesta_seg", SqlDbType.VarChar, _respuesta_seg);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@estado", SqlDbType.VarChar, _estado);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@usuario_creador", SqlDbType.VarChar, _usuario_creador);
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
        public bool modificar_usuario_contrasena(string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                //    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return false;
            }
            else
            {
                if (accion.Equals("Actualizar"))
                {
                    sql = "stp_usuario_modificar_contrasena";
                }
                ParamStruct[] parametros = new ParamStruct[4];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@nom_usu", SqlDbType.VarChar, _nom_usu);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@contrasenavieja", SqlDbType.VarChar, _contrasenavieja);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@contrasenanueva", SqlDbType.VarChar, _contrasenanueva);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@nom_usuario_modificador", SqlDbType.VarChar, _nom_usuario_modificador);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {

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


        public bool elimina_usuario(string nom_usu)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                // HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return false;
            }
            else
            {
                sql = "stp_usuario_eliminar";
                ParamStruct[] parametros = new ParamStruct[2];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@nom_usu", SqlDbType.VarChar, _nom_usu);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@usuario_ejecutor", SqlDbType.VarChar, _usuario_ejecutor);
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


        #endregion
    }
}
