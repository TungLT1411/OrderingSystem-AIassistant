using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystemAI.Repo.DTO
{
    public class OrderDTO
    {
        public string? FoodName { get; set; }

        public decimal? FoodPrice { get; set; }

        public int? Quantity { get; set; }
    }
}
