using System.Data;
using Data;

namespace Logic
{
    public class EmployeeLog
    {
        DataEmployee dataEmployee = new DataEmployee();

        // L�gica para obtener todos los empleados
        public DataSet GetEmployees()
        {
            return dataEmployee.ShowEmployees();
        }

        // L�gica para guardar un nuevo empleado
        public bool AddEmployee(int personaId)
        {
            return dataEmployee.SaveEmployee(personaId);
        }

        // L�gica para actualizar un empleado
        public bool EditEmployee(int empId, int personaId)
        {
            return dataEmployee.UpdateEmployee(empId, personaId);
        }

        // L�gica para eliminar un empleado
        public bool RemoveEmployee(int empId)
        {
            return dataEmployee.DeleteEmployee(empId);
        }

        // L�gica para mostrar empleados con DDL
        public DataSet GetEmployeesDDL()
        {
            return dataEmployee.ShowEmployeesDDL();
        }
    }
}
