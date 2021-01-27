using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class MockCarouselRepository : IRepository<Carousel>
    {
        #region Variables

        List<Carousel> carousels;

        #endregion Variables

        #region Public methods

        public MockCarouselRepository()
        {
            this.carousels = new List<Carousel>()
            { 
                new Carousel()
                {
                    Id = 0,
                    Title = "Clean Code",
                    Description = "A Handbook of Agile Software Craftsmanship",
                    ImageURL = "CleanCode.jpg"
                },
                new Carousel()
                {
                    Id = 1,
                    Title = "Software Engineering for Science",
                    Description = "Computational Science Series",
                    ImageURL = "SoftwareEngineeringForScience.jpg"
                },
                new Carousel()
                {
                    Id = 3,
                    Title = "Software Engineering",
                    Description = "Second Edition",
                    ImageURL = "SoftwareEngineering.jpg"
                }
            };
        }

        public bool Add(Carousel item)
        {
            try
            {
                Carousel carousel = item;
                carousel.Id = this.carousels.Max(x => x.Id) + 1;
                this.carousels.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Carousel item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Carousel item)
        {
            throw new NotImplementedException();
        }

        public Carousel Get(int id)
        {
            return this.carousels.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Carousel> GetAll()
        {
            return this.carousels.ToList();
        }

        #endregion Public methods
    }
}
