using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class DepartamentoDat
    {
        // Instancia de la clase Persistence para la conexión a la base de datos
        Persistence objPer = new Persistence();

        // Método para obtener todos los departamentos
        public DataSet ShowDepartamentos()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            // Configuración del comando para seleccionar departamentos
            MySqlCommand objSelectCmd = new MySqlCommand
            {
                Connection = objPer.openConnection(),
                CommandText = "spSelectDepartamento", // Procedimiento almacenado para seleccionar departamentos
                CommandType = CommandType.StoredProcedure
            };
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData); // Llena el DataSet con los datos obtenidos
            objPer.closeConnection();
            return objData;
        }

        // Método para insertar un nuevo departamento
        public bool InsertDepartamento(string codigo, string nombre, int fkPaisId)
        {
            bool executed = false;
            int row;

            // Configuración del comando para insertar un nuevo departamento
            MySqlCommand objInsertCmd = new MySqlCommand
            {
                Connection = objPer.openConnection(),
                CommandText = "spInsertDepartamento", // Procedimiento almacenado para insertar departamento
                CommandType = CommandType.StoredProcedure
            };
            objInsertCmd.Parameters.Add("p_codigo", MySqlDbType.VarChar).Value = codigo;
            objInsertCmd.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;
            objInsertCmd.Parameters.Add("p_fkpais_id", MySqlDbType.Int32).Value = fkPaisId;

            try
            {
                row = objInsertCmd.ExecuteNonQuery(); // Ejecuta el comando
                executed = row == 1; // Verifica si se ejecutó correctamente
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para actualizar un departamento existente
        public bool UpdateDepartamento(int id, string codigo, string nombre, int paisId)
        {
            bool executed = false;
            int row;

            // Configuración del comando para actualizar un departamento
            MySqlCommand objUpdateCmd = new MySqlCommand
            {
                Connection = objPer.openConnection(),
                CommandText = "sp_actualizar_departamento", // Procedimiento almacenado para actualizar departamento
                CommandType = CommandType.StoredProcedure
            };
            objUpdateCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objUpdateCmd.Parameters.Add("p_codigo", MySqlDbType.VarChar).Value = codigo;
            objUpdateCmd.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;
            objUpdateCmd.Parameters.Add("p_pais_id", MySqlDbType.Int32).Value = paisId;

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

        // Método para eliminar un departamento
        public bool DeleteDepartamento(int id)
        {
            bool executed = false;
            int row;

            // Configuración del comando para eliminar un departamento
            MySqlCommand objDeleteCmd = new MySqlCommand
            {
                Connection = objPer.openConnection(),
                CommandText = "sp_eliminar_departamento", // Procedimiento almacenado para eliminar departamento
                CommandType = CommandType.StoredProcedure
            };
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

        // Método para obtener todos los departamentos para un DropDownList
        public DataSet GetDepartamentosDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            // Configuración del comando para seleccionar departamentos para DDL
            MySqlCommand objSelectCmd = new MySqlCommand
            {
                Connection = objPer.openConnection(),
                CommandText = "spSelectDepartamentoDDL", // Procedimiento almacenado para DDL de departamentos
                CommandType = CommandType.StoredProcedure
            };
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
    }
}
