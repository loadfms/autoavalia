using System.Web.Mvc;

namespace Webmotors.Api.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
        }
	}
}
