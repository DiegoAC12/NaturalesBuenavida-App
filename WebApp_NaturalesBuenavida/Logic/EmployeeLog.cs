using System.Data;
using Data;

namespace Logic
{
    public class EmployeeLog
    {
        DataEmployee dataEmployee = new DataEmployee();

        // Lógica para obtener todos los empleados
        public DataSet GetEmployees()
        {
            return dataEmployee.ShowEmployees();
        }

        // Lógica para guardar un nuevo empleado
        public bool AddEmployee(int personaId)
        {
            return dataEmployee.SaveEmployee(personaId);
        }

        // Lógica para actualizar un empleado
        public bool EditEmployee(int empId, int personaId)
        {
            return dataEmployee.UpdateEmployee(empId, personaId);
        }

        // Lógica para eliminar un empleado
        public bool RemoveEmployee(int empId)
        {
            return dataEmployee.DeleteEmployee(empId);
        }

        // Lógica para mostrar empleados con DDL
        public DataSet GetEmployeesDDL()
        {
            return dataEmployee.ShowEmployeesDDL();
        }
    }
}
