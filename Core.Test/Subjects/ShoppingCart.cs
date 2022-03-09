using System;

namespace Applique.WhenGivenThen.Core.Test.Subjects
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public ShoppingCartItem[] Items { get; set; } = Array.Empty<ShoppingCartItem>();
    }
}