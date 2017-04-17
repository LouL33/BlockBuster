using Blockbuster.Models;
using Blockbuster.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Controllers
{
    public class MovieController : Controller
    {
        MovieService movieService = new MovieService();

        // GET: Movie
        public ActionResult Index()
        {
            var Movies = new MovieService().GetAllMovies();
            return View(Movies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var movie = new Movie();
            UpdateModel(movie);
            var newMovie = new MovieService().CreateMovie(movie);
            return RedirectToAction("Index");
        }

    }
}