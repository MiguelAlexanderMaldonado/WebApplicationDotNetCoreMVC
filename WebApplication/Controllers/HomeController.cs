using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.ViewModel;

namespace WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        #region Variables

        private IRepository<Book> bookRepo;
        private IRepository<Carousel> carouselRepo;

        #endregion Variables

        #region Public methods

        public HomeController(IRepository<Book> books, IRepository<Carousel> carousels) : base()
        {
            this.bookRepo = books;
            this.carouselRepo = carousels;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                Books = this.bookRepo.GetAll(),
                Carousels = this.carouselRepo.GetAll()
            };
            return View(model);
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

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                Book item = new Book()
                {
                    Id = this.bookRepo.GetAll().Max(m => m.Id) + 1,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    PublishDate = book.PublishDate,
                    Price = book.Price,
                    Image = book.Image
                };
                this.bookRepo.Add(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion Public methods
    }
}
