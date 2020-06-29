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
    public class EFoodPedido
    {
        #region propiedades

        

        private int _cliente;
        public int cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private int _costo;

        public int costo
        {
            get { return _costo; }
            set { _costo = value; }
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

        public string carga_lista_Pedido()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "stp_EFood_PedidoVer";
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
        public string carga_lista_UltimoPedido()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "stp_EFood_Pedido_Ultimo";
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


        public bool agregar_pedido(string accion)
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
                    sql = "[stp_EFood_PedidoCrear]";
                }
                ParamStruct[] parametros = new ParamStruct[2];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cliente", SqlDbType.Int, _cliente);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@costo", SqlDbType.Int, _costo);
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
                sql = "stp_Consulta_pedidos_verFecha";
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


        //public bool actualizar_consecutivo(string accion)
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
        //        if (accion.Equals("Actualizar"))
        //        {
        //            sql = "stp_consecutivo_modificar";
        //        }
        //        ParamStruct[] parametros = new ParamStruct[6];
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_consec_viejo", SqlDbType.Int, _cod_consec_viejo);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@cod_consec", SqlDbType.Int, _cod_consec);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@desc_consec", SqlDbType.VarChar, _desc_consec);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@posee_pref", SqlDbType.VarChar, _posee_pref);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@prefijo", SqlDbType.VarChar, _prefijo);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@usuario_nom_usu", SqlDbType.VarChar, _usuario_nom_usu);
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
        #endregion
    }
}
