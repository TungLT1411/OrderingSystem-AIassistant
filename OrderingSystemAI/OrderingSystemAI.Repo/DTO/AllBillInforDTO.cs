using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystemAI.Repo.DTO
{
    public class AllBillInforDTO
    {
        public int Id { get; set; }
        public int? BillId { get; set; }
        public string? FoodName { get; set; }
        public decimal? FoodPrice { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateTime { get; set; }
    }
}
