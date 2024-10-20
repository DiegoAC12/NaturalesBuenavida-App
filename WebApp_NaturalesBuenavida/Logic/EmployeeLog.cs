using System;
using System.Data;
using Data; // Referencia a la capa de datos

namespace Logic
{
    public class LogicEmpleado
    {
        DataEmpleado objDataEmpleado = new DataEmpleado();

        // Método para obtener todos los empleados
        public DataSet GetEmpleados()
        {
            try
            {
                return objDataEmpleado.showEmpleado();
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al obtener empleados: " + ex.Message);
            }
        }

        // Método para agregar un nuevo empleado
        public bool AddEmpleado(int personaId)
        {
            if (personaId <= 0)
            {
                throw new ArgumentException("El ID de la persona no es válido.");
            }

            try
            {
                return objDataEmpleado.saveEmpleado(personaId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al agregar empleado: " + ex.Message);
            }
        }

        // Método para actualizar un empleado
        public bool UpdateEmpleado(int empId, int personaId)
        {
            if (empId <= 0)
            {
                throw new ArgumentException("El ID del empleado no es válido.");
            }

            if (personaId <= 0)
            {
                throw new ArgumentException("El ID de la persona no es válido.");
            }

            try
            {
                return objDataEmpleado.updateEmpleado(empId, personaId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al actualizar empleado: " + ex.Message);
            }
        }

        // Método para eliminar un empleado
        public bool DeleteEmpleado(int empId)
        {
            if (empId <= 0)
            {
                throw new ArgumentException("El ID del empleado no es válido.");
            }

            try
            {
                return objDataEmpleado.deleteEmpleado(empId);
            }
            catch (Exception ex)
            {
                // Manejo de errores a nivel de lógica de negocio
                throw new Exception("Error al eliminar empleado: " + ex.Message);
            }
        }
    }
}
