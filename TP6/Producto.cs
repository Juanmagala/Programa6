using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6
{
    public class Producto
    {
        private int i_IdProducto;
        private string n_NombreProducto;
        private string c_CantidadPorUnidad;
        private decimal p_PrecioUnidad;

        public Producto()
        {

        }

        public Producto(int i_IdProducto, string n_NombreProducto, string c_CantidadPorUnidad, decimal p_PrecioUnidad)
        {
            this.i_IdProducto = i_IdProducto;
            this.n_NombreProducto = n_NombreProducto;
            this.c_CantidadPorUnidad = c_CantidadPorUnidad;
            this.p_PrecioUnidad = p_PrecioUnidad;
        }

        public int IdProducto
        {
            get { return i_IdProducto; }
            set { i_IdProducto = value; }
        }

        public string NombreProducto
        {
            get { return n_NombreProducto; }
            set { n_NombreProducto = value; }
        }

        public string CantidadPorUnidad
        {
            get { return c_CantidadPorUnidad; }
            set { c_CantidadPorUnidad = value; }
        }

        public decimal PrecioUnidad
        {
            get { return p_PrecioUnidad; }
            set { p_PrecioUnidad = value; }
        }
    }
}