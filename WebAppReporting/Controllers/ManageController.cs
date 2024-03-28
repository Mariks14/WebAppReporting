using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppReporting.Models.EFContext;
using WebAppReporting.Models.EFModels;

namespace WebAppReporting.Controllers
{
    //[Authorize]
    public class ManageController : Controller
    {
        private ApplicationContext _context;
        private readonly ILogger<HomeController> _logger;

        public ManageController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(List<string> categoryName)
        {

            foreach (var c in categoryName)
            {
                var newCategory = new Category { Name = c };
                _context.Category.Add(newCategory);             // добавляем категорию
            }

            _context.SaveChanges();

            return RedirectToAction("Category", "Home");
        }

        
        [HttpGet]
        public IActionResult UpdateOrDeleteCategory(string id)
        {
            Category takeCategory = _context.Category.Where(c => c.Id == int.Parse(id)).FirstOrDefault(); // берем категорию по id (id);
            //ViewBag.Category = takeCategory;

            return View(takeCategory);
        }

        [HttpPost]
        public IActionResult UpdateOrDeleteCategory(string id, string name)
        {
            //Console.WriteLine(id + " " + name);

            Category takeCategory = _context.Category.Where(c => c.Id == int.Parse(id)).FirstOrDefault();
            takeCategory.Name = name;

            _context.Update(takeCategory);
            _context.SaveChanges();                 // обновляем категорию


            return RedirectToAction("Category", "Home");
        }

        [HttpPost]
        public IActionResult DeleteCategory(string id, string name)
        {
            //Console.WriteLine("delete category" +id + " " + name);

            Category takeCategory = _context.Category.Where(c => c.Id == int.Parse(id)).FirstOrDefault();

            _context.Remove(takeCategory);
            _context.SaveChanges();               // удаляем категорию


            return RedirectToAction("Category", "Home");
        }


        [HttpGet]
        public IActionResult AddExpense()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExpense( List<Expense> expenses)
        {
            //foreach (var expense in expenses)
            //{
            //    Console.WriteLine(expense.Id + " " + expense.CategoryId + " " + expense.Amount + " " + expense.Date + " " + expense.Comment);
            //}

            foreach (var c in expenses)
            {
                var newExpense = new Expense { Amount = c.Amount, CategoryId = c.CategoryId, Date = c.Date, Comment = c.Comment };
                _context.Expense.Add(newExpense);             // добавляем Expense
            }

            _context.SaveChanges();

            return RedirectToAction("Expense", "Home");
        }

        [HttpGet]
        public IActionResult UpdateOrDeleteExpense(string id)
        {
            Expense takeExpense = _context.Expense.Where(c => c.Id == int.Parse(id)).FirstOrDefault(); // берем Expense по id (id);
            

            return View(takeExpense);
        }

        [HttpPost]
        public IActionResult UpdateOrDeleteExpense(string id, int Amount, string CategoryId, DateTime Date, string Comment)
        {
            //Console.WriteLine(id + " " + Amount + " " + CategoryId + " " + Date + " " + Comment);

            Expense takeExpense = _context.Expense.Where(c => c.Id == int.Parse(id)).FirstOrDefault();

            takeExpense.Amount = Amount;
            takeExpense.CategoryId = int.Parse(CategoryId);
            takeExpense.Date = Date;
            takeExpense.Comment = Comment;

            _context.Update(takeExpense);
            _context.SaveChanges();                 // обновляем Expense

            return RedirectToAction("Expense", "Home");
        }

        [HttpPost]
        public IActionResult DeleteExpense(string id)
        {
            

            Expense takeExpense = _context.Expense.Where(c => c.Id == int.Parse(id)).FirstOrDefault();

            _context.Remove(takeExpense);
            _context.SaveChanges();               // удаляем категорию


            return RedirectToAction("Expense", "Home");
        }
    }
}
