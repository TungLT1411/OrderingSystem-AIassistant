using OrderingSystemAI.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystemAI.Repo.Repo
{
    public interface IBillRepo
    {
         //ICollection<Bill> ListAllBillById();  
         Bill ListBillById(int id);  
         bool addBill(Bill bill);
         bool update(int id ,decimal totalPrice);
    }
    public class BillRepo : IBillRepo
    {
        private readonly OrderingSystemAiContext _context;
        public BillRepo()
        {
            _context = new OrderingSystemAiContext();
        }

        public bool addBill(Bill bill)
        {
            _context.Bills.Add(bill);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool update(int id,decimal totalPrice)
        {
            try
            {
                var existingBill = _context.Bills.FirstOrDefault(e => e.Id == id);
                if (existingBill != null)
                {
                    existingBill.TotalPrice = totalPrice;
                    existingBill.CreateTime = DateTime.Now.ToString("hh:mm:ss");

                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false; // Cập nhật thất bại
            }
        }

        public Bill ListBillById(int id)
        {
            return _context.Bills.FirstOrDefault(e => e.Id == id);
        }
    }
}
