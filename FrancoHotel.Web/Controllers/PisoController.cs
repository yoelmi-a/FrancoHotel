using Microsoft.AspNetCore.Mvc;

namespace FrancoHotel.Web.Controllers
{
    public class PisoController : Controller
    {
        // GET: PisoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PisoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PisoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PisoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PisoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PisoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PisoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PisoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
