using System.Web.Mvc;

namespace FunMatchGame.Controllers
{
	public class GameController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}