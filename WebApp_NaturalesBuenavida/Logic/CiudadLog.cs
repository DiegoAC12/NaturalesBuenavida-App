using System.Data;
using Data;

namespace Logic
{
    public class CiudadLog
    {
        // Instancia de la clase CiudadDat que maneja la interacción con la base de datos
        CiudadDat CiudadDat = new CiudadDat();

        // Método para obtener todas las ciudades desde la capa de datos
        public DataSet GetCiudades()
        {
            // Llama al método ShowCiudades en la capa de datos para recuperar el conjunto de ciudades
            return CiudadDat.ShowCiudades();
        }

        // Método para insertar una nueva ciudad en la base de datos
        public bool AddCiudad(string codigo, string nombre, int depId)
        {
            // Llama al método InsertCiudad en la capa de datos para insertar la ciudad con los parámetros proporcionados
            return CiudadDat.InsertCiudad(codigo, nombre, depId);
        }

        // Método para actualizar los datos de una ciudad existente
        public bool EditCiudad(int id, string codigo, string nombre, int depId)
        {
            // Llama al método UpdateCiudad en la capa de datos para actualizar la ciudad identificada por el ID
            return CiudadDat.UpdateCiudad(id, codigo, nombre, depId);
        }

        // Método para eliminar una ciudad de la base de datos
        public bool RemoveCiudad(int id)
        {
            // Llama al método DeleteCiudad en la capa de datos para eliminar la ciudad por su ID
            return CiudadDat.DeleteCiudad(id);
        }

        // Método para obtener un conjunto de datos de ciudades para usar en un DropDownList
        public DataSet GetCiudadesDDL()
        {
            // Llama al método GetCiudadesDDL en la capa de datos para obtener el conjunto de ciudades
            return CiudadDat.GetCiudadesDDL();
        }
    }
}
