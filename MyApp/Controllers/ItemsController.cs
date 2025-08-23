using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ItemsController(MyAppContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Item> items = await context
                .Items
                .Include(s => s.SerialNumber)
                .Include(c => c.Category)
                .Include(ic => ic.ItemClients)
                .ThenInclude(c => c.Client)
                .ToListAsync();

            return View(items);
        }

        public async Task<IActionResult> ShowForm([FromRoute] int? id)
        {
            ViewData["Categories"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(context.Categories, "Id", "Name");

            if (id is not null)
            {
                Item? item = await context.Items.FirstOrDefaultAsync(i => id == i.Id);
                return View(item);
            }

            return View();
        }

        public async Task<IActionResult> ConfirmDialog([FromRoute] int id)
        {
            Item? item = await context.Items.FirstOrDefaultAsync(i => id == i.Id);
            return View(item);
        }

        [HttpPost("/create")]
        public async Task<IActionResult> Create([Bind("Name, Price, CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                await context.Items.AddAsync(item);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("ShowForm");
        }

        [HttpPost("/edit")]
        public async Task<IActionResult> Edit([Bind("Id, Name, Price, CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                Item? itemToUpdate = await context.Items.FirstOrDefaultAsync(i => i.Id == item.Id);

                if (itemToUpdate is not null)
                {
                    itemToUpdate.Name = item.Name;
                    itemToUpdate.Price = item.Price;
                    itemToUpdate.CategoryId = item.CategoryId;

                    await context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }

            return RedirectToAction(nameof(ShowForm));
        }

        [HttpPost("/delete")]
        public async Task<IActionResult> Delete([Bind("Id")] int id)
        {
            Item? entityToDelete = await context.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (entityToDelete is not null)
            {
                context.Items.Remove(entityToDelete);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}