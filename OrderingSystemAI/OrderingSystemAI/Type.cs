using OrderingSystemAI.Repo.Models;
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
using static System.Windows.Forms.DataFormats;

namespace OrderingSystemAI
{
    public partial class Type : Form
    {
        private readonly IBillRepo _context = new BillRepo();
        private readonly ISubOrderRepo _subOrderRepo = new SubOrderRepo();
        private BindingSource _source;
        private bool form6Shown = false;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public Type()
        {
            InitializeComponent();
            InitializeSpeechRecognition();
            InitializeVoiceSynthesizer();
        }

        private void InitializeSpeechRecognition()
        {
            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//grammar.txt");
            choices.Add(text);
            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recEngne_SpeechRecognized);
        }

        private void InitializeVoiceSynthesizer()
        {
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.SelectVoiceByHints(VoiceGender.Female);
            reader.SpeakAsync("What do you want to order");
        }

        private void recEngne_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            string result = e.Result.Text;
            textBox1.Text = result;
            //resultLbl.Text += result + ", ";

            if (result == "Snack")
            {
                this.Close();

                SnackFood frm6 = new SnackFood();
                frm6.Show();
            }
            else if (result == "Pizza")
            {
                PizzaFood pizzaFood = new PizzaFood();
                this.Close();
                pizzaFood.Show();
            }
            else if (result == "Soft Drink")
            {
                SoftDrinkcs softDrinkcs = new SoftDrinkcs();
                this.Close();
                softDrinkcs.Show();
            }
            if (result == "Coffee")
            {
                this.Close();
                Coffee coffee = new Coffee();
                coffee.Show();
            }
            else if (result == "ALLAH")
            {

            }
            else
            {
                speech.SpeakAsyncCancelAll();
            }
            recEngine.RecognizeAsyncCancel();
        }



        private void Type_Load(object sender, EventArgs e)
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

        //private void Type_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    // Khi form đóng, tạm thời dừng chức năng nhận giọng nói
        //    recEngine.RecognizeAsyncCancel();

        //    // Nếu form đang được hiển thị, thì thực sự đóng form
        //    if (this.IsHandleCreated)
        //    {
        //        this.Close();
        //    }
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
