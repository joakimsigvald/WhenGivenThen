using System.Linq;
using System.Threading.Tasks;

namespace Joakimsigvald.WhenGivenThen.Test.Subjects;

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

    public Task PlaceOrder(ShoppingCart cart)
        => cart.IsOpen ? Task.Run(() => _orderService.CreateOrder(cart)) : throw new NotPurcheable();
}
