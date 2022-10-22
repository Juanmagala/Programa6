using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TP6
{
    public partial class Ejercicio2_2 : System.Web.UI.Page
    {
        public void cargarGridView()
        {
            GestionProductos gProductos = new GestionProductos();
            grdProductos.DataSource = gProductos.ObtenerTodosLosProductos(2);
            grdProductos.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGridView();
            }
        }

        protected void grdProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string s_IdProducto = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_IdProducto")).Text;
            string s_NombreProducto = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_NombreProducto")).Text;
            string s_IdProveedor = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_IdProveedor")).Text;
            string s_PrecioUnidad = ((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_PrecioUnidad")).Text;

            lblSeleccionado.Text = "Producto seleccionado: " + s_NombreProducto;

            if(Session["Grilla"]==null)
            {
                Session["Grilla"] = CrearTabla();
            }
            
            NuevoProducto((DataTable)Session["Grilla"], s_IdProducto, s_NombreProducto, s_IdProveedor, s_PrecioUnidad);
        }

        public DataTable CrearTabla()
        {
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("Id Producto", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Nombre Producto", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Id proveedor", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Precio unitario", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }

        public void NuevoProducto(DataTable tabla, string idprod, string nombre, string idprov, string precio)
        {
            foreach (DataRow dr1 in tabla.Rows)
            {
                if(dr1["Id Producto"].ToString()==idprod)
                {
                    lblSeleccionado.Text = "ESE ELEMENTO YA FUE SELECCIONADO";
                    return;
                }
            }

            DataRow dr = tabla.NewRow();
            dr["Id Producto"] = idprod;
            dr["Nombre Producto"] = nombre;
            dr["Id Proveedor"] = idprov;
            dr["Precio Unitario"] = precio;
            tabla.Rows.Add(dr);
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            cargarGridView();
        }
    }
}