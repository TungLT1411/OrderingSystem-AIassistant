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
    public partial class Quantity : Form
    {
        private readonly ISubOrderRepo _subOrderRepo = new SubOrderRepo();
        private BindingSource _source;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public Quantity()
        {
            InitializeComponent();
            InitializeVoiceSynthesizer();
            InitializeSpeechRecognition();

        }

        private void InitializeSpeechRecognition()
        {
            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//Quantity.txt");
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
            reader.SpeakAsync("How Many " + SubOrderDTO.Instance.FoodName + " Do You Want To Order??");
        }

        private void recEngne_SpechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;
            textBox1.Text = result;
            if (result == "One" || result == "Two" || result == "Three" || result == "Four" || result == "Five" || result == "Six" || result == "Seven" ||
                result == "Eight" || result == "Nine" || result == "Ten" || result == "Cancel")
            {

                if (result == "One")
                {
                    SubOrderDTO.Instance.Quantity = 1;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();
                }
                else if (result == "Two")
                {
                    SubOrderDTO.Instance.Quantity = 2;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();

                }
                else if (result == "Three")
                {
                    SubOrderDTO.Instance.Quantity = 3;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();

                }
                else if (result == "Four")
                {
                    SubOrderDTO.Instance.Quantity = 4;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();
                    result = "";

                }
                else if (result == "Five")
                {
                    SubOrderDTO.Instance.Quantity = 5;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();
                    result = "";

                }
                else if (result == "Six")
                {
                    SubOrderDTO.Instance.Quantity = 6;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();
                    result = "";

                }
                else if (result == "Seven")
                {
                    SubOrderDTO.Instance.Quantity = 7;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();
                    result = "";

                }
                else if (result == "Eight")
                {
                    SubOrderDTO.Instance.Quantity = 8;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();
                    result = "";

                }
                else if (result == "Nine")
                {
                    SubOrderDTO.Instance.Quantity = 9;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();
                    result = "";

                }
                else if (result == "Ten")
                {
                    SubOrderDTO.Instance.Quantity = 10;
                    this.Close();

                    AskContinue askContinue = new AskContinue();
                    askContinue.Show();
                    result = "";

                }
                else if (result == "Cancel")
                {
                    this.Close();

                    CancelOrder cancelOrder = new CancelOrder();
                    cancelOrder.Show();
                    result = "";

                }
                else
                {
                    speech.SpeakAsyncCancelAll();
                }
                recEngine.RecognizeAsyncCancel();
            }
        }
        private void Quantity_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(SubOrderDTO.Instance.ImagePathh);
            label1.Text = "How Many " + SubOrderDTO.Instance.FoodName + "\nDo You Want To Order??";

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
