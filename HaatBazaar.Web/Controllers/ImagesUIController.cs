using HaatBazaar.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class ImagesUiController(IConfiguration configuration) : BaseController(configuration, "images")
    {
        public async Task<IActionResult> Index()
        {
            var images = await GetAllAsync<Image>();
            return View(images);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var image = await GetByIdAsync<Image>(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Path")] Image image)
        {
            if (!ModelState.IsValid) 
                return View(image);

            await PostAsync(image);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await GetByIdAsync<Image>(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Path")] Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) 
                return View(image);

            await PutAsync(id, image);

            return RedirectToAction(nameof(Index));
        }

        // GET: ImagesUI/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var image = await GetByIdAsync<Image>(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: ImagesUI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await DeleteAsync<Category>(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
