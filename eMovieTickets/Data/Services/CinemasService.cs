using eMovieTickets.Data.Base;
using eMovieTickets.Models;

namespace eMovieTickets.Data.Services
{
    public class CinemasService: EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context): base(context)
        {

        }
    }
}
