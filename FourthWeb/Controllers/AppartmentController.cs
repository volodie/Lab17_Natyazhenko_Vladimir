using FourthWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FourthWeb.Controllers
{
    public class RegisterAppartmentController : Controller
    {
        public IActionResult RegApp()
        {
            return View();
        }
        public IActionResult DelApp()
        {
            return View();
        }

        public IActionResult ShowApp()
        {
            return View();
        }

        public IActionResult Index()
        {
            ViewData["Result"] = "Hello! ";
            return View();
        }
        public IActionResult RegAppartment(int idApp, int numberRooms, int square, int buildingYear, int flat)
        {
        
            AppartmentCollectionModel model = GetAppartmentCollectionModel();

            var Appartment = new AppartmentModel()
            {
                IdAPP = idApp,
                Rooms = numberRooms,
                Square = square,
                BuildingYear = buildingYear,
                Flat = flat
            };
            model.Collection.Add(Appartment);

            AppartmentCollectionModel m = PutAppartmentCollectionModel(model);
            
            ViewData["Result"] = "New appartment added";

            return View("Index");
        }
        public IActionResult ViewAllAppartments()
        {

            AppartmentCollectionModel mod = GetAppartmentCollectionModel();

            return View(mod.Collection);
        }

        public IActionResult DelAppartment(int id)
        {

            AppartmentCollectionModel mod = GetAppartmentCollectionModel();

            AppartmentModel tmpmod = mod.Collection.First(x => x.IdAPP == id);
            
            if (tmpmod != null)
            {
                mod.Collection.Remove(tmpmod);
                ViewBag.result = "Appartment deleted";

                AppartmentCollectionModel m = PutAppartmentCollectionModel(mod);
                return View("Index");
            }
            else
            {
                ViewBag.result = "Appartment not found";
                return View("Index");
            }
        }
        public IActionResult ShowAppartment(int id)
        {

            AppartmentCollectionModel mod = GetAppartmentCollectionModel();

            try
                {
                    return View(mod.Collection.First(x => x.IdAPP == id));
                }
            catch
                {
                    ViewBag.result = "not found";
                    return View("Index");
                }
        }

        private AppartmentCollectionModel GetAppartmentCollectionModel()
        {
            using (var f = new StreamReader("../Appartments.json"))
            {
                string s = f.ReadToEnd();
                return string.IsNullOrEmpty(s)
                    ? new AppartmentCollectionModel()
                    : JsonConvert.DeserializeObject<AppartmentCollectionModel>(s);
            }
        }
        private AppartmentCollectionModel PutAppartmentCollectionModel(AppartmentCollectionModel m)
        {
            using (StreamWriter w = new StreamWriter("../Appartments.json", false))
            {
                w.Write(JsonConvert.SerializeObject(m).ToString());
                return m;
            }
        }
    }
}
