using eMovieTickets.Data.Base;
using eMovieTickets.Models;

namespace eMovieTickets.Data.Services
{
    public class ProducersService: EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
                
        }
    }
}
