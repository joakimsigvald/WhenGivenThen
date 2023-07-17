namespace WhenGivenThen.Test.Subjects;

public class ShoppingService
{
    private readonly IOrderService _orderService;
    private readonly ILogger _logger;

    public ShoppingService(IOrderService orderService, ILogger logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

    public ShoppingCart CreateCart(int id) => new() { Id = id };

    public void PlaceOrder(ShoppingCart cart)
    {
        _orderService.CreateOrder(cart);
        _logger.ForContext("CartId", cart.Id).Information("Order created");
    }
}