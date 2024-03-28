using Microsoft.EntityFrameworkCore;
using WebAppReporting.Models.EFContext;
using WebAppReporting.Models.EFModels;

namespace WebAppReporting.Controllers.MyFuncs
{
    public class Funcs
    {

        public static void Initialize(ApplicationContext context)
        {
            

            // Проверяем, есть ли уже категории расходов
            if (!context.Category.Any())
            {
                // Создаем категории расходов и добавляем их в базу данных
                var categories = new Category[]
                {
                new Category { Name = "Transport" },
                new Category { Name = "Mobile Connection" },
                new Category { Name = "Internet" },
                new Category { Name = "Games" }
                };

                foreach (var category in categories)
                {
                    context.Category.Add(category);
                }

                context.SaveChanges();
            }

            // Проверяем, есть ли уже записи о расходах
            if (!context.Expense.Any())
            {
                var expenses = new Expense[]
                {
                    // Примеры расходов на транспорт
                    new Expense { Amount = 100, Date = DateTime.UtcNow, CategoryId = 1, Comment = "Volvo expense" },
                    new Expense { Amount = 150, Date = DateTime.UtcNow.AddDays(-2), CategoryId = 1, Comment = "Audi expense" },
                    new Expense { Amount = 200, Date = DateTime.UtcNow.AddDays(-6), CategoryId = 1, Comment = "BMW expense" },
                    new Expense { Amount = 120, Date = DateTime.UtcNow.AddDays(-8), CategoryId = 1, Comment = "Nissan expense" },
                    new Expense { Amount = 80, Date = DateTime.UtcNow.AddDays(-32), CategoryId = 1, Comment = "Renault expense" },

                    // Примеры расходов на мобильную связь
                    new Expense { Amount = 25, Date = DateTime.UtcNow.AddDays(-45), CategoryId = 2, Comment = "Mobile plan 1 expense" },
                    new Expense { Amount = 30, Date = DateTime.UtcNow.AddDays(-5), CategoryId = 2, Comment = "Mobile plan 2 expense" },
                    new Expense { Amount = 40, Date = DateTime.UtcNow.AddDays(-23), CategoryId = 2, Comment = "Mobile plan 3 expense" },
                    new Expense { Amount = 20, Date = DateTime.UtcNow.AddDays(-43), CategoryId = 2, Comment = "Mobile plan 4 expense" },
                    new Expense { Amount = 35, Date = DateTime.UtcNow.AddDays(-56), CategoryId = 2, Comment = "Mobile plan 5 expense" },

                    // Примеры расходов на интернет
                    new Expense { Amount = 50, Date = DateTime.UtcNow.AddDays(-12), CategoryId = 3, Comment = "Internet plan 1 expense" },
                    new Expense { Amount = 60, Date = DateTime.UtcNow.AddDays(-5), CategoryId = 3, Comment = "Internet plan 2 expense" },
                    new Expense { Amount = 70, Date = DateTime.UtcNow.AddDays(-24), CategoryId = 3, Comment = "Internet plan 3 expense" },
                    new Expense { Amount = 80, Date = DateTime.UtcNow.AddDays(-31), CategoryId = 3, Comment = "Internet plan 4 expense" },
                    new Expense { Amount = 90, Date = DateTime.UtcNow.AddDays(-6), CategoryId = 3, Comment = "Internet plan 5 expense" },

                    // Примеры расходов на развлечения
                    new Expense { Amount = 40, Date = DateTime.UtcNow.AddDays(-2), CategoryId = 4, Comment = "Game 1 expense" },
                    new Expense { Amount = 60, Date = DateTime.UtcNow.AddDays(-7), CategoryId = 4, Comment = "Game 2 expense" },
                    new Expense { Amount = 35, Date = DateTime.UtcNow.AddDays(-4), CategoryId = 4, Comment = "Game 3 expense" },
                    new Expense { Amount = 45, Date = DateTime.UtcNow.AddDays(-3), CategoryId = 4, Comment = "Game 4 expense" },
                    new Expense { Amount = 55, Date = DateTime.UtcNow.AddDays(-14), CategoryId = 4, Comment = "Game 5 expense" }
                };
                foreach (var expense in expenses)
                {
                    context.Expense.Add(expense);
                }

                context.SaveChanges();
            }
        }
    }
}
