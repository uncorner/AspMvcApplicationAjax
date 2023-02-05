using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace TestAspMvcApplication.DataAccess
{
    public class DbStorage : IDataStorage
    {
        private static readonly string connectionString;

        static DbStorage()
        {
            connectionString = ConfigurationManager.
                ConnectionStrings["DataClassesConnectionString"].ConnectionString;
        }

        private DataClassesDataContext CreateContext()
        {
            return new DataClassesDataContext(connectionString);
        }

        public void DeleteAllEmployees()
        {
            using (var context = CreateContext())
            {
                context.ExecuteCommand("DELETE FROM Employee");
            }
        }
        
        public void SaveEmployee(Employee employee)
        {
            using (var context = CreateContext())
            {
                context.Employee.InsertOnSubmit(employee);
                context.SubmitChanges();
            }
        }

        public IEnumerable<Employee> FetchAllEmployees()
        {
            using (var context = CreateContext())
            {
                return context.Employee
                    .OrderBy(e => e.Surname)
                    .ToList();
            }
        }

        public IEnumerable<Employee> FetchEmployeesBySurname(string surname)
        {
            if (surname == null)
            {
                throw new ArgumentNullException("surname");
            }

            using (var context = CreateContext())
            {
                return context.Employee
                    .Where(e => e.Surname == surname)
                    .OrderBy(e => e.Surname)
                    .ToList();
            }
        }

        public IEnumerable<Employee> FetchEmployeesByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            using (var context = CreateContext())
            {
                return context.Employee
                    .Where(e => e.Name == name)
                    .OrderBy(e => e.Surname)
                    .ToList();
            }
        }

        public IEnumerable<string> FetchFilterDataBySurname()
        {
            using(var context = CreateContext())
            {
                var items = (from e in context.Employee
                             group e by e.Surname
                                 into grp
                                 select new
                                            {
                                                Surname = grp.Key
                                            });

                var result = new List<string>();
                foreach (var item in items)
                {
                    result.Add(item.Surname);
                }

                return result;
            }
        }

        public IEnumerable<string> FetchFilterDataByName()
        {
            using (var context = CreateContext())
            {
                var items = (from e in context.Employee
                             group e by e.Name
                                 into grp
                                 select new
                                            {
                                                Name = grp.Key,
                                            });

                var result = new List<string>();
                foreach (var item in items)
                {
                    result.Add(item.Name);
                }

                return result;
            }
        }

        public void SaveCar(Car car)
        {
            using (var context = CreateContext())
            {
                car.Id = Guid.NewGuid();

                context.Car.InsertOnSubmit(car);
                context.SubmitChanges();
            }
        }

        public IEnumerable<Car> FetchAllCars()
        {
            using (var context = CreateContext())
            {
                return context.Car.ToList();
            }
        }

    }
}