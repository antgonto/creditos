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
  public  class GestionesPendientes
    {
        #region propiedades

        private int _idPersona;
        public int idPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
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
        public string carga_InfoUsuario(int id)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "[verInfoCompletaCliente]";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@id", SqlDbType.Int, id);
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


        public string cargarGestiones()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "verGestionesPendientes";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return (JsonConvert.SerializeObject(ds.Tables[0]));
                }
            }

        }

    }
}
#endregion