using OrderingSystemAI.Repo.DTO;
using OrderingSystemAI.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystemAI.Repo.Repo
{
    public interface ISubOrderRepo
    {
        ICollection<OrderDTO> GetList();
        bool addBillDetail(SubOrder subOrder);
        bool removeAllSubOrder();
    }
    public class SubOrderRepo : ISubOrderRepo
    {
        private readonly OrderingSystemAiContext _context;
        public SubOrderRepo()
        {
            _context = new OrderingSystemAiContext();
        }

        public ICollection<OrderDTO> GetList()
        {
            return _context.SubOrders.Select(b => new OrderDTO
            {
                FoodName = b.FoodName,
                FoodPrice = b.FoodPrice,
                Quantity = b.Quantity,
            }).ToList();
        }

        public bool addBillDetail(SubOrder subOrder)
        {
            _context.SubOrders.Add(subOrder);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool removeAllSubOrder()
        {
            var ListAll = _context.SubOrders.ToList();

            foreach (var subOrder in ListAll)
            {
                _context.SubOrders.Remove(subOrder);
            }
            return _context.SaveChanges() >0 ? true : false;    
        }
    }
}
