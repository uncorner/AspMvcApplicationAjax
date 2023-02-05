using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAspMvcApplication.DataAccess;

namespace TestAspMvcApplication.Models
{
    public class DataInitializer
    {
        readonly IDataStorage storage = DataStorageFactory.Create();

        public DataInitializer()
        {
            storage.DeleteAllEmployees();

            PrepareTestingData();
            PrepareTestingData_2();
        }

        private void PrepareTestingData_2()
        {
            Car car;
            storage.SaveCar(new Car()
                                {
                                    Name = "Бмв"
                                });
            storage.SaveCar(new Car
                                {
                                    Name = "Мерседес"
                                });
            storage.SaveCar(new Car
                                {
                                    Name = "Опель"
                                });
            storage.SaveCar(new Car
            {
                Name = "Лада"
            });
            storage.SaveCar(new Car
            {
                Name = "Рено"
            });
            storage.SaveCar(new Car
            {
                Name = "Мазда"
            });
            storage.SaveCar(new Car
            {
                Name = "Ниссан"
            });

        }

        private void PrepareTestingData()
        {
            Employee employee;
            employee = new Employee
            {
                Id = 10,
                Name = "Петр",
                Surname = "Петров",
                Address = "Новоселов 53"
            };
            storage.SaveEmployee(employee);

            employee = new Employee
            {
                Id = 20,
                Name = "Иван",
                Surname = "Сидоров",
                Address = "Первомайский проспект 10а"
            };
            storage.SaveEmployee(employee);

            employee = new Employee
            {
                Id = 30,
                Name = "Алексей",
                Surname = "Кузнецов",
                Address = "Дзержинского 12"
            };
            storage.SaveEmployee(employee);

            employee = new Employee
            {
                Id = 40,
                Name = "Михаил",
                Surname = "Иванов",
                Address = "Свободы 34/2"
            };
            storage.SaveEmployee(employee);

            employee = new Employee
            {
                Id = 50,
                Name = "Александр",
                Surname = "Федоров",
                Address = "Горького 24"
            };
            storage.SaveEmployee(employee);

            employee = new Employee
            {
                Id = 60,
                Name = "Александр",
                Surname = "Карпов",
                Address = "Ленина 10"
            };
            storage.SaveEmployee(employee);

            employee = new Employee
            {
                Id = 70,
                Name = "Михаил",
                Surname = "Федоров",
                Address = "Театральная 47"
            };
            storage.SaveEmployee(employee);

            employee = new Employee
            {
                Id = 80,
                Name = "Алексей",
                Surname = "Петров",
                Address = "Новая 15"
            };
            storage.SaveEmployee(employee);

            employee = new Employee
            {
                Id = 90,
                Name = "Дмитрий",
                Surname = "Лаптев",
                Address = "Яблочкова 30"
            };
            storage.SaveEmployee(employee);

            employee = new Employee
            {
                Id = 100,
                Name = "Илья",
                Surname = "Никитин",
                Address = "Первомайский проспект 20"
            };
            storage.SaveEmployee(employee);
        }

    }


}