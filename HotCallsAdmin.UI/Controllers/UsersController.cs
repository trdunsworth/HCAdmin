using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Concrete;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.UI.Controllers
{
    public class UsersController : Controller
    {
		private IUsersRepository usersRepository;
		public UsersController(IUsersRepository usersRepository)
		{
			this.usersRepository = usersRepository;
		}

		public ViewResult List()
		{
			return View(usersRepository.Users.ToList());
		}

		public ViewResult Edit(int userId)
		{
			var user = usersRepository.Users.First(x => x.Id == userId);
			return View(user);
		}

		[HttpPost]
		public ActionResult Edit(int userId)
		{
			User user = userId == 0
				? new User()
				: usersRepository.Users.First(x => x.Id == userId);
			TryUpdateModel(user);

			if (ModelState.IsValid)
			{
				usersRepository.SaveUser(user);
				TempData["message"] = user.Lname + ", " + user.Fname + " has been saved.";
				return RedirectToAction("List");
			}
			else // Validation error
				return View(user);
		}

		public ViewResult Create()
		{
			return View("Edit", new User());
		}

		public RedirectToRouteResult Delete(int userId)
		{
			var user = usersRepository.Users.First(x => x.Id == userId);
			usersRepository.DeleteUser(user);
			TempData["message"] = user.Lname + ", " + user.Fname + " has been deleted.";
			return RedirectToAction("List");
		}
    }
}
