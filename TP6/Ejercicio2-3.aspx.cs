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
    public partial class Ejercicio2_3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Grilla"]!=null)
            {
                grdProductos.DataSource=(DataTable)Session["Grilla"];
                grdProductos.DataBind();
            }
        }
    }
}