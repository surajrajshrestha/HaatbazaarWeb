using HaatBazaar.Web.Models.UserItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaatBazaar.Web.Controllers
{
    public class UserItemsUiController(IConfiguration configuration) : BaseController(configuration)
    {
        private const string Endpoint = "useritems";
        public async Task<IActionResult> Index()
        {
            var userItems = await GetAllAsync<UserItemDisplayModel>($"{Endpoint}");
            return View(userItems);
        }

        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var userItem = await GetByIdAsync<UserItem>(id);
        //    if (userItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userItem);
        //}

        public async Task<IActionResult> Create()
        {
            var items = await GetAllAsync<BaseItemModel>("items");
            
            return View(new UserItemCreateModel()
            {
                Items = items
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,Quantity,Price,Unit")] UserItemCreateModel userItem)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ItemId"] = new SelectList(await GetAllAsync<BaseItemModel>("items"), "Id", "Item", userItem.ItemId);
                return View(userItem);
            }

            await PostAsync($"{Endpoint}", userItem);
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var userItem = await GetByIdAsync<UserItem>(id);
        //    if (userItem == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewData["ItemId"] = new SelectList(await GetAllAsync<Item>(), "Id", "Id", userItem.ItemId);
        //    return View(userItem);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("UserId,ItemId,Price")] UserItem userItem)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewData["ItemId"] = new SelectList(await GetAllAsync<Item>(), "Id", "Id", userItem.ItemId);
        //        return View(userItem);
        //    }
        //    await PutAsync(id, userItem);

        //    return RedirectToAction(nameof(Index));
        //}

        //// GET: UserItemsUI/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var userItem = await GetByIdAsync<UserItem>(id);
        //    if (userItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userItem);
        //}

        //// POST: UserItemsUI/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    await DeleteAsync<UserItem>(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
