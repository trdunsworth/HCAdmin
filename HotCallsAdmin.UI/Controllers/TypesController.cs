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
    public class TypesController : Controller
	{
		private ITypesRepository typesRepository;
		public TypesController(ITypesRepository typesRepository)
		{
			this.typesRepository = typesRepository;
		}

		public ViewResult List()
		{
			return View(typesRepository.Types.ToList());
		}

		public ViewResult Edit(int typeId)
		{
			var atype = typesRepository.Types.First(x => x.Id == typeId);
			return View(atype);
		}

		[HttpPost]
		public ActionResult Edit(int typeId)
		{
			Atype atype = typeId == 0
				? new Atype()
				: typesRepository.Types.First(x => x.Id == typeId);
			TryUpdateModel(atype);

			if (ModelState.IsValid)
			{
				typesRepository.SaveType(atype);
				TempData["message"] = atype.Agency + " Id no. " + atype.Id.ToString() + " was saved.";
				return RedirectToAction("List");
			}
			else // Validation error
				return View(atype);
		}

		public ViewResult Create()
		{
			return View("Edit", new Atype());
		}

		public RedirectToRouteResult Delete(int typeId)
		{
			var atype = typesRepository.Types.First(x => x.Id == typeId);
			typesRepository.DeleteType(atype);
			TempData["message"] = atype.Agency + " Id no. " + atype.Id.ToString() + " was deleted.";
			return RedirectToAction("List");
		}
    }
}
