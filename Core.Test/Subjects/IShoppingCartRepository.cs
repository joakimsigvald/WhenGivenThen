using System.Threading.Tasks;

namespace Applique.GivenWhenThen.Core.Test.Subjects
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetCart(int id);
        Task StoreCart(ShoppingCart cart);
    }
}
