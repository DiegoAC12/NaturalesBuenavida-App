using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class DataPersona
    {
        Persistence objPer = new Persistence();

        // Método para insertar una nueva persona
        public bool insertarPersona(string identificacion, string nombreRazonsocial, string apellido,
            string telefono, string direccion, string correoElectronico, int docId, int paisId)
        {
            bool executed = false;
            int row;

            MySqlCommand objInsertCmd = new MySqlCommand();
            objInsertCmd.Connection = objPer.openConnection();
            objInsertCmd.CommandText = "sp_insertar_persona";
            objInsertCmd.CommandType = CommandType.StoredProcedure;
            objInsertCmd.Parameters.Add("p_identificacion", MySqlDbType.VarChar).Value = identificacion;
            objInsertCmd.Parameters.Add("p_nombre_razonsocial", MySqlDbType.VarChar).Value = nombreRazonsocial;
            objInsertCmd.Parameters.Add("p_apellido", MySqlDbType.VarChar).Value = apellido;
            objInsertCmd.Parameters.Add("p_telefono", MySqlDbType.VarChar).Value = telefono;
            objInsertCmd.Parameters.Add("p_direccion", MySqlDbType.VarChar).Value = direccion;
            objInsertCmd.Parameters.Add("p_correo_electronico", MySqlDbType.VarChar).Value = correoElectronico;
            objInsertCmd.Parameters.Add("p_doc_id", MySqlDbType.Int32).Value = docId;
            objInsertCmd.Parameters.Add("p_pais_id", MySqlDbType.Int32).Value = paisId;

            try
            {
                row = objInsertCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para mostrar una persona por ID
        public DataSet mostrarPersona(int id)
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "sp_mostrar_persona"; // Cambiar este nombre si el procedimiento se llama diferente
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para actualizar una persona
        public bool actualizarPersona(int id, string identificacion, string nombreRazonsocial, string apellido,
            string telefono, string direccion, string correoElectronico, int docId, int paisId)
        {
            bool executed = false;
            int row;

            MySqlCommand objUpdateCmd = new MySqlCommand();
            objUpdateCmd.Connection = objPer.openConnection();
            objUpdateCmd.CommandText = "sp_actualizar_persona";
            objUpdateCmd.CommandType = CommandType.StoredProcedure;
            objUpdateCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objUpdateCmd.Parameters.Add("p_identificacion", MySqlDbType.VarChar).Value = identificacion;
            objUpdateCmd.Parameters.Add("p_nombre_razonsocial", MySqlDbType.VarChar).Value = nombreRazonsocial;
            objUpdateCmd.Parameters.Add("p_apellido", MySqlDbType.VarChar).Value = apellido;
            objUpdateCmd.Parameters.Add("p_telefono", MySqlDbType.VarChar).Value = telefono;
            objUpdateCmd.Parameters.Add("p_direccion", MySqlDbType.VarChar).Value = direccion;
            objUpdateCmd.Parameters.Add("p_correo_electronico", MySqlDbType.VarChar).Value = correoElectronico;
            objUpdateCmd.Parameters.Add("p_doc_id", MySqlDbType.Int32).Value = docId;
            objUpdateCmd.Parameters.Add("p_pais_id", MySqlDbType.Int32).Value = paisId;

            try
            {
                row = objUpdateCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para eliminar una persona
        public bool eliminarPersona(int id)
        {
            bool executed = false;
            int row;

            MySqlCommand objDeleteCmd = new MySqlCommand();
            objDeleteCmd.Connection = objPer.openConnection();
            objDeleteCmd.CommandText = "sp_eliminar_persona";
            objDeleteCmd.CommandType = CommandType.StoredProcedure;
            objDeleteCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;

            try
            {
                row = objDeleteCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}
