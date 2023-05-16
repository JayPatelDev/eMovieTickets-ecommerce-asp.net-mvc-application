using eMovieTickets.Data.Base;
using eMovieTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovieTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        //private readonly AppDbContext _context;
        public ActorsService(AppDbContext context) : base(context) { }

    }
}
