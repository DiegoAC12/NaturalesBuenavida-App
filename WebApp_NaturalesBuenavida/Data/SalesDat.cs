using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class SalesDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar las ventas desde la base de datos.
        public DataSet ShowSales()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();

            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectVentas"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();

            return objData;
        }
        // Método para mostrar las ventas desde el procedimiento DDL
        public DataSet ShowDDLSales()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();

            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDDL_mostrar_ventas"; // nombre del procedimiento almacenado DDL
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();

            return objData;
        }

        // Método para guardar una nueva venta

        public bool SaveSale(string descripcion, int clienteId, int empleadoId, int productoId, int cantidad)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertVenta"; // Nombre actualizado del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan los parámetros necesarios para la venta
            objSelectCmd.Parameters.Add("p_cliente_id", MySqlDbType.Int32).Value = clienteId;
            objSelectCmd.Parameters.Add("p_empleado_id", MySqlDbType.Int32).Value = empleadoId;
            objSelectCmd.Parameters.Add("p_descripcion", MySqlDbType.Text).Value = descripcion;
            objSelectCmd.Parameters.Add("p_producto_id", MySqlDbType.Int32).Value = productoId;
            objSelectCmd.Parameters.Add("p_cantidad", MySqlDbType.Int32).Value = cantidad;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row > 0) // Cambié de `== 1` a `> 0` por seguridad en caso de múltiples filas afectadas
                {
                    executed = true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                objPer.closeConnection();
            }

            return executed;
        }

        //public bool SaveSale(DateTime fecha, double total, string descripcion, int clienteId, int empleadoId)
        //{
        //    bool executed = false;
        //    int row;

        //    MySqlCommand objSelectCmd = new MySqlCommand();
        //    objSelectCmd.Connection = objPer.openConnection();
        //    objSelectCmd.CommandText = "sp_insertar_venta"; // nombre del procedimiento almacenado
        //    objSelectCmd.CommandType = CommandType.StoredProcedure;

        //    // Se agregan parámetros al comando para pasar los valores de la venta.
        //    objSelectCmd.Parameters.Add("p_vent_fecha", MySqlDbType.Date).Value = fecha;
        //    objSelectCmd.Parameters.Add("p_vent_total", MySqlDbType.Double).Value = total;
        //    objSelectCmd.Parameters.Add("p_vent_descripcion", MySqlDbType.Text).Value = descripcion;
        //    objSelectCmd.Parameters.Add("p_cli_id", MySqlDbType.Int32).Value = clienteId;
        //    objSelectCmd.Parameters.Add("p_emp_id", MySqlDbType.Int32).Value = empleadoId;

        //    try
        //    {
        //        row = objSelectCmd.ExecuteNonQuery();
        //        if (row == 1)
        //        {
        //            executed = true;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error " + e.ToString());
        //    }
        //    objPer.closeConnection();
        //    return executed;
        //}

        // Método para actualizar una venta
        public bool UpdateSale(int ventaId, string descripcion, int clienteId, int empleadoId, int productoId, int cantidad)
        {
            bool executed = false;
            int row;

            MySqlCommand objUpdateCmd = new MySqlCommand();
            objUpdateCmd.Connection = objPer.openConnection();
            objUpdateCmd.CommandText = "sp_actualizar_venta"; // Procedimiento almacenado de actualización
            objUpdateCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan los parámetros necesarios para actualizar la venta
            objUpdateCmd.Parameters.Add("p_venta_id", MySqlDbType.Int32).Value = ventaId;
            objUpdateCmd.Parameters.Add("p_cliente_id", MySqlDbType.Int32).Value = clienteId;
            objUpdateCmd.Parameters.Add("p_empleado_id", MySqlDbType.Int32).Value = empleadoId;
            objUpdateCmd.Parameters.Add("p_descripcion", MySqlDbType.Text).Value = descripcion;
            objUpdateCmd.Parameters.Add("p_producto_id", MySqlDbType.Int32).Value = productoId;
            objUpdateCmd.Parameters.Add("p_cantidad", MySqlDbType.Int32).Value = cantidad;

            try
            {
                row = objUpdateCmd.ExecuteNonQuery();
                if (row > 0)
                {
                    executed = true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                objPer.closeConnection();
            }

            return executed;
        }

        // Método para eliminar una venta
        public bool DeleteSale(int ventId)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "sp_eliminar_venta"; // nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agrega parámetro al comando para pasar el ID de la venta.
            objSelectCmd.Parameters.Add("p_venta_id", MySqlDbType.Int32).Value = ventId;

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
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}