using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class DataInventario
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todo el inventario
        public DataSet showInventario()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "sp_read_inventario";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un nuevo registro en el inventario
        public bool saveInventario(int _Cantidad, DateTime _Fecha, string _Observacion, int _ProdId, int _EmpId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "sp_create_inventario";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_cantidad", MySqlDbType.Int32).Value = _Cantidad;
            objSelectCmd.Parameters.Add("p_fecha", MySqlDbType.Date).Value = _Fecha;
            objSelectCmd.Parameters.Add("p_observacion", MySqlDbType.Text).Value = _Observacion;
            objSelectCmd.Parameters.Add("p_prod_id", MySqlDbType.Int32).Value = _ProdId;
            objSelectCmd.Parameters.Add("p_emp_id", MySqlDbType.Int32).Value = _EmpId;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
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

        // Método para actualizar un registro de inventario
        public bool updateInventario(int _InvId, int _Cantidad, DateTime _Fecha, string _Observacion, int _ProdId, int _EmpId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "sp_update_inventario";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_inv_id", MySqlDbType.Int32).Value = _InvId;
            objSelectCmd.Parameters.Add("p_cantidad", MySqlDbType.Int32).Value = _Cantidad;
            objSelectCmd.Parameters.Add("p_fecha", MySqlDbType.Date).Value = _Fecha;
            objSelectCmd.Parameters.Add("p_observacion", MySqlDbType.Text).Value = _Observacion;
            objSelectCmd.Parameters.Add("p_prod_id", MySqlDbType.Int32).Value = _ProdId;
            objSelectCmd.Parameters.Add("p_emp_id", MySqlDbType.Int32).Value = _EmpId;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
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

        // Método para eliminar un registro de inventario
        public bool deleteInventario(int _InvId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "sp_delete_inventario";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_inv_id", MySqlDbType.Int32).Value = _InvId;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
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

        // Método para obtener inventario con empleado y producto
        public DataSet getInventarioWithEmpleadoAndProducto()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "sp_get_inventario_with_empleado_and_producto";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para obtener productos con inventario y categoría
        public DataSet getProductosWithInventarioAndCategoria()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "sp_get_productos_with_inventario_and_categoria";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
    }
}
