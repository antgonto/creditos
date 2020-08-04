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
    public class Trabajo
    {
        #region
        

        private string _Nom_Trabajo;
        public string Nom_Trabajo
        {
            get { return _Nom_Trabajo; }
            set { _Nom_Trabajo = value; }
        }

        private string _Lugar_Trabajo;
        public string Lugar_Trabajo
        {
            get { return _Lugar_Trabajo; }
            set { _Lugar_Trabajo = value; }
        }

        private string _Provincia_Trabajo;
        public string Provincia_Trabajo
        {
            get { return _Provincia_Trabajo; }
            set { _Provincia_Trabajo = value; }
        }
        private string _Canton_Trabajo;
        public string Canton_Trabajo
        {
            get { return _Canton_Trabajo; }
            set { _Canton_Trabajo = value; }
        }
        private string _Distrito_Trabajo;
        public string Distrito_Trabajo
        {
            get { return _Distrito_Trabajo; }
            set { _Distrito_Trabajo = value; }
        }

        private string _Dirección_Trabajo;
        public string Dirección_Trabajo
        {
            get { return _Dirección_Trabajo; }
            set { _Dirección_Trabajo = value; }
        }

        private int _Tel_Trabajo;
        public int Tel_Trabajo
        {
            get { return _Tel_Trabajo; }
            set { _Tel_Trabajo = value; }
        }

        private string _Email_Trabajo;
        public string Email_Trabajo
        {
            get { return _Email_Trabajo; }
            set { _Email_Trabajo = value; }
        }

        private int _CodPostal_Trabajo;
        public int CodPostal_Trabajo
        {
            get { return _CodPostal_Trabajo; }
            set { _CodPostal_Trabajo = value; }
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
        public string carga_Trabajo(int id)
        {
            conexion = cls_DAL.trae_conexion("Progra5", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "[Ver_Trabajo]";
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

        public bool agregar_trabajo(string accion)
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
                    sql = "Insertar_Trabajo";
                }
                ParamStruct[] parametros = new ParamStruct[9];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Nom_Trabajo", SqlDbType.VarChar, _Nom_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Lugar_Trabajo", SqlDbType.VarChar, _Lugar_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Provincia_Trabajo", SqlDbType.VarChar, _Provincia_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Canton_Trabajo", SqlDbType.VarChar, _Canton_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Distrito_Trabajo", SqlDbType.VarChar, _Distrito_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Dirección_Trabajo", SqlDbType.VarChar, _Dirección_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Tel_Trabajo", SqlDbType.Int, _Tel_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Email_Trabajo", SqlDbType.VarChar, _Email_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@CodPostal_Trabajo", SqlDbType.Int, _CodPostal_Trabajo);
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
        public bool modificarTrabajo(string accion)
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
                    sql = "Modificar_Trabajo";
                }
                ParamStruct[] parametros = new ParamStruct[9];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Nom_Trabajo", SqlDbType.VarChar, _Nom_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Lugar_Trabajo", SqlDbType.VarChar, _Lugar_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Provincia_Trabajo", SqlDbType.VarChar, _Provincia_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Canton_Trabajo", SqlDbType.VarChar, _Canton_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Distrito_Trabajo", SqlDbType.VarChar, _Distrito_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Dirección_Trabajo", SqlDbType.VarChar, _Dirección_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Tel_Trabajo", SqlDbType.Int, _Tel_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Email_Trabajo", SqlDbType.VarChar, _Email_Trabajo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@CodPostal_Trabajo", SqlDbType.Int, _CodPostal_Trabajo);
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
