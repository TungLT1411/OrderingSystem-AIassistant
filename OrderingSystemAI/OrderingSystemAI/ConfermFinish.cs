using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using OrderingSystemAI.Repo.DTO;
using OrderingSystemAI.Repo.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderingSystemAI
{
    public partial class ConfermFinish : Form
    {
        private readonly IBillDetailRepo _billDetailRepo = new BillDetailRepo();
        private readonly ISubOrderRepo _subOrderRepo = new SubOrderRepo();
        private readonly IBillRepo _billRepo = new BillRepo();
        private BindingSource _source;

        public ConfermFinish()
        {
            InitializeComponent();
        }

        private void ConfermFinish_Load(object sender, EventArgs e)
        {
            SendDataToGoogleSheet(SubOrderDTO.Instance.BillId);
            if (_subOrderRepo.removeAllSubOrder())
            {
                var ListOrder = _billDetailRepo.GetList();
                _source = new BindingSource();
                _source.DataSource = ListOrder;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _source;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Tự động điều chỉnh độ rộng của tất cả các cột dựa trên nội dung

                textBox1.Text = "TOTAL PRICE: " + caculateBill().ToString();
            }

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

            

        }

        private decimal caculateBill()
        {
            var ListOrder = _billDetailRepo.GetList();
            decimal totalBill = 0;

            if (ListOrder != null && ListOrder.Any())
            {
                foreach (var item in ListOrder)
                {
                    totalBill += (decimal)(item.FoodPrice * item.Quantity);
                }
            }
            else
            {
                totalBill = 0;
            }
            return totalBill;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var currentBill = _billRepo.ListBillById(SubOrderDTO.Instance.BillId);
            var ListBillDetail = _billDetailRepo.GetList();
            e.Graphics.DrawString("Phương's Fast Food MiniStore", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(185, 30));
            e.Graphics.DrawString("BILL ORDER", new Font("Arial", 20, FontStyle.Bold), Brushes.Red, new Point(300, 100));
            e.Graphics.DrawLine(Pens.Black, 0, 0, this.ClientSize.Width, 0);
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------",
                new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 150));

            e.Graphics.DrawString("Date: " + currentBill.CreateDate.ToString(), new Font("Arial", 15 ), Brushes.Black, new Point(25, 170));
            e.Graphics.DrawString("Time: " + currentBill.CreateTime.ToString(), new Font("Arial", 15), Brushes.Black, new Point(500, 170));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------",
                new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 190));

            e.Graphics.DrawString("Item Name ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(60, 280));         
            e.Graphics.DrawString("Item Price ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(350, 280));
            e.Graphics.DrawString("Quantity ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, 280));
            e.Graphics.DrawString("Total Price", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 280));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------",
               new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, 310));

            int yPos = 340;
            for(int i=0; i < ListBillDetail.Count; i++)
            {
                var IndexBill = ListBillDetail.ToList()[i];
                e.Graphics.DrawString(IndexBill.FoodName, new Font("Arial", 12), Brushes.Black, new Point(60, yPos));
                e.Graphics.DrawString(IndexBill.FoodPrice.ToString(), new Font("Arial", 12), Brushes.Black, new Point(350, yPos));
                e.Graphics.DrawString(IndexBill.Quantity.ToString(), new Font("Arial", 12), Brushes.Black, new Point(500, yPos));
                e.Graphics.DrawString((IndexBill.Quantity * IndexBill.FoodPrice).ToString(), new Font("Arial", 12), Brushes.Black, new Point(600, yPos));
                yPos += 30;
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------- ",
               new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, yPos+50));

            e.Graphics.DrawString("Total Amount:  ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, yPos + 100));
            e.Graphics.DrawString(currentBill.TotalPrice.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(650, yPos + 100));
            e.Graphics.DrawString("Tax(VAT):  ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, yPos + 130));
            e.Graphics.DrawString("0", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(650, yPos + 130));
            e.Graphics.DrawString("---------------------------------------", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, yPos + 150));
            e.Graphics.DrawString("Total Pay:  ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, yPos + 180));
            e.Graphics.DrawString(currentBill.TotalPrice.ToString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(650, yPos + 180));
            e.Graphics.DrawString("---------------------------------------", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, yPos + 200));

        }

        private void SendDataToGoogleSheet(int id)
        {
            var currentBill = _billRepo.ListBillById(SubOrderDTO.Instance.BillId);
            string credentialsFilePath = "E:\\FPT\\3rd Year\\PRN211\\Assignments\\OrderingSystem-AIassistant\\OrderingSystem-AIassistant\\OrderingSystemAI\\OrderingSystemAI\\sheetapi.json";
            string spreadsheetId = "1oknCkKhxuh7YVC7CcTQIMJZLtAlDa5yrnVLk9p5Tn-A";
            string sheetName = "PRN211";
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            SheetsService service;
            var data = _billDetailRepo.GetBillByID(id);
            try
            {
                foreach (AllBillInforDTO bill in data)
                {
                    GoogleCredential credential;
                    using (var stream = new System.IO.FileStream(credentialsFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
                    }

                    // Khởi tạo SheetsService sử dụng Service Account Credential
                    service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "OrderingSystemAI",
                    });

                    var range = $"{sheetName}!A:G";
                    var valueRange = new ValueRange();

                    var objectList = new List<object>()
                    {
                        bill.BillId,
                        bill.CreateDate,
                        bill.CreateTime,
                        bill.FoodName,
                        bill.FoodPrice,
                        bill.Quantity,
                        bill.Quantity * bill.FoodPrice
                    };
                    valueRange.Values = new List<IList<object>> { objectList };
                    var request = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
                    request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                    var response = request.Execute();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi gửi dữ liệu lên Google Sheet: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
