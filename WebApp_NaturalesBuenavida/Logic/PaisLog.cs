using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class PaisDat
    {
        // Instancia de la clase Persistence para manejar la conexión con la base de datos
        Persistence objPer = new Persistence();

        // Método para obtener todos los países desde la base de datos
        public DataSet ShowPais()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            // Configura el comando para ejecutar el procedimiento almacenado que selecciona todos los países
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectPais";
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para insertar un nuevo país en la base de datos
        public bool InsertPais(string codigo, string nombre)
        {
            bool executed = false;
            int row;

            // Configura el comando para el procedimiento almacenado que inserta un país
            MySqlCommand objInsertCmd = new MySqlCommand();
            objInsertCmd.Connection = objPer.openConnection();
            objInsertCmd.CommandText = "spCreatePais";
            objInsertCmd.CommandType = CommandType.StoredProcedure;

            // Parámetros para el código y nombre del país
            objInsertCmd.Parameters.Add("p_codigo", MySqlDbType.VarChar).Value = codigo;
            objInsertCmd.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;

            try
            {
                row = objInsertCmd.ExecuteNonQuery();
                executed = row == 1; // Se ejecuta correctamente si se afecta una fila
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para actualizar un país existente en la base de datos
        public bool UpdatePais(int id, string codigo, string nombre)
        {
            bool executed = false;
            int row;

            // Configura el comando para el procedimiento almacenado que actualiza un país
            MySqlCommand objUpdateCmd = new MySqlCommand();
            objUpdateCmd.Connection = objPer.openConnection();
            objUpdateCmd.CommandText = "spUpdatepais";
            objUpdateCmd.CommandType = CommandType.StoredProcedure;

            // Parámetros para el ID, código y nombre del país
            objUpdateCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objUpdateCmd.Parameters.Add("p_codigo", MySqlDbType.VarChar).Value = codigo;
            objUpdateCmd.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;

            try
            {
                row = objUpdateCmd.ExecuteNonQuery();
                executed = row == 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para eliminar un país en la base de datos
        public bool DeletePais(int id)
        {
            bool executed = false;
            int row;

            // Configura el comando para el procedimiento almacenado que elimina un país
            MySqlCommand objDeleteCmd = new MySqlCommand();
            objDeleteCmd.Connection = objPer.openConnection();
            objDeleteCmd.CommandText = "spDeletepais";
            objDeleteCmd.CommandType = CommandType.StoredProcedure;

            // Parámetro para el ID del país a eliminar
            objDeleteCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;

            try
            {
                row = objDeleteCmd.ExecuteNonQuery();
                executed = row == 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para obtener un conjunto de datos de países para usar en un DropDownList
        public DataSet ShowPaisDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            // Configura el comando para el procedimiento almacenado que selecciona los países para un DropDownList
            MySqlCommand objSelectDDL = new MySqlCommand();
            objSelectDDL.Connection = objPer.openConnection();
            objSelectDDL.CommandText = "spSelectPaisDDL";
            objSelectDDL.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectDDL;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
    }
}
