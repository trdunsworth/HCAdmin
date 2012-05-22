using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Concrete;

namespace HotCallsAdmin.UI.Controllers
{
    public class SentsController : Controller
    {
		private ISentsRepository sentsRepository;
		public SentsController(ISentsRepository sentsRepository)
		{
			this.sentsRepository = sentsRepository;
		}

		public ViewResult List()
		{
			return View(sentsRepository.Sents.ToList());
		}
    }
}
