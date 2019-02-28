using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utx.FoodOrder.Enums;

namespace Utx.FoodOrder.Models
{
    public class FoodModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public FoodProviders Provider { get; set; }
    }
}
