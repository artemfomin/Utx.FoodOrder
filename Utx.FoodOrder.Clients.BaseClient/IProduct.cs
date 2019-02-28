using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utx.FoodOrder.Clients.BaseClient
{
    public interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
    }
}
