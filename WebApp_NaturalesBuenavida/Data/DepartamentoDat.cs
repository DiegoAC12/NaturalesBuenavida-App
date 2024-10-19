using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class DataDepartamento
    {
        Persistence objPer = new Persistence();

        // Método para insertar un nuevo departamento
        public bool insertarDepartamento(string codigo, string nombre, int paisId)
        {
            bool executed = false;
            int row;

            MySqlCommand objInsertCmd = new MySqlCommand();
            objInsertCmd.Connection = objPer.openConnection();
            objInsertCmd.CommandText = "sp_insertar_departamento";
            objInsertCmd.CommandType = CommandType.StoredProcedure;
            objInsertCmd.Parameters.Add("p_codigo", MySqlDbType.VarChar).Value = codigo;
            objInsertCmd.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;
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

        // Método para mostrar un departamento por ID
        public DataSet mostrarDepartamento(int id)
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "sp_mostrar_departamento";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para actualizar un departamento
        public bool actualizarDepartamento(int id, string codigo, string nombre, int paisId)
        {
            bool executed = false;
            int row;

            MySqlCommand objUpdateCmd = new MySqlCommand();
            objUpdateCmd.Connection = objPer.openConnection();
            objUpdateCmd.CommandText = "sp_actualizar_departamento";
            objUpdateCmd.CommandType = CommandType.StoredProcedure;
            objUpdateCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objUpdateCmd.Parameters.Add("p_codigo", MySqlDbType.VarChar).Value = codigo;
            objUpdateCmd.Parameters.Add("p_nombre", MySqlDbType.VarChar).Value = nombre;
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

        // Método para eliminar un departamento
        public bool eliminarDepartamento(int id)
        {
            bool executed = false;
            int row;

            MySqlCommand objDeleteCmd = new MySqlCommand();
            objDeleteCmd.Connection = objPer.openConnection();
            objDeleteCmd.CommandText = "sp_eliminar_departamento";
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
