using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utx.FoodOrder.Clients.BaseClient;

namespace Utx.FoodOrder.Clients.McDonalds
{
    public class Provider : BaseClient<McDonaldsProduct>
    {
        public Provider() : base("https://mcdonalds.ru") { }

        public override IList<IProduct> GetAvailableProducts()
        {
            return new List<IProduct>
            {
                new McDonaldsProduct { Name = "Hamburger", Price = 2 },
                new McDonaldsProduct { Name = "Salad", Price = 5 },
            };
        }

        public override bool PlaceOrder(IList<IProduct> order)
        {
            return true;
        }
    }
}
