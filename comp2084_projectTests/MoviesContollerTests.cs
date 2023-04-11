using comp2084_project.Controllers;
using comp2084_project.Data;
using comp2084_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace comp2084_projectTests
{
    [TestClass]
    public class MoviesContollerTests
    {
        private ApplicationDbContext _context;
        private MoviesController _controller;

        private Movie _movie;
       
        [TestInitialize]
        public void TestInitialize()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(dbOptions);

            _movie = new Movie
            {
                Id = 100,
                Title = "test",
                Director = "James. J",
                Description = "testing movie",
                Image = "testing image",
            };
            _context.Movie.Add(_movie);
            _controller = new MoviesController(_context);

        }

        [TestMethod]
        public async Task GetCreateView()
        {
            var result = (ViewResult)_controller.Create();

           Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public async Task GetCreateMovieIsNotNull()
        {
            var result = (ViewResult)_controller.Create();

            Assert.IsNotNull(result.ViewData["MovieId"]);
        }

        [TestMethod]
        public async Task GetCreateCinemaRoomIsNotNull()
        {
            var result = (ViewResult)_controller.Create();

            Assert.IsNotNull(result.ViewData["CinemaRoomId"]);
        }

        [TestMethod]
        public async Task PostCreateInvalidState()
        {
            var movie = CreateSomeMovie();

            _controller.ModelState.AddModelError("Name", "Invalid");

            var result = (ViewResult) await _controller.Create((Movie)movie, null);

            Assert.IsNull(result.ViewName);
            Assert.AreEqual(movie, result.Model);
        }

        private object CreateSomeMovie() => _movie = new Movie
        {
            Id = 100,
            Title = "test",
            Director = "James. J",
            Description = "testing movie",
            Image = "testing image",
        };
    }
}