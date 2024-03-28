
using WebAppReporting.Models;
using WebAppReporting.Models.EFModels;

namespace MoscowWeatherApp.Models
{
    public class CategoryViewModel
    {
        //public IEnumerable<> Users { get; }
        public IEnumerable<Category> List { get; }
        //public List<RakooEvents> Awdaw { get;}
        public PageViewModel PageViewModel { get; }


        public CategoryViewModel(IEnumerable<Category> list, PageViewModel viewModel)
        {
            //RakooClass.rakooMonthGlobal
            List = list;
            PageViewModel = viewModel;
        }
    }

    public class ExpenseViewModel
    {
        //public IEnumerable<> Users { get; }
        public IEnumerable<Expense> List { get; }
        //public List<RakooEvents> Awdaw { get;}
        public PageViewModel PageViewModel { get; }


        public ExpenseViewModel(IEnumerable<Expense> list, PageViewModel viewModel)
        {
            //RakooClass.rakooMonthGlobal
            List = list;
            PageViewModel = viewModel;
        }
    }
}
