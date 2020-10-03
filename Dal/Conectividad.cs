using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


class Conectividad
    {
    SqlConnection conn = new SqlConnection();
    public SqlConnection conexion()
    {
        try
        {
            conn.ConnectionString =
                ConfigurationManager.ConnectionStrings[
                    "dbConn"].ToString();

        }
        catch (Exception ex)
        {
            conn.ConnectionString =
                "Data Source=DESKTOP-1CH3FMA-SQLEXPRESS;" + "Initial Catalogo=ProyectoAeropuerto;" +
                "Integrated Segurity=true";

        }
        return conn;
    }
    public void CerrarConexion()
    {
        if (conn.State.Equals(ConnectionState.Open))
            conn.Close();
    }
    public void AbrirConexion()
    {
        if (conn.State.Equals(ConnectionState.Closed))
            conn.Open();
    }
}

