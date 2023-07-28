using Microsoft.EntityFrameworkCore;
using OrderingSystemAI.Repo.DTO;
using OrderingSystemAI.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystemAI.Repo.Repo
{
    public interface IBillDetailRepo
    {
        ICollection<BillDetailDTO> GetList();
        bool addBillDetail(BillDetail billDetail);
        ICollection<AllBillInforDTO> GetBillByID(int id);
    }
    public class BillDetailRepo : IBillDetailRepo
    {
        private readonly OrderingSystemAiContext _context;
        public BillDetailRepo()
        {
            _context = new OrderingSystemAiContext(); 
        }

        public ICollection<BillDetailDTO> GetList()
        {
            return _context.BillDetails.Where(e=>e.BillId == SubOrderDTO.Instance.BillId).Select(b => new BillDetailDTO
            {
                FoodName = b.FoodName,
                FoodPrice = b.FoodPrice,
                Quantity = b.Quantity,
            }).ToList();
        }

        public bool addBillDetail(BillDetail billDetail)
        {
            _context.BillDetails.Add(billDetail);
            return _context.SaveChanges() >0 ? true : false;
        }

        public ICollection<AllBillInforDTO> GetBillByID(int id)
        {
            return _context.BillDetails.Include(e => e.Bill).Select(bill => new AllBillInforDTO
            {
                BillId = bill.Bill.Id,
                CreateDate = bill.Bill.CreateDate,
                CreateTime = bill.Bill.CreateTime,
                FoodName = bill.FoodName,
                FoodPrice = bill.FoodPrice,
                Quantity = bill.Quantity

            }).Where(e=>e.BillId ==id).ToList();
        }
    }
}
