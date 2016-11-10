using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TestServer.Classes;
using TestServer.Models;

namespace TestServer.Controllers
{
    public class TicketsController : ApiController
    {
        // контекст БД
        readonly MovieContext _dbContext = new MovieContext();

        // вместимость зала
        private const int HallCapasity = 100;

        /// <summary>
        /// Оплата билетов
        /// </summary>
        /// <param name="ticket">Данные о количестве оплачиваемых билетов</param>
        [ResponseType(typeof(void))]
        public string PostTicketPay(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return "Ошибка";
            }
            ticket.Date = DateTime.Now;

            var movie = _dbContext.Set<Movie>().Find(ticket.MovieId);
            if (movie == null) return "Фильм не найден";
            if (movie.TicketCount + ticket.Count > HallCapasity) return "Невозможно продать указанное количество";
            _dbContext.Set<Ticket>().Add(ticket);
            _dbContext.SaveChanges();
            return "Билеты оплачены";
        }

        /// <summary>
        /// Запрос количества свободных билетов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetTicketCount(int id)
        {
            var movie = _dbContext.Set<Movie>().SingleOrDefault(r=>r.Id == id);
            if (movie == null) return 0;
            return HallCapasity - movie.TicketCount;
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