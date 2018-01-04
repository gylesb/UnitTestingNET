using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListContext db = new ToDoListContext();
        public IActionResult Index()
        {
            return View(db.Items.ToList());
        }
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Item item)
		{
			db.Items.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Details(int id)
		{
			Item thisItem = db.Items.FirstOrDefault(items => items.id == id);
			return View(thisItem);
		}
    }
}
