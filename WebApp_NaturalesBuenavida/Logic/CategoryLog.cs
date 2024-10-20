using System;
using System.Data;
using Data; // Referencia a la capa de datos

namespace Logic
{
    public class LogicCategory
    {
        DataCategory objDataCategory = new DataCategory();

        // Método para obtener todas las categorías
        public DataSet GetCategories()
        {
            try
            {
                return objDataCategory.showCategories();
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al obtener categorías: " + ex.Message);
            }
        }

        // Método para guardar una nueva categoría
        public bool AddCategory(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");
            }

            try
            {
                return objDataCategory.saveCategory(descripcion);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al agregar categoría: " + ex.Message);
            }
        }

        // Método para actualizar una categoría
        public bool UpdateCategory(int catId, string descripcion)
        {
            if (catId <= 0)
            {
                throw new ArgumentException("El ID de la categoría no es válido.");
            }

            if (string.IsNullOrEmpty(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");
            }

            try
            {
                return objDataCategory.updateCategory(catId, descripcion);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al actualizar categoría: " + ex.Message);
            }
        }

        // Método para eliminar una categoría
        public bool DeleteCategory(int catId)
        {
            if (catId <= 0)
            {
                throw new ArgumentException("El ID de la categoría no es válido.");
            }

            try
            {
                return objDataCategory.deleteCategory(catId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al eliminar categoría: " + ex.Message);
            }
        }

        // Método para obtener productos con su categoría y proveedor
        public DataSet GetProductsWithCategoryAndSupplier()
        {
            try
            {
                return objDataCategory.getProductsWithCategoryAndSupplier();
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al obtener productos con categorías y proveedores: " + ex.Message);
            }
        }
    }
}
