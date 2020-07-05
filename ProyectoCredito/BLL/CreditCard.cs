using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Newtonsoft.Json;

namespace BLL
{
    public class CreditCard
    {
        private int _Cod_CreditCard;
        public int Cod_CreditCard
        {
            get { return _Cod_CreditCard; }
            set { _Cod_CreditCard = value; }
        }

        private int _Nom_CreditCard;
        public int Nom_CreditCard
        {
            get { return _Nom_CreditCard; }
            set { _Nom_CreditCard = value; }
        }

        private string _NumCuenta_CreditCard;
        public string NumCuenta_CreditCard
        {
            get { return _NumCuenta_CreditCard; }
            set { _NumCuenta_CreditCard = value; }
        }

        private string _Saldo_CreditCard;
        public string Saldo_CreditCard
        {
            get { return _Saldo_CreditCard; }
            set { _Saldo_CreditCard = value; }
        }
        private string _Id_Persona;
        public string Id_Persona
        {
            get { return _Id_Persona; }
            set { _Id_Persona = value; }
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
        public string carga_CreditCard(int id, string accion)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "Ver_Trabajo";
                ParamStruct[] parametros = new ParamStruct[2];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_CreditCard", SqlDbType.Int, Cod_CreditCard);
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


        public bool agregar_creditcard(string accion)
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
                    sql = "Insertar_CreditCard";
                }
                ParamStruct[] parametros = new ParamStruct[5];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_CreditCard", SqlDbType.Int, _Cod_CreditCard);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nom_CreditCard", SqlDbType.VarChar, _Nom_CreditCard);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@NumCuenta_CreditCard", SqlDbType.Int, _NumCuenta_CreditCard);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Saldo_CreditCard", SqlDbType.Decimal, _Saldo_CreditCard);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Id_Persona", SqlDbType.Int, _Id_Persona);
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
        public bool modificarCreditCard(string accion)
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
                    sql = "Modificar_CreditCard";
                }
                ParamStruct[] parametros = new ParamStruct[5];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_CreditCard", SqlDbType.Int, _Cod_CreditCard);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nom_CreditCard", SqlDbType.VarChar, _Nom_CreditCard);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@NumCuenta_CreditCard", SqlDbType.Int, _NumCuenta_CreditCard);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Saldo_CreditCard", SqlDbType.Decimal, _Saldo_CreditCard);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Id_Persona", SqlDbType.VarChar, _Id_Persona);
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
