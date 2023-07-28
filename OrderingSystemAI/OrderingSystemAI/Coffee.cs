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
    public partial class Coffee : Form
    {
        private readonly ISubOrderRepo _subOrderRepo = new SubOrderRepo();
        private BindingSource _source;
        private bool formCQuantityShown = false;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public Coffee()
        {
            InitializeComponent();
            InitializeSpeechRecognition();
            InitializeVoiceSynthesizer();
        }
        private void InitializeSpeechRecognition()
        {
            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//CoffeeList.txt");
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
            americano.Text = result;
            if (result == "Americano")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = americano.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Americano.png";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt25.Text);

                this.Close();
                Quantity quantity = new Quantity();
                result = "";
                quantity.Show();

            }
            else if (result == "Cappuccino")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = cappuccino.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Cappuccino.png";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt35.Text);
                Quantity quantity = new Quantity();
                this.Close();
                result = "";
                quantity.Show();
            }
            else if (result == "Espresso")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = espresso.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Espresso.jpg";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt30.Text);
                Quantity quantity = new Quantity();
                this.Close();
                quantity.Show();
                result = "";
            }
            else if (result == "Milk Coffee")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = milkCoffee.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Milk Coffee.png";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt15.Text);
                Quantity quantity = new Quantity();
                this.Close();
                quantity.Show();
                result = "";
            }
            else if (result == "Black Coffee")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = blackCoffee.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\Black Coffee.png";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt12.Text);
                Quantity quantity = new Quantity();
                this.Close();
                quantity.Show();
                result = "";
            }
            else if (result == "White Coffee")
            {
                // Lưu tên đồ ăn đã chọn vào Singleton
                SubOrderDTO.Instance.FoodName = whiteCoffee.Text;
                SubOrderDTO.Instance.ImagePathh = Environment.CurrentDirectory + "\\ICON\\White Coffee.png";
                SubOrderDTO.Instance.FoodPrice = int.Parse(txt20.Text);
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
    }
}
