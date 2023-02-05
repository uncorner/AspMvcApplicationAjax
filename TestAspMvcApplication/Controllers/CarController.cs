using System.Web.Mvc;
using TestAspMvcApplication.DataAccess;
using TestAspMvcApplication.Models.Forms;

namespace TestAspMvcApplication.Controllers
{
    public class CarController : Controller
    {
        private readonly IDataStorage storage = DataStorageFactory.Create();

        public ActionResult Index()
        {
            return RedirectToAction("list", "car");
        }

        public ActionResult List()
        {
            var cars = storage.FetchAllCars();
            return View(cars);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CarForm form)
        {
            if (ModelState.IsValid)
            {
                var car = form.GetCar();
                storage.SaveCar(car);

                return RedirectToAction("list", "car");
            }

            return View();
        }


        /*
        //
        // GET: /Car/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Car/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

         

        
        
        //
        // GET: /Car/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Car/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Car/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Car/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */

    }
}
