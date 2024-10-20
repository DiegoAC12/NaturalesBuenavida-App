using System;
using System.Data;
using Data; // Referencia a la capa de datos

namespace Logic
{
    public class LogicInventario
    {
        DataInventario objDataInventario = new DataInventario();

        // Método para obtener todo el inventario
        public DataSet GetInventario()
        {
            try
            {
                return objDataInventario.showInventario();
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al obtener inventario: " + ex.Message);
            }
        }

        // Método para agregar un nuevo registro en el inventario
        public bool AddInventario(int cantidad, DateTime fecha, string observacion, int prodId, int empId)
        {
            // Validación de reglas de negocio
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            }

            if (prodId <= 0 || empId <= 0)
            {
                throw new ArgumentException("El ID de producto o empleado no es válido.");
            }

            try
            {
                return objDataInventario.saveInventario(cantidad, fecha, observacion, prodId, empId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al agregar inventario: " + ex.Message);
            }
        }

        // Método para actualizar un registro de inventario
        public bool UpdateInventario(int invId, int cantidad, DateTime fecha, string observacion, int prodId, int empId)
        {
            // Validación de reglas de negocio
            if (invId <= 0)
            {
                throw new ArgumentException("El ID de inventario no es válido.");
            }

            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            }

            if (prodId <= 0 || empId <= 0)
            {
                throw new ArgumentException("El ID de producto o empleado no es válido.");
            }

            try
            {
                return objDataInventario.updateInventario(invId, cantidad, fecha, observacion, prodId, empId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al actualizar inventario: " + ex.Message);
            }
        }

        // Método para eliminar un registro de inventario
        public bool DeleteInventario(int invId)
        {
            if (invId <= 0)
            {
                throw new ArgumentException("El ID de inventario no es válido.");
            }

            try
            {
                return objDataInventario.deleteInventario(invId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al eliminar inventario: " + ex.Message);
            }
        }

        // Método para obtener inventario con empleado y producto
        public DataSet GetInventarioWithEmpleadoAndProducto()
        {
            try
            {
                return objDataInventario.getInventarioWithEmpleadoAndProducto();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener inventario con empleado y producto: " + ex.Message);
            }
        }

        // Método para obtener productos con inventario y categoría
        public DataSet GetProductosWithInventarioAndCategoria()
        {
            try
            {
                return objDataInventario.getProductosWithInventarioAndCategoria();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos con inventario y categoría: " + ex.Message);
            }
        }
    }
}
