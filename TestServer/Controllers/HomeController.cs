using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestServer.Classes;
using TestServer.Models;

namespace TestServer.Controllers
{
    public class HomeController : Controller
    {
        // контекст БД
        private readonly MovieContext _dbContext = new MovieContext();
       
        /// <summary>
        /// Открыть страницу
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                return View(_dbContext.Set<Movie>().OrderBy(r => r.Date).ToArray());
            }
            catch (Exception)
            {
                var movies = new List<Movie>();
                return View(movies);
            }
        }

        /// <summary>
        /// Добавление фильма
        /// </summary>
        /// <param name="date">Дата фильма</param>
        /// <param name="name">Название фильма</param>
        [HttpPost]
        public ActionResult AddMovie(DateTime date, string name)
        {
            try
            {
                var movie = new Movie {Date = date, Name = name};
                _dbContext.Set<Movie>().Add(movie);
                _dbContext.SaveChanges();
                return Json(new {result = 0});
            }
            catch (Exception exception)
            {
                return Json(new { result = 1, msg=exception.Message });
            }
        }

        /// <summary>
        /// Удаление фильма
        /// </summary>
        /// <param name="id">ИД фильма</param>
        [HttpPost]
        public ActionResult RemoveMovie(int id)
        {
            try
            {
                var movie = _dbContext.Set<Movie>().SingleOrDefault(r => r.Id == id);
                if (movie == null)
                {
                    throw new Exception("Фильм не найден");
                }
                if (movie.TicketCount > 0)
                {
                    throw new Exception("На фильм уже проданы билеты");
                }
                _dbContext.Set<Movie>().Remove(movie);
                _dbContext.SaveChanges();
                return Json(new { result = 0 });
            }
            catch (Exception exception)
            {
                return Json(new { result = 1, msg = exception.Message });
            }
        }

        /// <summary>
        /// Очистка использованных объектов
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}