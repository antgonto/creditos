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
    public class EFoodDetalleFac
    {
        #region propiedades

        private int _factura;
        public int factura
        {
            get { return _factura; }
            set { _factura = value; }
        }

        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
               
        private int _precio;
        public int precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        private string _codPro;
        public string codPro
        {
            get { return _codPro; }
            set { _codPro = value; }
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
        //public string carga_lista_consecutivos()
        //{
        //    conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
        //    if (conexion == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        sql = "stp_consecutivo_ver";    
        //        ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
        //        if (numero_error != 0)
        //        {
        //         return null;
        //        }
        //        else
        //        {
        //            return  JsonConvert.SerializeObject(ds.Tables[0]);
        //        }
        //    }

        //}


        public bool agregar_detalle(string accion)
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
                    sql = "stp_EFood_DetalleFac";
                }
                ParamStruct[] parametros = new ParamStruct[4];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_pro", SqlDbType.VarChar, _codPro);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@cantidad", SqlDbType.VarChar, _cantidad);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@precio", SqlDbType.Int, _precio);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@factura", SqlDbType.Int, _factura);

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
