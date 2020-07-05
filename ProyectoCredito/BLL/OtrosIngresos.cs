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
    public class OtrosIngresos
    {
        #region propiedades

        private int _idPersona;
        public int idPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
        }

        private decimal _Sueldo_OtrosIngree;
        public decimal Sueldo_OtrosIngree
        {
            get { return _Sueldo_OtrosIngree; }
            set { _Sueldo_OtrosIngree = value; }
        }
        private decimal _BonosComision_OtrosIngree;
        public decimal BonosComision_OtrosIngree
        {
            get { return _BonosComision_OtrosIngree; }
            set { _BonosComision_OtrosIngree = value; }
        }
        private decimal _Rentas_OtrosIngree;
        public decimal Rentas_OtrosIngree
        {
            get { return _Rentas_OtrosIngree; }
            set { _Rentas_OtrosIngree = value; }
        }

        private decimal _Inversión_OtrosIngree;
        public decimal Inversión_OtrosIngree
        {
            get { return _Inversión_OtrosIngree; }
            set { _Inversión_OtrosIngree = value; }
        }

        private decimal _Otros_OtrosIngree;
        public decimal Otros_OtrosIngree
        {
            get { return _Otros_OtrosIngree; }
            set { _Otros_OtrosIngree = value; }
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
        public string carga_OtrosIngresos(int id)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "[Ver_Otroso_Ingresos]";
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
        public bool agregar_OtrosIngresos(string accion)
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
                    sql = "Insertar_Otros_Ingresos";
                }
                ParamStruct[] parametros = new ParamStruct[6];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Sueldo_OtrosIngree", SqlDbType.Decimal, _Sueldo_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@BonosComision_OtrosIngree", SqlDbType.Decimal, _BonosComision_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Rentas_OtrosIngree", SqlDbType.Decimal, _Rentas_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Inversión_OtrosIngree", SqlDbType.Decimal, _Inversión_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Otros_OtrosIngree", SqlDbType.Decimal, _Otros_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@id_Persona", SqlDbType.Int, _idPersona);
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

        public bool modificar_OtrosIngresos(string accion)
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
                    sql = "Modificar_Otros_Ingresos";
                }
                ParamStruct[] parametros = new ParamStruct[6];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Sueldo_OtrosIngree", SqlDbType.Decimal, _Sueldo_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@BonosComision_OtrosIngree", SqlDbType.Decimal, _BonosComision_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Rentas_OtrosIngree", SqlDbType.Decimal, _Rentas_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Inversión_OtrosIngree", SqlDbType.Decimal, _Inversión_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Otros_OtrosIngree", SqlDbType.Decimal, _Otros_OtrosIngree);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@id_Persona", SqlDbType.Int, _idPersona);
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
