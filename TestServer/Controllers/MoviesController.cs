using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestServer.Classes;
using TestServer.Models;

namespace TestServer.Controllers
{
    public class MoviesController : ApiController
    {
        // контекст БД
        readonly MovieContext _dbContext = new MovieContext();

        /// <summary>
        /// Получение списка фильмов
        /// </summary>
        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Set<Movie>().Where(r => r.Date > DateTime.Now).ToArray();
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