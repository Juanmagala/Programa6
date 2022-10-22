using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        public void cargarGridView()
        {
            GestionProductos gProductos = new GestionProductos();
            grdProductos.DataSource = gProductos.ObtenerTodosLosProductos(1);
            grdProductos.DataBind();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarGridView();
            }
        }

        protected void grdProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string s_IdProducto = ((Label)grdProductos.Rows[e.RowIndex].FindControl("lbl_it_IdProducto")).Text;

            Producto prod = new Producto();
            prod.IdProducto = Convert.ToInt32(s_IdProducto);

            GestionProductos gProductos = new GestionProductos();
            gProductos.EliminarProducto(prod);

            cargarGridView();
        }

        protected void grdProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProductos.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void grdProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            lblError.Visible = false;
            grdProductos.EditIndex = -1;
            cargarGridView();
        }

        protected void grdProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                lblError.Visible = false;
                string s_IdProducto = ((Label)grdProductos.Rows[e.RowIndex].FindControl("lbl_it_IdProducto")).Text;
                string s_NombreProducto = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtEditarNombre")).Text;
                string s_CantidadporUnidad = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtEditarCantidad")).Text;
                string s_PrecioUnidad = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtEditarPrecio")).Text;

                if(s_NombreProducto.Trim()=="" || s_CantidadporUnidad.Trim()=="" || s_PrecioUnidad.Trim()=="")
                {
                    lblError.Text = "DEBE LLENAR TODOS LOS CAMPOS";
                    lblError.Visible = true;
                }
                else
                {
                    Producto prod = new Producto();
                    prod.IdProducto = Convert.ToInt32(s_IdProducto);
                    prod.NombreProducto = s_NombreProducto;
                    prod.CantidadPorUnidad = s_CantidadporUnidad;
                    prod.PrecioUnidad = Convert.ToDecimal(s_PrecioUnidad);

                    GestionProductos gProducto = new GestionProductos();
                    gProducto.ActualizarProducto(prod);

                    grdProductos.EditIndex = -1;
                    cargarGridView();
                }
            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "EL PRECIO DEBE SER UN NUMERO";
            }
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            cargarGridView();
        }
    }
}