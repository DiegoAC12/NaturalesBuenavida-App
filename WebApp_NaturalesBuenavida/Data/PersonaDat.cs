using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class PersonaDat
    {
        // Instancia de la clase de persistencia para manejar la conexión a la base de datos
        Persistence objPer = new Persistence();

        // Método para mostrar todas las personas
        public DataSet ShowPersonas()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            // Configuración del comando para ejecutar el procedimiento almacenado de selección
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectPersona"; // Nombre del procedimiento para obtener personas
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Asigna el comando al adaptador y llena el dataset
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection(); // Cierra la conexión
            return objData;
        }

        // Método para insertar una nueva persona
        public bool InsertPersona(string identificacion, string nombreRazonSocial, string apellido, string telefono,
                                  string direccion, string correoElectronico, int fkDocId, int fkPaisId)
        {
            bool executed = false; // Indica si la operación fue exitosa
            int row;

            // Configuración del comando para insertar una nueva persona
            MySqlCommand objInsertCmd = new MySqlCommand();
            objInsertCmd.Connection = objPer.openConnection();
            objInsertCmd.CommandText = "spInsertPersona"; // Nombre del procedimiento para insertar
            objInsertCmd.CommandType = CommandType.StoredProcedure;

            // Agregar parámetros al comando
            objInsertCmd.Parameters.Add("p_identificacion", MySqlDbType.VarChar).Value = identificacion;
            objInsertCmd.Parameters.Add("p_nombre_razonsocial", MySqlDbType.VarChar).Value = nombreRazonSocial;
            objInsertCmd.Parameters.Add("p_apellido", MySqlDbType.VarChar).Value = apellido;
            objInsertCmd.Parameters.Add("p_telefono", MySqlDbType.VarChar).Value = telefono;
            objInsertCmd.Parameters.Add("p_direccion", MySqlDbType.VarChar).Value = direccion;
            objInsertCmd.Parameters.Add("p_correo_electronico", MySqlDbType.VarChar).Value = correoElectronico;
            objInsertCmd.Parameters.Add("p_fkdoc_id", MySqlDbType.Int32).Value = fkDocId;
            objInsertCmd.Parameters.Add("p_fkpais_id", MySqlDbType.Int32).Value = fkPaisId;

            try
            {
                row = objInsertCmd.ExecuteNonQuery(); // Ejecuta el comando
                executed = row == 1; // Verifica si se afectó una fila
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString()); // Manejo de errores
            }
            objPer.closeConnection(); // Cierra la conexión
            return executed;
        }

        // Método para actualizar una persona existente
        public bool UpdatePersona(int id, string identificacion, string nombreRazonSocial, string apellido,
                                  string telefono, string direccion, string correoElectronico, int docId, int paisId)
        {
            bool executed = false; // Indica si la operación fue exitosa
            int row;

            // Configuración del comando para actualizar una persona existente
            MySqlCommand objUpdateCmd = new MySqlCommand();
            objUpdateCmd.Connection = objPer.openConnection();
            objUpdateCmd.CommandText = "sp_actualizar_persona"; // Nombre del procedimiento para actualizar
            objUpdateCmd.CommandType = CommandType.StoredProcedure;

            // Agregar parámetros al comando
            objUpdateCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objUpdateCmd.Parameters.Add("p_identificacion", MySqlDbType.VarChar).Value = identificacion;
            objUpdateCmd.Parameters.Add("p_nombre_razonsocial", MySqlDbType.VarChar).Value = nombreRazonSocial;
            objUpdateCmd.Parameters.Add("p_apellido", MySqlDbType.VarChar).Value = apellido;
            objUpdateCmd.Parameters.Add("p_telefono", MySqlDbType.VarChar).Value = telefono;
            objUpdateCmd.Parameters.Add("p_direccion", MySqlDbType.VarChar).Value = direccion;
            objUpdateCmd.Parameters.Add("p_correo_electronico", MySqlDbType.VarChar).Value = correoElectronico;
            objUpdateCmd.Parameters.Add("p_doc_id", MySqlDbType.Int32).Value = docId;
            objUpdateCmd.Parameters.Add("p_pais_id", MySqlDbType.Int32).Value = paisId;

            try
            {
                row = objUpdateCmd.ExecuteNonQuery(); // Ejecuta el comando
                executed = row == 1; // Verifica si se afectó una fila
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString()); // Manejo de errores
            }
            objPer.closeConnection(); // Cierra la conexión
            return executed;
        }

        // Método para eliminar una persona
        public bool DeletePersona(int id)
        {
            bool executed = false; // Indica si la operación fue exitosa
            int row;

            // Configuración del comando para eliminar una persona
            MySqlCommand objDeleteCmd = new MySqlCommand();
            objDeleteCmd.Connection = objPer.openConnection();
            objDeleteCmd.CommandText = "sp_eliminar_persona"; // Nombre del procedimiento para eliminar
            objDeleteCmd.CommandType = CommandType.StoredProcedure;

            // Agregar parámetro al comando
            objDeleteCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;

            try
            {
                row = objDeleteCmd.ExecuteNonQuery(); // Ejecuta el comando
                executed = row == 1; // Verifica si se afectó una fila
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString()); // Manejo de errores
            }
            objPer.closeConnection(); // Cierra la conexión
            return executed;
        }

        // Método para obtener todas las personas (para un DropDownList)
        public DataSet GetPersonasDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            // Configuración del comando para obtener datos del DDL de personas
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectPersonaDDL"; // Procedimiento almacenado para DDL
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Asigna el comando al adaptador y llena el dataset
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection(); // Cierra la conexión
            return objData;
        }
    }
}
