using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is required")]
        [Display(Name ="Book Title"), MinLength(2,ErrorMessage ="Minimun lenght is 2 chars")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }
        [Required(ErrorMessage ="Price is required")]
        [DataType(DataType.Currency, ErrorMessage ="Please enter correct price")]
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
