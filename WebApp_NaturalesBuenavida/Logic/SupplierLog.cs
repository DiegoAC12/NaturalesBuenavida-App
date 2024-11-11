using System.Data;
using Data;

namespace Logic
{
    public class SupplierLog
    {
        SupplierDat dataSupplier = new SupplierDat();

        // Lógica para insertar un proveedor
        public void InsertSupplier(int personaId)
        {
            dataSupplier.InsertSupplier(personaId);
        }

        // Lógica para obtener todos los proveedores
        public DataSet GetSupplier()
        {
            return dataSupplier.GetSupplier();
        }

        // Lógica para actualizar un proveedor
        public void UpdateSupplier(int provId, int personaId)
        {
            dataSupplier.UpdateSupplier(provId, personaId);
        }

        // Lógica para eliminar un proveedor
        public void DeleteSupplier(int provId)
        {
            dataSupplier.DeleteSupplier(provId);
        }

        // Lógica para obtener proveedores en formato DDL
        public DataSet GetSupplierDDL()
        {
            return dataSupplier.GetSupplierDDL();
        }
    }
}
