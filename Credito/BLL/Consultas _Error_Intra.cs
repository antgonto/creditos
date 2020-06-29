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
    public class Consultas_Error_Intra
    {
        #region propiedades

        private string _fecha1;
        public string fecha1
        {
            get { return _fecha1; }
            set { _fecha1 = value; }
        }

        private string _fecha2;
        public string fecha2
        {
            get { return _fecha2; }
            set { _fecha2 = value; }
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
        public string carga_lista_consultas_errores_intra()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "stp_Consulta_error_intra_ver";    
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

        //public bool carga_lista_erroresRango(string accion)
        //{
        //    conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
        //    if (conexion == null)
        //    {
        //        //insertar en la table de errores
        //        //    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
        //        return false;
        //    }
        //    else
        //    {
        //        if (accion.Equals("Buscar"))
        //        {
        //            sql = "stp_Consulta_error_intra_verFecha";
        //        }
        //        ParamStruct[] parametros = new ParamStruct[2];
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@fecha1", SqlDbType.VarChar, _fecha1);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@fecha2", SqlDbType.VarChar, _fecha2);
        //        cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
        //        cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        //        if (numero_error != 0)
        //        {
        //            //insertar en la table de errores
        //            //HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
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
        
          public string carga_lista_erroresRango(string fecha1, string fecha2)
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
                sql = "stp_Consulta_error_intra_verFecha";
                ParamStruct[] parametros = new ParamStruct[2];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@fecha1", SqlDbType.VarChar, fecha1);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@fecha2", SqlDbType.VarChar, fecha2);
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
         

        #endregion
    }
}
