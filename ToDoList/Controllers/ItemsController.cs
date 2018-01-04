using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Linq;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListContext db = new ToDoListContext();
        public IActionResult Index()
        {
            ToDoList<Item> model = db.Items.ToList();
            return View(model);
        }

		public IActionResult Details(int id)
		{
			Item thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
			return View(thisItem);
		}
    }
}
