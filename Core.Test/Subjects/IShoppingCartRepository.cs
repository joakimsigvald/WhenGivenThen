using System.Threading.Tasks;

namespace WhenGivenThen.Test.Subjects;

public interface IShoppingCartRepository
{
    Task<ShoppingCart> GetCart(int id);
    Task StoreCart(ShoppingCart cart);
}