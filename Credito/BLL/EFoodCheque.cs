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
    public class EFoodCheque
    {
        #region propiedades

        private string _codCheque;
        public string codCheque
        {
            get { return _codCheque; }
            set { _codCheque = value; }
        }

        private string _num_cuenta;
        public string num_cuenta
        {
            get { return _num_cuenta; }
            set { _num_cuenta = value; }
        }      

        private int _monto;

        public int monto
        {
            get { return _monto; }
            set { _monto = value; }
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
               
        //public bool agregar_tarjeta(string accion)
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
        //        if (accion.Equals("Insertar"))
        //        {
        //            sql = "stp_EFood_TarejetaCrear";
        //        }
        //        ParamStruct[] parametros = new ParamStruct[7];
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@num_taj", SqlDbType.VarChar, _numTarj);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@tipo", SqlDbType.VarChar, _tipo);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@mes", SqlDbType.Int, _mes);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@anio", SqlDbType.Int, _anio);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@cw", SqlDbType.Int, _cw);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@monto", SqlDbType.Int, _monto);
        //        cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@creODebi", SqlDbType.VarChar, _creODebi);
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
        public bool valida_cheque(string accion)
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
                    sql = "stp_EFood_ChequeValidad";
                }
                ParamStruct[] parametros = new ParamStruct[3];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cod_cheque", SqlDbType.VarChar, _codCheque);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@num_cuenta", SqlDbType.VarChar, _num_cuenta);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@saldo", SqlDbType.Int, _monto);
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
