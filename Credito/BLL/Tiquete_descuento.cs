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
    public class Tiquete_descuento
    {
        #region propiedades

        private string _cod_desc;
        public string cod_desc
        {
            get { return _cod_desc; }
            set { _cod_desc = value; }
        }

        private string _desc_descuento;
        public string desc_descuento
        {
            get { return _desc_descuento; }
            set { _desc_descuento = value; }
        }

        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private int _descuento;
        public int descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }

        private string _usuario_nom_usu;
        public string usuario_nom_usu
        {
            get { return _usuario_nom_usu; }
            set { _usuario_nom_usu = value; }
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
        public string carga_lista_tiquetes()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "stp_tiquete_desc_ver";    
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                 return null;
                }
                else
                {
                    return  JsonConvert.SerializeObject(ds.Tables[0]);
                }
            }

        }
        public bool agregar_tiquete_descuento(string accion)
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
                    sql = "stp_tiquete_desc_crear";
                }
                ParamStruct[] parametros = new ParamStruct[5];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_desc", SqlDbType.VarChar,_cod_desc);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@desc_descuento", SqlDbType.VarChar, _desc_descuento);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@cantidad", SqlDbType.Int, _cantidad);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@descuento", SqlDbType.Int, _descuento);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@usuario_nom_usu", SqlDbType.VarChar, _usuario_nom_usu);
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


        public bool eliminar_tiquete_descuento(string cod_planta)
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
                sql = "stp_tiquete_desc_eliminar";
                ParamStruct[] parametros = new ParamStruct[2];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_desc", SqlDbType.VarChar, _cod_desc );
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@usuario_ejecutor", SqlDbType.VarChar, _usuario_nom_usu);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                   // HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
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

        public bool modificar_tiquete_descuento(string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                //HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return false;
            }
            else
            {
                if (accion.Equals("Actualizar"))
                {
                    sql = "stp_tiquete_desc_modificar";
                }
                ParamStruct[] parametros = new ParamStruct[5];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_desc", SqlDbType.VarChar, _cod_desc);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@desc_descuento", SqlDbType.VarChar, _desc_descuento);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@cantidad", SqlDbType.Int, _cantidad);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@descuento", SqlDbType.VarChar, _descuento);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@usuario_nom_usu", SqlDbType.VarChar, _usuario_nom_usu);
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
        #endregion
    }
}
