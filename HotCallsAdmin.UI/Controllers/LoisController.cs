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
    public class LoisController : Controller
    {
		private ILoisRepository loisRepository;
		public LoisController(ILoisRepository loisRepository)
		{
			this.loisRepository = loisRepository;
		}

		public ViewResult List()
		{
			return View(loisRepository.Lois.ToList());
		}

		public ViewResult Edit(int loiId)
		{
			var loi = loisRepository.Lois.First(x => x.Id == loiId);
			return View(loi);
		}

		[HttpPost]
		public ActionResult Edit(int loiId)
		{
			Loi loi = loiId == 0 ? new Loi() : loisRepository.Lois.First(x => x.Id == loiId);
			TryUpdateModel(loi);

			if (ModelState.IsValid)
			{
				loisRepository.SaveLoi(loi);
				TempData["message"] = loi.Id.ToString() + " has been saved";
				return RedirectToAction("List");
			}
			else // Validation Error
				return View(loi);
		}

		public ViewResult Create()
		{
			return View("Edit", new Loi());
		}

		public RedirectToRouteResult Delete(int loiId)
		{
			var loi = loisRepository.Lois.First(x => x.Id == loiId);
			loisRepository.DeleteLoi(loi);
			TempData["message"] = loi.Id.ToString() + " was deleted.";
			return RedirectToAction("List");
		}
    }
}
