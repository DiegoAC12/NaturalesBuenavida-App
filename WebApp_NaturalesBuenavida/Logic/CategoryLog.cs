using System.Data;
using Data;

namespace Logic
{
    public class CategoryLog
    {
        DataCategory dataCategory = new DataCategory();

        // L�gica para obtener todas las categor�as
        public DataSet GetCategories()
        {
            return dataCategory.ShowCategories();
        }

        // L�gica para crear una nueva categor�a
        public bool AddCategory(string descripcion)
        {
            return dataCategory.CreateCategory(descripcion);
        }

        // L�gica para actualizar una categor�a
        public bool EditCategory(int catId, string descripcion)
        {
            return dataCategory.UpdateCategory(catId, descripcion);
        }

        // L�gica para eliminar una categor�a
        public bool RemoveCategory(int catId)
        {
            return dataCategory.DeleteCategory(catId);
        }

        // L�gica para obtener las categor�as en formato DDL
        public DataSet GetCategoriesDDL()
        {
            return dataCategory.ShowCategoriesDDL();
        }
    }
}
