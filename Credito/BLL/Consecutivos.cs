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
    public class Consecutivo
    {
        #region propiedades

        private int _cod_consec;
        public int cod_consec
        {
            get { return _cod_consec; }
            set { _cod_consec = value; }
        }

        private string _desc_consec;
        public string desc_consec
        {
            get { return _desc_consec; }
            set { _desc_consec = value; }
        }

        private string _posee_pref;

        public string posee_pref
        {
            get { return _posee_pref; }
            set { _posee_pref = value; }
        }

        private string _prefijo;
        public string prefijo
        {
            get { return _prefijo; }
            set { _prefijo = value; }
        }

        private string _usuario_nom_usu;
        public string usuario_nom_usu
        {
            get { return _usuario_nom_usu; }
            set { _usuario_nom_usu = value; }
        }
        private int _cod_consec_viejo;

        public int cod_consec_viejo
        {
            get { return _cod_consec_viejo; }
            set { _cod_consec_viejo = value; }
        }

        public string _prefijo_viejo;
        public string prefijo_viejo
        {
            get { return _prefijo_viejo; }
            set { _prefijo_viejo = value; }
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
        public string carga_lista_consecutivos()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "stp_consecutivo_ver";
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
        public string carga_lista_consecutivos2()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "stp_consecutivo_ver_SinCon ";
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
        public string carga_lista_consecutivo_prefijo(int consecutivo)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                //  HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return null;
            }
            else
            {
                sql = "stp_consecutivo_verPrefijo";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_consec", SqlDbType.VarChar, consecutivo);
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

        public bool agregar_consecutivo(string accion)
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
                    sql = "stp_consecutivo_crear";
                }
                ParamStruct[] parametros = new ParamStruct[5];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_consec", SqlDbType.Int, _cod_consec);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@desc_consec", SqlDbType.VarChar, _desc_consec);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@posee_pref", SqlDbType.VarChar, _posee_pref);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@prefijo", SqlDbType.VarChar, _prefijo);
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
        public bool actualizar_consecutivo(string accion)
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
                    sql = "stp_consecutivo_modificar";
                }
                ParamStruct[] parametros = new ParamStruct[6];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_consec_viejo", SqlDbType.Int, _cod_consec_viejo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@cod_consec", SqlDbType.Int, _cod_consec);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@desc_consec", SqlDbType.VarChar, _desc_consec);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@posee_pref", SqlDbType.VarChar, _posee_pref);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@prefijo", SqlDbType.VarChar, _prefijo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@usuario_nom_usu", SqlDbType.VarChar, _usuario_nom_usu);
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
