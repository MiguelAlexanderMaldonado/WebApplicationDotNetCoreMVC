using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Carousel> Carousels { get; set; }
    }
}
