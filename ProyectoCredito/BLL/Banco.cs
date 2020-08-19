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
  public class Banco
    {
        #region propiedades

        private int _idGestion;
        public int idGestion
        {
            get { return _idGestion; }
            set { _idGestion = value; }
        }
        private string _nombreEntidad;
        public string nombreEnditdad
        {
            get { return _nombreEntidad; }
            set { _nombreEntidad = value; }
        }
        private string _respuesta;
        public string respuesta
        {
            get { return _respuesta; }
            set { _respuesta = value; }
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
        public string carga_RespuestaBanco(int id)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "[verRespuestaBanco]";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@idGestion", SqlDbType.Int, id);
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
        public bool agregar_RespuestaBanco(string accion)
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
                    sql = "Insert_Respuesta_Banco";
                }
                ParamStruct[] parametros = new ParamStruct[3];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@id_Gestion", SqlDbType.Int, _idGestion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@nombreEntidad", SqlDbType.VarChar, _nombreEntidad);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@respuesta", SqlDbType.VarChar, _respuesta);                
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
