using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utx.FoodOrder.Clients.BaseClient;

namespace Utx.FoodOrder.Clients.McDonalds
{
    public class McDonaldsProduct : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
