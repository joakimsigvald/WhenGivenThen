namespace Applique.WhenGivenThen.Core.Test.Subjects;

public class ShoppingService
{
    private readonly IOrderService _anotherService;

    public ShoppingService(IOrderService orderService)
        => _anotherService = orderService;

    public ShoppingCart CreateCart(int id)
        => new ShoppingCart { Id = id };

    public void PlaceOrder(ShoppingCart cart)
        => _anotherService.CreateOrder(cart);
}