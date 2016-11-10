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
        // �������� ��
        readonly MovieContext _dbContext = new MovieContext();

        /// <summary>
        /// ��������� ������ �������
        /// </summary>
        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Set<Movie>().Where(r => r.Date > DateTime.Now).ToArray();
        }

        /// <summary>
        /// ������� �������������� ��������
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