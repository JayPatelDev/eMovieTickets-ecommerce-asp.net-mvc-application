using eMovieTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovieTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context) {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetRequiredService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId= cartId };
        }

        public async Task AddItemToCart(Movie movie)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
               if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }

                
            }
            await _context.SaveChangesAsync();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n=> n.ShoppingCartId == ShoppingCartId).Select(n=> n.Movie.Price * n.Amount).Sum();

        public async Task ClearShoppingCartAsyc()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

    }
}
