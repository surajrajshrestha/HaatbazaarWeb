using HaatBazaar.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class CategoriesUiController(IConfiguration configuration) : BaseController(configuration)
    {
        private const string Endpoint = "categories";
        public async Task<IActionResult> Index()
        {
            var categories = await GetAllAsync<Category>($"{Endpoint}");
            return View(categories);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await GetByIdAsync<Category>($"{Endpoint}", id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
        {
            if (!ModelState.IsValid) 
                return View(category);

            await PostAsync($"{Endpoint}", category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await GetByIdAsync<Category>($"{Endpoint}", id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) 
                return View(category);

            await PutAsync($"{Endpoint}", id, category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await GetByIdAsync<Category>($"{Endpoint}", id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await DeleteAsync<Category>($"{Endpoint}", id);

            return RedirectToAction(nameof(Index));
        }
    }
}
