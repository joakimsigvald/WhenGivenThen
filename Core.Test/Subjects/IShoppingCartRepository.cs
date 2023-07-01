using System.Threading.Tasks;

namespace Joakimsigvald.WhenGivenThen.Test.Subjects;

public interface IShoppingCartRepository
{
    Task<ShoppingCart> GetCart(int id);
    Task StoreCart(ShoppingCart cart);
}