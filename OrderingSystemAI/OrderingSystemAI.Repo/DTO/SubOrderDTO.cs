using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystemAI.Repo.DTO
{
    public class SubOrderDTO
    {
        private static SubOrderDTO instance = null;

        // Khai báo private constructor để ngăn việc tạo đối tượng từ bên ngoài lớp
        private SubOrderDTO() { }

        // Property để truy cập đối tượng singleton
        public static SubOrderDTO Instance
        {
            get
            {
                // Nếu đối tượng chưa được tạo, tạo mới và trả về
                if (instance == null)
                {
                    instance = new SubOrderDTO();
                }
                return instance;
            }
        }

        // Các thuộc tính để lưu trữ thông tin tạm thời
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public int Quantity { get; set; }
        public string ImagePathh { get; set; }
        public int BillId { get; set; }
        // Các thuộc tính khác nếu cần thiết
    }
}
