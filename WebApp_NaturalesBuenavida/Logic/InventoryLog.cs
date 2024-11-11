using System;
using System.Data;
using Data;

namespace Logic
{
    public class InventoryLog
    {
        InventoryDat dataInventory = new InventoryDat();

        // L�gica para mostrar todos los registros de inventario
        public DataSet GetInventory()
        {
            return dataInventory.ShowInventory();
        }

        // L�gica para insertar un nuevo registro de inventario
        public bool AddInventory(int cantidad, DateTime fecha, string observacion, int fkProductoId, int fkEmpleadoId)
        {
            return dataInventory.InsertInventory(cantidad, fecha, observacion, fkProductoId, fkEmpleadoId);
        }

        // L�gica para actualizar un registro de inventario
        public bool EditInventory(int invId, int cantidad, DateTime fecha, string observacion, int fkProducto, int fkEmpleado)
        {
            return dataInventory.UpdateInventory(invId, cantidad, fecha, observacion, fkProducto, fkEmpleado);
        }

        // L�gica para eliminar un registro de inventario
        public bool RemoveInventory(int invId)
        {
            return dataInventory.DeleteInventory(invId);
        }

        // L�gica para mostrar el inventario en formato DDL
        public DataSet GetInventoryDDL()
        {
            return dataInventory.ShowInventoryDDL();
        }
    }
}
