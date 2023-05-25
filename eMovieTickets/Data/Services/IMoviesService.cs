using eMovieTickets.Data.Base;
using eMovieTickets.Data.ViewModels;
using eMovieTickets.Models;

namespace eMovieTickets.Data.Services
{
    public interface IMoviesService: IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVm> GetNewMovieDropdownsValue();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);

    }
}
