using System.Data;
using Data;

namespace Logic
{
    public class PersonaLog
    {
        PersonaDat PersonaDat = new PersonaDat();

        // Lógica para mostrar todas las personas
        public DataSet GetPersonas()
        {
            return PersonaDat.ShowPersonas();
        }

        // Lógica para insertar una nueva persona
        public bool AddPersona(string identificacion, string nombreRazonSocial, string apellido, string telefono,
                               string direccion, string correoElectronico, int fkDocId, int fkPaisId)
        {
            return PersonaDat.InsertPersona(identificacion, nombreRazonSocial, apellido, telefono, direccion,
                                             correoElectronico, fkDocId, fkPaisId);
        }

        // Lógica para actualizar una persona existente
        public bool EditPersona(int id, string identificacion, string nombreRazonSocial, string apellido,
                                string telefono, string direccion, string correoElectronico, int docId, int paisId)
        {
            return PersonaDat.UpdatePersona(id, identificacion, nombreRazonSocial, apellido, telefono,
                                             direccion, correoElectronico, docId, paisId);
        }

        // Lógica para eliminar una persona
        public bool RemovePersona(int id)
        {
            return PersonaDat.DeletePersona(id);
        }

        // Lógica para obtener las personas para DDL
        public DataSet GetPersonasDDL()
        {
            return PersonaDat.GetPersonasDDL();
        }
    }
}
