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
    public class Productos
    {
        #region propiedades
        private string _cod_prod;
        public string cod_prod
        {
            get { return _cod_prod; }
            set { _cod_prod = value; }
        }

        private string _desc_prod;
        public string desc_prod
        {
            get { return _desc_prod; }
            set { _desc_prod = value; }
        }

        private string _contenido;
        public string contenido
        {
            get { return _contenido; }
            set { _contenido = value; }
        }

        private string _linea_comida;
        public string linea_comida
        {
            get { return _linea_comida; }
            set { _linea_comida = value; }
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
        public string carga_lista_Productos()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "stp_producto_ver";    
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

        public bool agregar_producto(string accion)
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
                    sql = "stp_producto_crear";
                }
                ParamStruct[] parametros = new ParamStruct[4];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@desc_prod", SqlDbType.VarChar, _desc_prod );
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@contenido", SqlDbType.VarChar, _contenido);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@desc_licom", SqlDbType.VarChar,_linea_comida );
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@usuario_nom_usu", SqlDbType.VarChar, _usuario_nom_usu );
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

        public bool eliminar_producto(string cod_planta)
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
                sql = "stp_producto_eliminar";
                ParamStruct[] parametros = new ParamStruct[2];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_prod", SqlDbType.VarChar, _cod_prod);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@usuario_ejecutor", SqlDbType.VarChar, _usuario_nom_usu);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                 //   HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
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
        public bool modificar_producto(string accion)
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
                    sql = "stp_producto_modificar";
                }
                ParamStruct[] parametros = new ParamStruct[5];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_prod", SqlDbType.VarChar, _cod_prod);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@desc_prod", SqlDbType.VarChar, _desc_prod);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@contenido", SqlDbType.VarChar, _contenido);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@desc_licom", SqlDbType.VarChar, _linea_comida);
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
