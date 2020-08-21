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
   public class GestionFormulario
    {

        private decimal _Valor_Credito;
        public decimal Valor_Credito
        {
            get { return _Valor_Credito; }
            set { _Valor_Credito = value; }
        }

        private string _Plazo_Credito;
        public string Plazo_Credito
        {
            get { return _Plazo_Credito; }
            set { _Plazo_Credito = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Planilla;
        public string Planilla
        {
            get { return _Planilla; }
            set { _Planilla = value; }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private int _Id_Persona;
        public int Id_Persona
        {
            get { return _Id_Persona; }
            set { _Id_Persona = value; }
        }

        #region variables privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        public string carga_GestionFormulario(int id)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "[Ver_GestionFormulario]";
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

        public bool agregar_gestionformulario(string accion)
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
                    sql = "Insert_GestionFormulario";
                }
                ParamStruct[] parametros = new ParamStruct[6];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ValorCredito", SqlDbType.Decimal, _Valor_Credito);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@PlazoCredito", SqlDbType.VarChar, _Plazo_Credito);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Descripcion", SqlDbType.VarChar, _Descripcion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Planilla", SqlDbType.VarChar, _Planilla);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Estado", SqlDbType.VarChar, _Estado);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Id_Persona", SqlDbType.Int, _Id_Persona);
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

        public bool modificar_gestionformulario(string accion)
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
                    sql = "Modificar_GestionFormulrio";
                }
                ParamStruct[] parametros = new ParamStruct[6];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ValorCredito", SqlDbType.Decimal, _Valor_Credito);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@PlazoCredito", SqlDbType.VarChar, _Plazo_Credito);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Descripcion", SqlDbType.VarChar, _Descripcion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Planilla", SqlDbType.Bit, _Planilla);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Estado", SqlDbType.VarChar, _Estado);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Id_Persona", SqlDbType.Int, _Id_Persona);
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



    }
}
