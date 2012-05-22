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
    public class AgenciesController : Controller
    {
		private IAgenciesRepository agenciesRepository;
		public AgenciesController(IAgenciesRepository agenciesRepository)
		{
			this.agenciesRepository = agenciesRepository;
		}

		public ViewResult List()
		{
			return View(agenciesRepository.Agencies.ToList());
		}

		public ViewResult Edit(int agencyId)
		{
			var agency = agenciesRepository.Agencies.First(x => x.Id == agencyId);
			return View(agency);
		}

		[HttpPost]
		public ActionResult Edit(int agencyId)
		{
			Agency agency = agencyId == 0
				? new Agency()
				: agenciesRepository.Agencies.First(x => x.Id == agencyId);
			TryUpdateModel(agency);

			if (ModelState.IsValid)
			{
				agenciesRepository.SaveAgency(agency);
				TempData["message"] = agency.Id.ToString() + " " + agency.Ag_Id + "has been saved";
				return RedirectToAction("List");
			}
			else // Validation error
				return View(agency);
		}

		public ViewResult Create()
		{
			return View("Edit", new Agency());
		}

		public RedirectToRouteResult Delete(int agencyId)
		{
			var agency = agenciesRepository.Agencies.First(x => x.Id == agencyId);
			agenciesRepository.DeleteAgency(agency);
			TempData["message"] = agency.Id.ToString() + " " + agency.Ag_Id + " was deleted.";
			return RedirectToAction("List");
		}
    }
}
