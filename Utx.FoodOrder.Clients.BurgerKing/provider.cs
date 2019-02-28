using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utx.FoodOrder.Clients.BaseClient;

namespace Utx.FoodOrder.Clients.BurgerKing
{
    public class Provider : BaseClient<BurgerKingProduct>
    {
        public Provider() : base("https://burgerking.ru") { }

        public override IList<IProduct> GetAvailableProducts()
        {            
            return new List<IProduct>
            {
                new BurgerKingProduct { Name = "Hamburger", Price = 4 },
                new BurgerKingProduct { Name = "Spaghetti", Price = 8 },
                new BurgerKingProduct { Name = "Chicken wings", Price = 5 },
                new BurgerKingProduct { Name = "Salad", Price = 5 },
            };
        }

        public override bool PlaceOrder(IList<IProduct> order)
        {
            return true;
        }
    }
}
