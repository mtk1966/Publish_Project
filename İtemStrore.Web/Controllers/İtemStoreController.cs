using İtemStrore.Web.Models;
using ItemStrore.Web.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace İtemStrore.Web.Controllers
{
    public class İtemStoreController : Controller
    {
        private readonly DbContext _dbContext;

        public İtemStoreController(AppDbContext  dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            // Veritabanından verileri çekip doğrudan ViewModel'e eşliyoruz
            var items = await _dbContext.Set<İtemEntity>()
                .Select(i => new ItemViewModel
                {
                    Name = i.İtemName,
                    Price = i.İtemPrice
                })
                .ToListAsync();

            return View(items);
        }
        public IActionResult İtemAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> İtemAdd(ItemViewModel model)
        {
          
            var itemAdd = new İtemEntity
            {
                Id = Guid.CreateVersion7(),
                İtemName = model.Name,
                İtemPrice = model.Price,
            };
             _dbContext.Add(itemAdd);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
