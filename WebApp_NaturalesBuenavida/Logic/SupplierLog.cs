using System;
using System.Data;
using Data; // Referencia a la capa de datos

namespace Logica
{
    public class LogicaSupplier
    {
        DataSupplier objDataSupplier = new DataSupplier();

        // Método para obtener todos los proveedores
        public DataSet GetSuppliers()
        {
            try
            {
                return objDataSupplier.showSuppliers();
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al obtener proveedores: " + ex.Message);
            }
        }

        // Método para agregar un nuevo proveedor
        public bool AddSupplier(int personaId)
        {
            // Validación de reglas de negocio
            if (personaId <= 0)
            {
                throw new ArgumentException("El ID de persona no es válido.");
            }

            try
            {
                return objDataSupplier.saveSupplier(personaId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al agregar proveedor: " + ex.Message);
            }
        }

        // Método para actualizar un proveedor
        public bool UpdateSupplier(int provId, int personaId)
        {
            // Validación de reglas de negocio
            if (provId <= 0)
            {
                throw new ArgumentException("El ID de proveedor no es válido.");
            }

            if (personaId <= 0)
            {
                throw new ArgumentException("El ID de persona no es válido.");
            }

            try
            {
                return objDataSupplier.updateSupplier(provId, personaId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al actualizar proveedor: " + ex.Message);
            }
        }

        // Método para eliminar un proveedor
        public bool DeleteSupplier(int provId)
        {
            // Validación de reglas de negocio
            if (provId <= 0)
            {
                throw new ArgumentException("El ID de proveedor no es válido.");
            }

            try
            {
                return objDataSupplier.deleteSupplier(provId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al eliminar proveedor: " + ex.Message);
            }
        }
    }
}
