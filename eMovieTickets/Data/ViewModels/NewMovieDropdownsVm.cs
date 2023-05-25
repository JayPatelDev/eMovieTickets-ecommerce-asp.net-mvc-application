using eMovieTickets.Models;

namespace eMovieTickets.Data.ViewModels
{
    public class NewMovieDropdownsVm
    {
        public NewMovieDropdownsVm()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors= new List<Actor>();
        }
        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
