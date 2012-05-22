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
    public class PrioritiesController : Controller
    {
		private IPrioritiesRepository prioritiesRepository;
		public PrioritiesController(IPrioritiesRepository prioritiesRepository)
		{
			this.prioritiesRepository = prioritiesRepository;
		}

		public ViewResult List()
		{
			return View(prioritiesRepository.Priorities.ToList());
		}

		public ViewResult Edit(int priorityId)
		{
			var priority = prioritiesRepository.Priorities.First(x => x.Id == priorityId);
			return View(priority);
		}

		[HttpPost]
		public ActionResult Edit(int priorityId)
		{
			Priority priority = priorityId == 0 ? new Priority() : prioritiesRepository.Priorities.First(x => x.Id == priorityId);
			TryUpdateModel(priority);

			if (ModelState.IsValid)
			{
				prioritiesRepository.SavePriority(priority);
				TempData["message"] = priority.Id.ToString() + " has been saved.";
				return RedirectToAction("List");
			}
			else // Validation errors
				return View(priority);
		}

		public ViewResult Create()
		{
			return View("Edit", new Priority());
		}

		public RedirectToRouteResult Delete(int priorityId)
		{
			var priority = prioritiesRepository.Priorities.First(x => x.Id == priorityId);
			prioritiesRepository.DeletePriority(priority);
			TempData["message"] = priority.Id.ToString() + " was deleted.";
			return RedirectToAction("List");
		}
    }
}
