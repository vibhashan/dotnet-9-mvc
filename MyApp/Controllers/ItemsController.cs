using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ItemsController(MyAppContext appContext) : Controller
    {
        public IActionResult Overview()
        {
            Item item = new()
            {
                Name = "Keyboard"
            };

            Console.WriteLine("### " + appContext.Item.Count());

            return View(item);
        }

        public IActionResult Edit([FromRoute] int id)
        {
            return Content("id=" + id);
        }
    }
}