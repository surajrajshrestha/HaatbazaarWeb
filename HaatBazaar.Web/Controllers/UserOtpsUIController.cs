namespace HaatBazaar.Web.Controllers
{
    public class UserOtpsUiController(IConfiguration configuration) : BaseController(configuration)
    {
        private const string endpoint = "userotps";
        //public async Task<IActionResult> Index()
        //{
        //    var userOtps = await GetAllAsync<UserOtp>();
        //    return View(userOtps);
        //}

        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var userOtp = await GetByIdAsync<UserOtp>(id);
        //    if (userOtp == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userOtp);
        //}

        //public async Task<IActionResult> Create()
        //{
        //    ViewData["UserId"] = new SelectList(await GetAllAsync<User>(), "Id", "Id");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserId,PhoneNumber,Otp,DateSent")] UserOtp userOtp)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewData["UserId"] = new SelectList(await GetAllAsync<User>(), "Id", "Id", userOtp.UserId);
        //        return View(userOtp);
        //    }

        //    await PostAsync(userOtp);
        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var userOtp = await GetByIdAsync<UserOtp>(id);
        //    if (userOtp == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(await GetAllAsync<User>(), "Id", "Id", userOtp.UserId);
        //    return View(userOtp);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("UserId,PhoneNumber,Otp,DateSent")] UserOtp userOtp)
        //{
        //    if (id != userOtp.UserId)
        //    {
        //        return NotFound();
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        ViewData["UserId"] = new SelectList(await GetAllAsync<User>(), "Id", "Id", userOtp.UserId);
        //        return View(userOtp);
        //    }
        //    await PutAsync(id, userOtp);

        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var userOtp = await GetByIdAsync<UserOtp>(id);
        //    if (userOtp == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userOtp);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    await DeleteAsync<UserOtp>(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
