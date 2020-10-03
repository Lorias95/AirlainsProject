using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


public class CRUDrrhh

    {
    Conectividad cnx = new Conectividad();

    public int InsertUpdateAsociado(RRHH recurso, String Codigo)

    {

        SqlCommand cmd = new SqlCommand("InsertarActualizarRRHH", cnx.conexion());

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@CategoriaID", recurso.CategoriaID);

        cmd.Parameters.AddWithValue("@Departamento", recurso.Departamento);

        cmd.Parameters.AddWithValue("@Nombre", recurso.Nombre);

        cmd.Parameters.AddWithValue("@Direccion", recurso.Direccion);

        cmd.Parameters.AddWithValue("@Telefono", recurso.Telefono);

        cmd.Parameters.AddWithValue("@Correo", recurso.Correo);

        cmd.Parameters.AddWithValue("@Clave", recurso.Clave);

        cmd.Parameters.AddWithValue("@Codigo", recurso.Codigo);

        //1=Agrega 2=Actualiza

        cmd.Parameters.AddWithValue("@Codigo", Codigo);

        cnx.AbrirConexion();

        int i = cmd.ExecuteNonQuery();

        cnx.CerrarConexion();

        return i;

    }







    public int DeleteAsociado(String CategoriaID)

    {

        SqlCommand cmd = new SqlCommand("EliminarRRHH", cnx.conexion());

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@CategoriaID", CategoriaID);

        cnx.AbrirConexion();

        int i = cmd.ExecuteNonQuery();

        cnx.CerrarConexion();

        return i;

    }

    public RRHH BuscarAsociado(String CategoriaID)
    {

        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("ConsultarRRHH", cnx.conexion());

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@CategoriaID", SqlDbType.NVarChar);

        cmd.Parameters["@CategoriaID"].Value = CategoriaID;

        cnx.AbrirConexion();

        SqlDataReader registro = cmd.ExecuteReader();

        RRHH recurso = new RRHH();

        if (registro.HasRows)
        {

            while (registro.Read())
            {

                recurso.CategoriaID = registro.GetString(0);

                recurso.Nombre = registro.GetString(1);

                recurso.Departamento = registro.GetString(2);

                recurso.Direccion = registro.GetString(3);

                recurso.Telefono = registro.GetString(4);

                recurso.Correo = registro.GetString(5);

                recurso.Clave = registro.GetString(6);

                recurso.Codigo = registro.GetString(6);

            }
        }

        else { recurso = null; }

        registro.Close();

        cnx.CerrarConexion();

        return recurso;

    }



    public RRHH ValidarAsociado(String CategoriaID,

                                        String Clave)
    {

        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("ValidarRRHH", cnx.conexion());

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@CategoriaID", CategoriaID);

        cmd.Parameters.AddWithValue("@Clave", Clave);

        cnx.AbrirConexion();

        SqlDataReader registro = cmd.ExecuteReader();

        RRHH recurso = new RRHH();

        if (registro.HasRows)
        {

            while (registro.Read())
            {

                recurso.CategoriaID = registro.GetString(0);

                recurso.Departamento = registro.GetString(1);

                recurso.Nombre = registro.GetString(2);

                recurso.Direccion = registro.GetString(3);

                recurso.Telefono = registro.GetString(4);

                recurso.Correo = registro.GetString(5);

                recurso.Clave = registro.GetString(6);

            }
        }

        else { recurso = null; }

        registro.Close();

        cnx.CerrarConexion();

        return recurso;

    }

    public List<RRHH> GetRecurso()
    {

        List<RRHH> recurso = new List<RRHH>();

        SqlCommand cmd = new SqlCommand("ListarRRHH", cnx.conexion());

        cnx.AbrirConexion();

        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter sd = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();

        sd.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {

            recurso.Add(new RRHH
            {

                CategoriaID = Convert.ToString(dr["CategoriaID"]),

                Departamento = Convert.ToString(dr["Departamento"]),

                Nombre = Convert.ToString(dr["Nombre"]),

                Direccion = Convert.ToString(dr["Direccion"]),

                Telefono = Convert.ToString(dr["Telefono"]),

                Correo = Convert.ToString(dr["Correo"]),

                Clave = Convert.ToString(dr["Clave"]),

                Codigo = Convert.ToString(dr["Codigo"])

            });

        }

        cnx.CerrarConexion();

        return recurso;

    }
}

