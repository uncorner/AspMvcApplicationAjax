using System.Collections.Generic;
using System.Web.Mvc;
using TestAspMvcApplication.DataAccess;
using TestAspMvcApplication.Models;

namespace TestAspMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        readonly IDataStorage storage = DataStorageFactory.Create();

        [HttpGet]
        public ActionResult Index()
        {
            var model = GetMainPageModel();
            return View(model);
        }

        [HttpPost]
        public JsonResult FilterBySurname(string data)
        {
            var employees = string.IsNullOrEmpty(data) ?
                storage.FetchAllEmployees() :
                storage.FetchEmployeesBySurname(data);
            
            return Json(employees);
        }

        [HttpPost]
        public JsonResult FilterByName(string data)
        {
            var employees = string.IsNullOrEmpty(data) ?
                storage.FetchAllEmployees() :
                storage.FetchEmployeesByName(data);

            return Json(employees);
        }

        [HttpGet]
        public ActionResult GetSecondPagePartial()
        {
            var filterEmployees = storage.FetchFilterDataByName();
            var model = GetPageModel(filterEmployees, "Фильтр по именам", "/Home/FilterByName");
            return PartialView("FilterTable", model);
        }

        [HttpGet]
        public ActionResult GetMainPagePartial()
        {
            var model = GetMainPageModel();
            return PartialView("FilterTable", model);
        }

        private ViewModel GetMainPageModel()
        {
            var filterEmployees = storage.FetchFilterDataBySurname();
            return GetPageModel(filterEmployees, "Фильтр по фамилиям", "/Home/FilterBySurname");
        }

        private ViewModel GetPageModel(
            IEnumerable<string> filterEmployees,
            string filterListName,
            string requestUrl)
        {
            var employees = storage.FetchAllEmployees();

            var filterList = new List<string>(filterEmployees);
            filterList.Insert(0, "");

            return new ViewModel
            {
                FilterListName = filterListName,
                Employees = employees,
                SelectList = new SelectList(filterList),
                RequestUrl = requestUrl
            };
        }

    }
}
