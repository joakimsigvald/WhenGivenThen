using System;

namespace Applique.GivenWhenThen.Core.Test.Subjects
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public ShoppingCartItem[] Items { get; set; } = Array.Empty<ShoppingCartItem>();
    }
}