using Entities.Domains;
using FullEfCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Diagnostics;

namespace FullEfCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, BlogDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {

            //var ar1 = new Article()
            //{
            //    Title = "Title 1",
            //    CategoryId = 1,
            //    CreatedDate = DateTime.Now,
            //};


            //var ar2 = new Article()
            //{
            //    Title = "Title 2",
            //    CategoryId = 1,
            //    CreatedDate = DateTime.Now,
            //};

            //var ar3 = new Article()
            //{
            //    Title = "Title 3",
            //    CategoryId = 1,
            //    CreatedDate = DateTime.Now,
            //};



            //var ar4 = new Article()
            //{
            //    Title = "Title 1",
            //    CategoryId = 2,
            //    CreatedDate = DateTime.Now,
            //};


            //await _dbContext.Set<Article>().AddAsync(ar1);
            //await _dbContext.Set<Article>().AddAsync(ar2);
            //await _dbContext.Set<Article>().AddAsync(ar3);
            //await _dbContext.Set<Article>().AddAsync(ar4);
            //await _dbContext.SaveChangesAsync();

            var lst = await _dbContext.Set<Article>()
                .Include(c => c.Category)
                .ToListAsync();


            var data = await _dbContext.Set<Article>()
                .Where(q => q.CategoryId == 1)
                .Select(q => new { q.Id, q.Title }).ToListAsync();



            var data2 = from art in _dbContext.Set<Article>()
                        join cat in _dbContext.Set<Category>() on art.CategoryId equals cat.Id
                        where art.Id == 1
                        select art;
                        





            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
