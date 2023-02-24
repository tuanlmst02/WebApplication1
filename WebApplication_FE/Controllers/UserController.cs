using Microsoft.AspNetCore.Mvc;
using WebApplication_FE.Models;

namespace WebApplication_FE.Controllers
{
	public class UserController : Controller
	{
		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(User user)
		{
			//call api in here 
			// https://localhost:7249/User
			ViewBag.Message = "Login Success";
			return RedirectToAction("Index", "Home");
		}
	}
}
