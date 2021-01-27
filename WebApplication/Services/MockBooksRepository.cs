using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class MockBooksRepository : IRepository<Book>
    {
        #region Variables

        private List<Book> books;

        #endregion Variables

        #region Public methods

        public MockBooksRepository()
        {
            this.books = new List<Book>()
            {
                new Book()
                {
                    Id = 0,
                    Title = "Clean Code",
                    Description = "A Handbook of Agile Software Craftsmanship",
                    Author = "Robert C. Martin",
                    PublishDate = "April 2018",
                    Price = 30,
                    Image = "CleanCode.jpg"
                },
                new Book()
                {
                    Id = 1,
                    Title = "Software Engineering for Science",
                    Description = "Computational Science Series",
                    Author = "Jeffrey C. Carver, Neil P. Chue Hong",
                    PublishDate = "August 2017",
                    Price = 39.99,
                    Image = "SoftwareEngineeringForScience.jpg"
                },
                new Book()
                {
                    Id = 2,
                    Title = "Software Engineering",
                    Description = "Second Edition",
                    Author = "Ronald J. Leach",
                    PublishDate = "March 2018",
                    Price = 30,
                    Image = "SoftwareEngineering.jpg"
                },
                new Book()
                {
                    Id = 3,
                    Title = "Software Engineering for Science",
                    Description = "Computational Science Series",
                    Author = "Jeffrey C. Carver, Neil P. Chue Hong",
                    PublishDate = "August 2017",
                    Price = 39.99,
                    Image = "SoftwareEngineeringForScience.jpg"
                },
                new Book()
                {
                    Id = 4,
                    Title = "Software Engineering",
                    Description = "Second Edition",
                    Author = "Ronald J. Leach",
                    PublishDate = "March 2018",
                    Price = 30,
                    Image = "SoftwareEngineering.jpg"
                },
                new Book()
                {
                    Id = 5,
                    Title = "Software Engineering",
                    Description = "Second Edition",
                    Author = "Ronald J. Leach",
                    PublishDate = "March 2018",
                    Price = 30,
                    Image = "SoftwareEngineering.jpg"
                },
                new Book()
                {
                    Id = 6,
                    Title = "Software Engineering for Science",
                    Description = "Computational Science Series",
                    Author = "Jeffrey C. Carver, Neil P. Chue Hong",
                    PublishDate = "August 2017",
                    Price = 39.99,
                    Image = "SoftwareEngineeringForScience.jpg"
                },
                new Book()
                {
                    Id = 7,
                    Title = "Software Engineering",
                    Description = "Second Edition",
                    Author = "Ronald J. Leach",
                    PublishDate = "March 2018",
                    Price = 30,
                    Image = "SoftwareEngineering.jpg"
                }
            };
        }

        public bool Add(Book item)
        {
            try
            {
                Book book = item;
                book.Id = this.books.Max(x => x.Id) + 1;
                this.books.Add(item);
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public bool Delete(Book item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Book item)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            return this.books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return this.books.ToList();
        }

        #endregion Public methods
    }
}
