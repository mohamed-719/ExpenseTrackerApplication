using AppNtier.Entities.Models;
using ExpenseTracker.Entities.Interface;
using ExpenseTracker.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Client.Controllers
{
    public class CategoryController : Controller
    {
        private  IRepository<Category> _repositoryCateory;
        private IRepository<TransactionOf> _transactionCateory;

        public CategoryController(IRepository<Category> repositoryCateory, IRepository<TransactionOf> transactionCateory)
        {
            _repositoryCateory = repositoryCateory;
            _transactionCateory = transactionCateory;
        }
        public IActionResult Index()
        {
            var category = _repositoryCateory.GetAll();
            return View(category);
        }
    }
}
