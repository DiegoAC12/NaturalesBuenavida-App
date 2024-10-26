using System.Data;
using Data;

namespace Logic
{
    public class DepartamentoLog
    {
        // Instancia de la clase DepartamentoDat para manejar la interacción con la base de datos
        DepartamentoDat DepartamentoDat = new DepartamentoDat();

        // Lógica para obtener todos los departamentos
        public DataSet GetDepartamentos()
        {
            // Llama al método en la capa de datos para obtener todos los departamentos
            return DepartamentoDat.ShowDepartamentos();
        }

        // Lógica para insertar un nuevo departamento
        public bool AddDepartamento(string codigo, string nombre, int fkPaisId)
        {
            // Llama al método en la capa de datos para insertar un nuevo departamento con los parámetros proporcionados
            return DepartamentoDat.InsertDepartamento(codigo, nombre, fkPaisId);
        }

        // Lógica para actualizar un departamento existente
        public bool EditDepartamento(int id, string codigo, string nombre, int paisId)
        {
            // Llama al método en la capa de datos para actualizar el departamento con el ID especificado
            return DepartamentoDat.UpdateDepartamento(id, codigo, nombre, paisId);
        }

        // Lógica para eliminar un departamento
        public bool RemoveDepartamento(int id)
        {
            // Llama al método en la capa de datos para eliminar el departamento por su ID
            return DepartamentoDat.DeleteDepartamento(id);
        }

        // Lógica para obtener los departamentos para un DropDownList
        public DataSet GetDepartamentosDDL()
        {
            // Llama al método en la capa de datos para obtener los departamentos para el DropDownList
            return DepartamentoDat.GetDepartamentosDDL();
        }
    }
}
