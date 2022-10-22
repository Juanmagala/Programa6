using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TP6
{
    public class AccesoDatos
    {
        string rutaBDneptuno = "Data Source=localhost\\sqlexpress;Initial Catalog = Neptuno; Integrated Security = True";


        public SqlConnection obtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBDneptuno);

            try
            {
                cn.Open();
                return cn;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter obtenerAdaptador(string consulta)
        {
            SqlDataAdapter adaptador;

            try
            {
                adaptador = new SqlDataAdapter(consulta, obtenerConexion());
                return adaptador;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int EjecutarProcedAlmacenado(SqlCommand comando, string nombre)
        {
            int filasCambiadas;
            SqlConnection cn = obtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = comando;
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = nombre;
            filasCambiadas = cmd.ExecuteNonQuery();
            cn.Close();
            return filasCambiadas;
        }
    }
}