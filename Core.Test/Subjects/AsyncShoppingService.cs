using System.Linq;
using System.Threading.Tasks;

namespace Applique.WhenGivenThen.Core.Test.Subjects
{
    public class AsyncShoppingService
    {
        private readonly IOrderService _orderService;
        private readonly IShoppingCartRepository _repository;

        public AsyncShoppingService(IOrderService orderService, IShoppingCartRepository repository)
            => (_orderService, _repository) = (orderService, repository);

        public Task<ShoppingCart> CreateCart(int id)
            => Task.FromResult(new ShoppingCart { Id = id });

        public async Task<ShoppingCart> AddToCartCart(int cartId, ShoppingCartItem item)
        {
            var cart = await _repository.GetCart(cartId);
            var res = new ShoppingCart
            {
                Id = cart.Id,
                Items = cart.Items.Append(item).ToArray()
            };
            await _repository.StoreCart(res);
            return res;
        }

        public Task PlaceOrder(ShoppingCart aMessage)
            => Task.Run(() => _orderService.CreateOrder(aMessage));
    }
}
