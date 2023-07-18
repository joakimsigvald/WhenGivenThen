namespace WhenGivenThen.Test.Subjects;

public class ShoppingService
{
    private readonly IOrderService _orderService;
    private readonly ILogger _logger;
    private readonly string _shopName;
    private readonly string _division;

    public ShoppingService(IOrderService orderService, ILogger logger, (string shop, string division) names)
    {
        _orderService = orderService;
        _logger = logger;
        _shopName = names.shop;
        _division = names.division;
    }

    public ShoppingCart CreateCart(int id) => new() { Id = id };

    public void PlaceOrder(ShoppingCart cart)
    {
        _orderService.CreateOrder(cart);
        _logger.ForContext("CartId", cart.Id).Information($"{_shopName}:{_division} created order");
    }
}