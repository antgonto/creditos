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
    public class Usuario_Estado
    {
        #region propiedades
        private string _nom_usu;

        public string nom_usu
        {
            get { return _nom_usu; }
            set { _nom_usu = value; }
        }

        private string _estado;
        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
       

        private string _nom_usuario_modificador;
        public string nom_usuario_modificador
        {
            get { return _nom_usuario_modificador; }
            set { _nom_usuario_modificador = value; }
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
        public string carga_lista_UsuariosEstado()
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "stp_usuario_verNombreyEstado";
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

        public bool agregar_usuario_Estado(string accion)
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
                if (accion.Equals("Actualizar"))
                {
                    sql = "stp_usuario_modificar_edo";
                }
                ParamStruct[] parametros = new ParamStruct[3];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@nom_usu", SqlDbType.VarChar, nom_usu);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@estado", SqlDbType.VarChar, estado);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@nom_usuario_modificador", SqlDbType.VarChar, _nom_usuario_modificador);
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
