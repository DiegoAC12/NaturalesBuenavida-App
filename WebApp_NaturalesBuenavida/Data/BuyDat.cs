﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class BuyDat
    {
        Persistence objPer = new Persistence();

        //Metodo para mostrar todas las Compras y su respectivo detalle
        public DataSet showBuy()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectCompraYDetalle";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        /// <summary>
        /// Metodo para guardar una compra de un producto o materia prima nueva
        /// </summary>
        /// <param name="_fecha_compra">Fecha de la compra</param>
        /// <param name="_total">Total de la compra</param>
        /// <param name="_fkproducto_id">Id del producto a comprar. Foranea</param>
        /// <param name="_numero_factura">Número de factura de compra, dada por el proveedor</param>
        /// <param name="_cantidad">Cantidad del producto comprado</param>
        /// <param name="_precio_unitario">precio unitario de la compra</param>
        /// <returns></returns>
        public bool saveBuy(DateTime _fecha_compra, double _total, int _fkproducto_id, string _numero_factura, int _cantidad, double _precio_unitario)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertCategory"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_fecha_compra", MySqlDbType.DateTime).Value = _fecha_compra;
            objSelectCmd.Parameters.Add("p_total", MySqlDbType.Double).Value = _total;
            objSelectCmd.Parameters.Add("p_fkproducto_id", MySqlDbType.Int32).Value = _fkproducto_id;
            objSelectCmd.Parameters.Add("p_numero_factura", MySqlDbType.VarString).Value = _numero_factura;
            objSelectCmd.Parameters.Add("p_cantidad", MySqlDbType.Int32).Value = _cantidad;
            objSelectCmd.Parameters.Add("p_precio_unitario", MySqlDbType.Double).Value = _precio_unitario;

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

        /// <summary>
        /// Metodo para guardar una compra de un producto o materia prima nueva
        /// </summary>
        /// <param name="_compra_id">ID de la compra para su actualización</param>
        /// <param name="_fecha_compra">Fecha de la compra</param>
        /// <param name="_total">Total de la compra</param>
        /// <param name="_fkproducto_id">Id del producto a comprar. Foranea</param>
        /// <param name="_numero_factura">Número de factura de compra, dada por el proveedor</param>
        /// <param name="_cantidad">Cantidad del producto comprado</param>
        /// <param name="_precio_unitario">precio unitario de la compra</param>
        /// <returns></returns>
        public bool updateBuy(int _compra_id, DateTime _fecha_compra, double _total, string _numero_factura, int _fkproducto_id, int _cantidad, double _precio_unitario)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateCompra"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_compra_id", MySqlDbType.Int32).Value = _compra_id;
            objSelectCmd.Parameters.Add("p_fecha_compra", MySqlDbType.DateTime).Value = _fecha_compra;
            objSelectCmd.Parameters.Add("p_total", MySqlDbType.Double).Value = _total;
            objSelectCmd.Parameters.Add("p_numero_factura", MySqlDbType.VarString).Value = _numero_factura;
            objSelectCmd.Parameters.Add("p_fkproducto_id", MySqlDbType.Int32).Value = _fkproducto_id;
            objSelectCmd.Parameters.Add("p_cantidad", MySqlDbType.Int32).Value = _cantidad;
            objSelectCmd.Parameters.Add("p_precio_unitario", MySqlDbType.Double).Value = _precio_unitario;

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