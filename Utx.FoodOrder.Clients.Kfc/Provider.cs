using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utx.FoodOrder.Clients.BaseClient;

namespace Utx.FoodOrder.Clients.Kfc
{
    public class Provider : BaseClient<KfcProduct>
    {
        public Provider() : base("https://kfc.ru") { }

        public override IList<IProduct> GetAvailableProducts()
        {
            return new List<IProduct>
            {
                new KfcProduct { Name = "Hamburger", Price = 5 },
                new KfcProduct { Name = "Chicken wings", Price = 4 },
                new KfcProduct { Name = "Salad", Price = 5 },
            };
        }

        public override bool PlaceOrder(IList<IProduct> order)
        {
            return true;
        }
    }
}
