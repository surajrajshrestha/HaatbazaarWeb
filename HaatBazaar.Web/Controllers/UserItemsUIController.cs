using HaatBazaar.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaatBazaar.Web.Controllers
{
    public class UserItemsUiController(IConfiguration configuration) : BaseController(configuration, "useritems")
    {
        public async Task<IActionResult> Index()
        {
            var userItems = await GetAllAsync<UserItem>();
            return View(userItems);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userItem = await GetByIdAsync<UserItem>(id);
            if (userItem == null)
            {
                return NotFound();
            }

            return View(userItem);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await GetAllAsync<Category>(), "Id", "Id");
            ViewData["ItemId"] = new SelectList(await GetAllAsync<Item>(), "Id", "Id");
            ViewData["UserId"] = new SelectList(await GetAllAsync<User>(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ItemId,Price")] UserItem userItem)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ItemId"] = new SelectList(await GetAllAsync<Item>(), "Id", "Id", userItem.ItemId);
                ViewData["UserId"] = new SelectList(await GetAllAsync<User>(), "Id", "Id", userItem.UserId);
                return View(userItem);
            }

            await PostAsync(userItem);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userItem = await GetByIdAsync<UserItem>(id);
            if (userItem == null)
            {
                return NotFound();
            }

            ViewData["ItemId"] = new SelectList(await GetAllAsync<Item>(), "Id", "Id", userItem.ItemId);
            ViewData["UserId"] = new SelectList(await GetAllAsync<User>(), "Id", "Id", userItem.UserId);
            return View(userItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("UserId,ItemId,Price")] UserItem userItem)
        {
            if (id != userItem.UserId)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                ViewData["ItemId"] = new SelectList(await GetAllAsync<Item>(), "Id", "Id", userItem.ItemId);
                ViewData["UserId"] = new SelectList(await GetAllAsync<User>(), "Id", "Id", userItem.UserId);
                return View(userItem);
            }
            await PutAsync(id, userItem);

            return RedirectToAction(nameof(Index));
        }

        // GET: UserItemsUI/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userItem = await GetByIdAsync<UserItem>(id);
            if (userItem == null)
            {
                return NotFound();
            }

            return View(userItem);
        }

        // POST: UserItemsUI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await DeleteAsync<UserItem>(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
