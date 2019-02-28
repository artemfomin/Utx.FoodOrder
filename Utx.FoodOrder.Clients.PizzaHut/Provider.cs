using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utx.FoodOrder.Clients.BaseClient;

namespace Utx.FoodOrder.Clients.PizzaHut
{
    public class Provider : BaseClient<PizzaHutProduct>
    {
        public Provider() : base("https://mcdonalds.ru") { }

        public override IList<IProduct> GetAvailableProducts()
        {
            return new List<IProduct>
            {
                new PizzaHutProduct { Name = "Pizza", Price = 15 },
                new PizzaHutProduct { Name = "Hamburger", Price = 6 },
                new PizzaHutProduct { Name = "Spaghetti", Price = 8 },
                new PizzaHutProduct { Name = "Chicken wings", Price = 6 },
                new PizzaHutProduct { Name = "Salad", Price = 4 },
            };
        }

        public override bool PlaceOrder(IList<IProduct> order)
        {
            return true;
        }
    }
}
