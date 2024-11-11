using System.Data;
using Data;

namespace Logic
{
    public class SupplierLog
    {
        SupplierDat dataSupplier = new SupplierDat();

        // L�gica para insertar un proveedor
        public void InsertSupplier(int personaId)
        {
            dataSupplier.InsertSupplier(personaId);
        }

        // L�gica para obtener todos los proveedores
        public DataSet GetSupplier()
        {
            return dataSupplier.GetSupplier();
        }

        // L�gica para actualizar un proveedor
        public void UpdateSupplier(int provId, int personaId)
        {
            dataSupplier.UpdateSupplier(provId, personaId);
        }

        // L�gica para eliminar un proveedor
        public void DeleteSupplier(int provId)
        {
            dataSupplier.DeleteSupplier(provId);
        }

        // L�gica para obtener proveedores en formato DDL
        public DataSet GetSupplierDDL()
        {
            return dataSupplier.GetSupplierDDL();
        }
    }
}
