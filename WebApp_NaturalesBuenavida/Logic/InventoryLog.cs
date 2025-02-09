using Data;
using Newtonsoft.Json;
using System;
using System.Data;

namespace Logic
{
    public class InventoryLog
    {
        private InventoryDat objInv = new InventoryDat();

        // Método para obtener todos los inventarios
        public DataSet ShowInventory()
        {
            return objInv.ShowInventory();
        }

        // Método para obtener un resumen de inventarios
        public DataSet ShowInventorySummary()
        {
            return objInv.ShowInventorySummary();
        }

        // Método para obtener los detalles de un inventario específico
        public DataSet ShowInventoryDetails(int inventoryId)
        {
            return objInv.ShowInventoryDetails(inventoryId);
        }

        // Método para guardar un inventario con los productos de la lista temporal
        public bool SaveInventory(DateTime fecha, string observacion, int empleadoId, string productosJson)
        {
            return objInv.InsertInventory(fecha, observacion, empleadoId, productosJson);
        }

        // Método para eliminar un inventario
        public bool DeleteInventory(int invId)
        {
            return objInv.DeleteInventory(invId);
        }
    }
}
