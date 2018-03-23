using System.Web.Mvc;

namespace AutoAvalia_API.Controllers
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
