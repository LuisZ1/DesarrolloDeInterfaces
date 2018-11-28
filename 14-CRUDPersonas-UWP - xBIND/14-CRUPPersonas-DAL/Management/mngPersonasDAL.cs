using _14_CRUPPersonas_DAL.connections;
using _14_CRUPPersonas_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUPPersonas_DAL.Management {
    public class mngPersonasDAL {

        public clsPersona getPersonaID_DAL(int id) {

            SqlConnection miConexion;
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsPersona persona = null; ;

            //Algoritmo
            miConexion = gestoraConexion.getConnection(); //No es necesario poner try/catch porque myConnection ya lo gestiona

            SqlParameter idpersonaSQL = new SqlParameter();
            idpersonaSQL.SqlDbType = System.Data.SqlDbType.Int;
            idpersonaSQL.ParameterName = "@id";
            idpersonaSQL.Value = id;
            miComando.Parameters.Add(idpersonaSQL);

            //Otra manera de declarar un parametro SQL, para intentar evitar SQL injection
            //miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;


            miComando.CommandText = "SELECT * FROM Personas WHERE IDPersona = @id";
            miComando.Connection = miConexion;

            miLector = miComando.ExecuteReader();

            if (miLector.HasRows) {
                miLector.Read();
                persona = new clsPersona();
                persona.idPersona = (int)miLector["idPersona"];
                persona.nombre = (String)miLector["nombrePersona"];
                persona.apellidos = (String)miLector["apellidosPersona"];
                persona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                persona.telefono = (String)miLector["telefono"];
                persona.direccion = (String)miLector["direccion"];
                persona.idDepartamento = (int)miLector["idDepartamento"];
            }

            //Cerrar conexion
            gestoraConexion.closeConnection(ref miConexion);
            miLector.Close();

            return persona;

        }

        /// <summary>
        /// elimina la persona cuyo id corresponda al recibido
        /// conectandose a la bbdd. Si no borra nada devuelve -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns>numero de filas borradas</returns>
        public int dropPersonaID_DAL(int id) {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();
            clsPersona persona = null;
            int numberOfDeletes = -1;

            //Algoritmo
            miConexion = gestoraConexion.getConnection(); //No es necesario poner try/catch porque myConnection ya lo gestiona

            SqlParameter idpersonaSQL = new SqlParameter();
            idpersonaSQL.SqlDbType = System.Data.SqlDbType.Int;
            idpersonaSQL.ParameterName = "@id";
            idpersonaSQL.Value = id;
            miComando.Parameters.Add(idpersonaSQL);

            //Otra manera de declarar un parametro SQL, para intentar evitar SQL injection
            //miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            miComando.CommandText = "DELETE FROM Personas WHERE IDPersona = @id";
            miComando.Connection = miConexion;

            numberOfDeletes = miComando.ExecuteNonQuery();

            //Cerrar conexion
            gestoraConexion.closeConnection(ref miConexion);

            return numberOfDeletes;
        }

        public int insertPersona_DAL(clsPersona personaAInsertar) {
            int numberOfRows = -1;

            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();

            //Algoritmo
            miConexion = gestoraConexion.getConnection(); //No es necesario poner try/catch porque myConnection ya lo gestiona

            //Otra manera de declarar un parametro SQL, para intentar evitar SQL injection
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = personaAInsertar.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = personaAInsertar.apellidos;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = personaAInsertar.fechaNacimiento;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = personaAInsertar.telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = personaAInsertar.direccion;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = personaAInsertar.idDepartamento;

            miComando.CommandText = "INSERT INTO [Personas] VALUES (@nombre, @apellidos, @fechaNacimiento, @telefono, @direccion, @idDepartamento)";
            miComando.Connection = miConexion;

            numberOfRows = miComando.ExecuteNonQuery();

            //Cerrar conexion
            gestoraConexion.closeConnection(ref miConexion);

            return numberOfRows;
        }

        public int alterPersona_DAL(clsPersona personaAModificar) {
            int numberOfRows = -1;

            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestoraConexion = new clsMyConnection();

            //Algoritmo
            miConexion = gestoraConexion.getConnection(); //No es necesario poner try/catch porque myConnection ya lo gestiona

            //Otra manera de declarar un parametro SQL, para intentar evitar SQL injection
            miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = personaAModificar.idPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = personaAModificar.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = personaAModificar.apellidos;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = personaAModificar.fechaNacimiento;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = personaAModificar.telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = personaAModificar.direccion;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = personaAModificar.idDepartamento;

            // miComando.CommandText = "INSERT INTO [Personas] VALUES (@nombre, @apellidos, @fechaNacimiento, @telefono, @direccion, @idDepartamento)";
            miComando.CommandText = "UPDATE[dbo].[Personas] SET[nombrePersona] = @nombre ,[apellidosPersona] = @apellidos ,[fechaNacimiento] = @fechaNacimiento ,[telefono] = @telefono ,[direccion] = @direccion ,[IDDepartamento] = @idDepartamento  WHERE IDPersona =@idPersona";
            //TODO ALTER
            miComando.Connection = miConexion;

            numberOfRows = miComando.ExecuteNonQuery();

            //Cerrar conexion
            gestoraConexion.closeConnection(ref miConexion);

            return numberOfRows;
        }

    }
}
