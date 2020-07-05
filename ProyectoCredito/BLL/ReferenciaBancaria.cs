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
    public class ReferenciaBancaria
    {
        #region propiedades

        private int _idPersona;
        public int idPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
        }

        private string _NomInst_ReferBan;
        public string NomInst_ReferBan
        {
            get { return _NomInst_ReferBan; }
            set { _NomInst_ReferBan = value; }
        }

        private int _CuentaCorriente_ReferBan;
        public int CuentaCorriente_ReferBan
        {
            get { return _CuentaCorriente_ReferBan; }
            set { _CuentaCorriente_ReferBan = value; }
        }

        private decimal _CajaAhorros_ReferBan;
        public decimal CajaAhorros_ReferBan
        {
            get { return _CajaAhorros_ReferBan; }
            set { _CajaAhorros_ReferBan = value; }
        }
        private decimal _Prestamo_ReferBan;
        public decimal Prestamo_ReferBan
        {
            get { return _Prestamo_ReferBan; }
            set { _Prestamo_ReferBan = value; }
        }
        private decimal _SaldoPrestamo_ReferBan;
        public decimal SaldoPrestamo_ReferBan
        {
            get { return _SaldoPrestamo_ReferBan; }
            set { _SaldoPrestamo_ReferBan = value; }
        }

        private string _Direc_ReferBan;
        public string Direc_ReferBan
        {
            get { return _Direc_ReferBan; }
            set { _Direc_ReferBan = value; }
        }

        private int _Tel_ReferBan;
        public int Tel_ReferBan
        {
            get { return _Tel_ReferBan; }
            set { _Tel_ReferBan = value; }
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
        public string carga_ReferenciaBancaria(int id)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "[Ver_ReferBancar]";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@id_Persona", SqlDbType.Int, id);
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
        public bool agregar_ReferenciaBancaria(string accion)
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
                    sql = "Insertar_ReferBancar";
                }
                ParamStruct[] parametros = new ParamStruct[8];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@NomInst_ReferBan", SqlDbType.VarChar, _NomInst_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@CuentaCorriente_ReferBan", SqlDbType.Int, _CuentaCorriente_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@CajaAhorros_ReferBan", SqlDbType.Decimal, _CajaAhorros_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Prestamo_ReferBan", SqlDbType.Decimal, _Prestamo_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@SaldoPrestamo_ReferBan", SqlDbType.Decimal, _SaldoPrestamo_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Direc_ReferBan", SqlDbType.VarChar, _Direc_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Tel_ReferBan", SqlDbType.Int, _Tel_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Id_Persona", SqlDbType.Int, _idPersona);
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

        public bool modificar_ReferenciaBancaria(string accion)
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
                    sql = "Modificar_ReferBancar";
                }
                ParamStruct[] parametros = new ParamStruct[8];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@NomInst_ReferBan", SqlDbType.VarChar, _NomInst_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@CuentaCorriente_ReferBan", SqlDbType.Int, _CuentaCorriente_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@CajaAhorros_ReferBan", SqlDbType.Decimal, _CajaAhorros_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Prestamo_ReferBan", SqlDbType.Decimal, _Prestamo_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@SaldoPrestamo_ReferBan", SqlDbType.Decimal, _SaldoPrestamo_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Direc_ReferBan", SqlDbType.VarChar, _Direc_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Tel_ReferBan", SqlDbType.Int, _Tel_ReferBan);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Id_Persona", SqlDbType.Int, _idPersona);
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
