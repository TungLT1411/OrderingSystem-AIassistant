using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using OrderingSystemAI.Repo.DTO;
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
    public partial class AskContinue : Form
    {
        private readonly IBillDetailRepo _billDetailRepo = new BillDetailRepo();
        private readonly ISubOrderRepo _subOrderRepo = new SubOrderRepo();
        private readonly IBillRepo _billRepo = new BillRepo();
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public AskContinue()
        {
            InitializeComponent();
            InitializeVoiceSynthesizer();
            InitializeSpeechRecognition();
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
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recEngne_SpechRecognized);
        }

        private void InitializeVoiceSynthesizer()
        {
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.SelectVoiceByHints(VoiceGender.Female);
            reader.SpeakAsync("You have ordered " + SubOrderDTO.Instance.Quantity.ToString() + " " + SubOrderDTO.Instance.FoodName
               + " Successfully");
            reader.SpeakAsync("    Do you want to continue order or Finish order?");
        }

        private void recEngne_SpechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;
            textBox1.Text = result;
            _subOrderRepo.addBillDetail(new SubOrder
            {
                FoodName = SubOrderDTO.Instance.FoodName,
                FoodPrice = (decimal?)SubOrderDTO.Instance.FoodPrice,
                Quantity = SubOrderDTO.Instance.Quantity
            });

            _billDetailRepo.addBillDetail(new BillDetail
            {
                BillId = SubOrderDTO.Instance.BillId,
                FoodName = SubOrderDTO.Instance.FoodName,
                FoodPrice = (decimal?)SubOrderDTO.Instance.FoodPrice,
                Quantity = SubOrderDTO.Instance.Quantity
            });


            if (result == "Continue")
            {
                this.Close();

                Type type = new Type();
                type.Show();
            }
            else if (result == "Finish")
            {
                _billRepo.update(SubOrderDTO.Instance.BillId, caculateBill());


                this.Close();
                ConfermFinish confermFinish = new ConfermFinish();
                confermFinish.Show();
            }
            else
            {
                speech.SpeakAsyncCancelAll();
            }
            recEngine.RecognizeAsyncCancel();
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

        private void AskContinue_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.Text = "You have ordered " + SubOrderDTO.Instance.Quantity.ToString() + " " + SubOrderDTO.Instance.FoodName
                + "      Price:        " + SubOrderDTO.Instance.FoodPrice.ToString() + "   Successfully";
            pictureBox1.Image = Image.FromFile(SubOrderDTO.Instance.ImagePathh);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        
    }
}
