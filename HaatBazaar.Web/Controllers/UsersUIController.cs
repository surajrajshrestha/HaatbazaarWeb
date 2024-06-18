using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class UsersUiController : Controller
    {
        // GET: UsersUIController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsersUIController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersUIController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersUIController/Create
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

        // GET: UsersUIController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersUIController/Edit/5
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

        // GET: UsersUIController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersUIController/Delete/5
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
