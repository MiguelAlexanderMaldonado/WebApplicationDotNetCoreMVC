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
                    Title = "JavaScript and JSON Essentials",
                    Description = "Use JSON for building web applicaitons with technologies like HTML, ",
                    Author = "Bruno Joseph D'mello, Sai Srinivas Sriparasa",
                    PublishDate = "April 2018",
                    Price = 30,
                    Image = "img0"
                },
                new Book()
                {
                    Id = 1,
                    Title = "Beginning C# 7 Hands-On - The Core Lenguage",
                    Description = "A C# 7 beginners guide to the core parts of the C# lenguage!",
                    Author = "Tom Owsiak",
                    PublishDate = "August 2017",
                    Price = 39.99,
                    Image = "img1"
                },
                new Book()
                {
                    Id = 2,
                    Title = ".NET Core 2.0 By Example",
                    Description = "Build cross-platform solutions with .NET Core 2.0 htrough real-life scenarios",
                    Author = "Rishabh Verma, Neha Shrivastava",
                    PublishDate = "March 2018",
                    Price = 30,
                    Image = "img2"
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
