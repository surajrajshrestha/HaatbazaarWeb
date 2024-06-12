using HaatBazaar.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class ItemsUiController(IConfiguration configuration) : BaseController(configuration, "items")
    {
        public async Task<IActionResult> Index()
        {
            var items = await GetAllAsync<Item>();
            return View(items);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await GetByIdAsync<Item>(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Item item)
        {
            if (!ModelState.IsValid) 
                return View(item);
            await PostAsync(item);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await GetByIdAsync<Item>(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid) 
                return View(item);
            await PutAsync(id, item);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await GetByIdAsync<Item>(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: ItemsUI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await DeleteAsync<Item>(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
