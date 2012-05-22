using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Concrete;

namespace HotCallsAdmin.UI.Controllers
{
    public class CurentsController : Controller
    {
		private ICurentsRespository curentsRepository;
		public CurentsController(ICurentsRespository curentsRepository)
		{
			this.curentsRepository = curentsRepository;
		}

		public ViewResult List()
		{
			return View(curentsRepository.Curents.ToList());
		}
    }
}
