using OrderingSystemAI.Repo.DTO;
using OrderingSystemAI.Repo.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderingSystemAI
{
    public partial class SoftDrinkcs : Form
    {
        private readonly ISubOrderRepo _subOrderRepo = new SubOrderRepo();
        private BindingSource _source;
        private bool formCQuantityShown = false;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public SoftDrinkcs()
        {
            InitializeComponent();
            InitializeSpeechRecognition();
            InitializeVoiceSynthesizer();
        }

        private void InitializeSpeechRecognition()
        {
            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//SoftDrinkList.txt");
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
            if (result == "Coca")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = coca.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\coca.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt10.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Fanta")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = fanta.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\fanta.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt10.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Water")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = Water.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\water.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt10.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Sprite")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = sprite.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Sprite.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt10.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else
            {
                speech.SpeakAsyncCancelAll();
            }
            recEngine.RecognizeAsyncCancel();
        }

        private void SoftDrinkcs_Load(object sender, EventArgs e)
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
