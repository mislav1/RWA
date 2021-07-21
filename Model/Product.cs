using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public string MinimumAmount { get; set; }
        public double PriceWithoutPDV { get; set; }
        public int SubCategoryId { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
