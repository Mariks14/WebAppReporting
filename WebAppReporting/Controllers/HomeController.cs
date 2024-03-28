using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoscowWeatherApp.Models;
using System.Diagnostics;
using WebAppReporting.Controllers.MyFuncs;
using WebAppReporting.Models;
using WebAppReporting.Models.EFContext;
using WebAppReporting.Models.EFModels;

namespace WebAppReporting.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private ApplicationContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            

            return View();
        }

        public async Task<IActionResult> Category(int page = 1)
        {


            Funcs.Initialize(_context);



            int pageSize = 3;   // количество элементов на странице

            IQueryable<Category> source = _context.Category;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            CategoryViewModel viewModel = new CategoryViewModel(items, pageViewModel);
            

            return View(viewModel);
        }

        public async Task<IActionResult> Expense(string category, int page = 1)
        {
            

            ViewBag.Category = category;
            Funcs.Initialize(_context);

            int pageSize = 4;   // количество элементов на странице
            IQueryable<Expense> source = _context.Expense;
            if (!string.IsNullOrEmpty(category))
            {
                source = _context.Expense.Where(e => e.Category.Name == category);
            }
            
            
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ExpenseViewModel viewModel = new ExpenseViewModel(items, pageViewModel);

            return View(viewModel);
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
