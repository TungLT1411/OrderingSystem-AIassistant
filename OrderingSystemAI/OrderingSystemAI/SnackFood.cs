using OrderingSystemAI.Repo.DTO;
using OrderingSystemAI.Repo.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrderingSystemAI
{
    public partial class SnackFood : Form
    {
        private readonly ISubOrderRepo _subOrderRepo = new SubOrderRepo();
        private BindingSource _source;
        private bool formCQuantityShown = false;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public SnackFood()
        {
            InitializeComponent();
            InitializeSpeechRecognition();
            InitializeVoiceSynthesizer();
        }

        private void InitializeSpeechRecognition()
        {
            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//SnackList.txt");
            choices.Add(text);
            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recEngne_SpechRecognized);
        }

        private void InitializeVoiceSynthesizer()
        {
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.SelectVoiceByHints(VoiceGender.Female);
            reader.SpeakAsync("Please choose something!");
        }

        private void recEngne_SpechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            string result = e.Result.Text;
            textBox1.Text = result;
            if (result == "Fries Small")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = FriesS.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\FriesSmall.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt10.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Fries Medium")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = FriesM.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\FiresMedium.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt20.Text);
                Quantity quantity = new Quantity();
                this.Close();
                result = "";
                quantity.Show();
            }
            else if (result == "Fries Large")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = FriesL.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\FiresLarge.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt25.Text);
                Quantity quantity = new Quantity();
                this.Close();
                quantity.Show();
                result = "";
            }
            else if (result == "Fried Chicken")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = lblFC.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Spicy Chicken Fires.png";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txtFchicken.Text);
                Quantity quantity = new Quantity();
                this.Close();
                quantity.Show();
                result = "";
            }
            else if (result == "Chicken Wings")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = lblCW.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Fried Chicken.png";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txtWings.Text);
                Quantity quantity = new Quantity();
                this.Close();
                quantity.Show();
                result = "";
            }
            else if (result == "Burger")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = lblBurger.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\burger.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txtBurger.Text);
                Quantity quantity = new Quantity();
                this.Close();
                quantity.Show();
                result = "";
            }
            else
            {
                speech.SpeakAsyncCancelAll();
            }
            recEngine.RecognizeAsyncCancel();
        }

        private void SnackFood_Load(object sender, EventArgs e)
        {
            var ListOrder = _subOrderRepo.GetList();
            _source = new BindingSource();
            _source.DataSource = ListOrder;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _source;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Tự động điều chỉnh độ rộng của tất cả các cột dựa trên nội dung
            textBox1.Text = "TOTAL PRICE: " + caculateBill().ToString();
        }

        private decimal caculateBill()
        {
            var ListOrder = _subOrderRepo.GetList();
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
    }
}
