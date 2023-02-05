using System.Collections.Generic;

namespace TestAspMvcApplication.DataAccess
{
    public interface IDataStorage
    {
        void DeleteAllEmployees();
        void SaveEmployee(Employee employee);
        IEnumerable<Employee> FetchAllEmployees();
        IEnumerable<Employee> FetchEmployeesBySurname(string surname);
        IEnumerable<Employee> FetchEmployeesByName(string name);
        IEnumerable<string> FetchFilterDataBySurname();
        IEnumerable<string> FetchFilterDataByName();
        void SaveCar(Car car);
        IEnumerable<Car> FetchAllCars();
    }
}
