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
   public class Gastos
    {

        #region propiedades

        private int _idPersona;
        public int idPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
        }

        private decimal _prestamo_Gasto;
        public decimal prestamo_Gasto
        {
            get { return _prestamo_Gasto; }
            set { _prestamo_Gasto = value; }
        }
        private decimal _factuMensu_Gasto;
        public decimal factuMensu_Gasto
        {
            get { return _factuMensu_Gasto; }
            set { _factuMensu_Gasto = value; }
        }
        private decimal _Hipotecas_Gasto;
        public decimal Hipotecas_Gasto
        {
            get { return _Hipotecas_Gasto; }
            set { _Hipotecas_Gasto = value; }
        }

        private decimal _Otros_Gasto;
        public decimal Otros_Gasto
        {
            get { return _Otros_Gasto; }
            set { _Otros_Gasto = value; }
        }

        private decimal _Total_Gasto;
        public decimal Total_Gasto
        {
            get { return _Total_Gasto; }
            set { _Total_Gasto = value; }
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
        public string carga_Gastos(int id)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "[Ver_Gastos]";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@idPersona", SqlDbType.Int, id);
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
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

        public bool agregar_Gastos(string accion)
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
                    sql = "InsertarGastos";
                }
                ParamStruct[] parametros = new ParamStruct[5];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@prestamo_Gasto", SqlDbType.Decimal, _prestamo_Gasto);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@factuMensu_Gasto", SqlDbType.Decimal, _factuMensu_Gasto);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Hipotecas_Gasto", SqlDbType.Decimal, _Hipotecas_Gasto);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Otros_Gasto", SqlDbType.Decimal, _Otros_Gasto);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@id_Persona", SqlDbType.Int, _idPersona);
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

        public bool modificarGastos(string accion)
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
                    sql = "Modificar_Gastos";
                }
                ParamStruct[] parametros = new ParamStruct[5];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@prestamo_Gasto", SqlDbType.Decimal, _prestamo_Gasto);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@factuMensu_Gasto", SqlDbType.Decimal, _factuMensu_Gasto);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Hipotecas_Gasto", SqlDbType.Decimal, _Hipotecas_Gasto);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Otros_Gasto", SqlDbType.Decimal, _Otros_Gasto);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@id_Persona", SqlDbType.Int, _idPersona);
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
