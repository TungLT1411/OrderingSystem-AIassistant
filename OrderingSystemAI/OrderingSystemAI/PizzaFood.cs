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

namespace OrderingSystemAI
{
    public partial class PizzaFood : Form
    {
        private readonly ISubOrderRepo _subOrderRepo = new SubOrderRepo();
        private BindingSource _source;
        private bool formCQuantityShown = false;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public PizzaFood()
        {
            InitializeComponent();
            InitializeSpeechRecognition();
            InitializeVoiceSynthesizer();
        }

        private void InitializeSpeechRecognition()
        {
            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//PizzaList.txt");
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
            if (result == "Small Beef Pizza")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName =  SizeS.Text + " " + txtpizza1.Text ;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Pizza1SizeS.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt10.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Medium Beef Pizza")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = SizeM.Text + " " + txtpizza1.Text ;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Pizza1SizeM.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt20.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Large Beef Pizza")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = SizeL.Text + " " + txtpizza1.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Pizza1SizeL.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt25.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Small Mixed Pizza")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = SizeS.Text + " " + txtpizza2.Text ;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Pizza2SizeS.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt15.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Medium Mixed Pizza")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = txtpizza2.Text + " " + SizeM.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Pizza2SizeM.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt30.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Large Mixed Pizza")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = txtpizza2.Text + " " + SizeL.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Pizza2SizeL.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt40.Text);

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

        private void PizzaFood_Load(object sender, EventArgs e)
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




        private void FriesS_Click(object sender, EventArgs e)
        {

        }

        private void FriesL_Click(object sender, EventArgs e)
        {

        }

        private void FriesM_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
