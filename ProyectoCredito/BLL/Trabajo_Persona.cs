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
    public class Trabajo_Persona
    {
        #region
        private int _Cod_Trabajo;
        public int Cod_Trabajo
        {
            get { return _Cod_Trabajo; }
            set { _Cod_Trabajo = value; }
        }

        private int _Id_Persona;
        public int Id_Persona
        {
            get { return _Id_Persona; }
            set { _Id_Persona = value; }
        }

        private string _SueldoMen_Trabajo;
        public string SueldoMen_Trabajo
        {
            get { return _SueldoMen_Trabajo; }
            set { _SueldoMen_Trabajo = value; }
        }

        private string _FechaIngrso_Trabajo;
        public string FechaIngrso_Trabajo
        {
            get { return _FechaIngrso_Trabajo; }
            set { _FechaIngrso_Trabajo = value; }
        }
        private string _Puesto_Trabajo;
        public string Puesto_Trabajo
        {
            get { return _Puesto_Trabajo; }
            set { _Puesto_Trabajo = value; }
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
        public string carga_Trabajo_Persona(int id)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "[Ver_Trabajo_Persona]";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Trabajo", SqlDbType.Int, id);
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
        public bool agregar_trabajo_persona(string accion)
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
                    sql = "Insertar_Trabajo_Persona";
                }
                ParamStruct[] parametros = new ParamStruct[4];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Id_Persona", SqlDbType.Int, _Id_Persona);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@SueldoMen_Trabajo", SqlDbType.Int, _SueldoMen_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@FechaIngrso_Trabajo", SqlDbType.Date, _FechaIngrso_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Puesto_Trabajo", SqlDbType.VarChar, _Puesto_Trabajo);
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
        public bool modificarTrabajoPersona(string accion)
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
                    sql = "Modificar_Trabajo_Persona";
                }
                ParamStruct[] parametros = new ParamStruct[4];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Id_Persona", SqlDbType.Int, _Id_Persona);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@SueldoMen_Trabajo", SqlDbType.Int, _SueldoMen_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@FechaIngrso_Trabajo", SqlDbType.Date, _FechaIngrso_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Puesto_Trabajo", SqlDbType.VarChar, _Puesto_Trabajo);
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
