using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TP6
{
    public class GestionProductos
    {
        public GestionProductos()
        {

        }

        private DataTable ObtenerTabla(string nombre, string sql)
        {
            DataSet ds = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adp = datos.obtenerAdaptador(sql);
            adp.Fill(ds, nombre);
            return ds.Tables[nombre];
        }

        public DataTable ObtenerTodosLosProductos(int ejercicio)
        {
            if(ejercicio == 1)
            {
                return ObtenerTabla("Productos", "Select IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad from Productos");
            }
            else
            {
                return ObtenerTabla("Productos", "Select IdProducto, NombreProducto, IdProveedor, PrecioUnidad from Productos");
            }
        }

        private void ArmarParametrosProductosEliminar(ref SqlCommand comando, Producto prod)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            SqlParametros.Value = prod.IdProducto;
        }

        private void ArmarParametrosProductos(ref SqlCommand comando, Producto prod)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            SqlParametros.Value = prod.IdProducto;
            SqlParametros = comando.Parameters.Add("@NombreProducto", SqlDbType.NVarChar,40);
            SqlParametros.Value = prod.NombreProducto;
            SqlParametros = comando.Parameters.Add("@CantidadPorUnidad", SqlDbType.NVarChar,20);
            SqlParametros.Value = prod.CantidadPorUnidad;
            SqlParametros = comando.Parameters.Add("@PrecioUnidad", SqlDbType.Money);
            SqlParametros.Value = prod.PrecioUnidad;
        }

        public bool ActualizarProducto(Producto prod)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosProductos(ref cmd, prod);
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.EjecutarProcedAlmacenado(cmd, "spActualizarProducto");
            if (filas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarProducto(Producto prod)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosProductosEliminar(ref cmd, prod);
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.EjecutarProcedAlmacenado(cmd, "spEliminarProducto");
            if(filas==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}