using System.Data;
using Data;

namespace Logic
{
    public class CategoryLog
    {
        DataCategory dataCategory = new DataCategory();

        // Lógica para obtener todas las categorías
        public DataSet GetCategories()
        {
            return dataCategory.ShowCategories();
        }

        // Lógica para crear una nueva categoría
        public bool AddCategory(string descripcion)
        {
            return dataCategory.CreateCategory(descripcion);
        }

        // Lógica para actualizar una categoría
        public bool EditCategory(int catId, string descripcion)
        {
            return dataCategory.UpdateCategory(catId, descripcion);
        }

        // Lógica para eliminar una categoría
        public bool RemoveCategory(int catId)
        {
            return dataCategory.DeleteCategory(catId);
        }

        // Lógica para obtener las categorías en formato DDL
        public DataSet GetCategoriesDDL()
        {
            return dataCategory.ShowCategoriesDDL();
        }
    }
}
