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
    public partial class CancelOrder : Form
    {
        private readonly ISubOrderRepo _subOrderRepo = new SubOrderRepo();
        private BindingSource _source;
        private bool formCQuantityShown = false;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public CancelOrder()
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
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recEngne_SpechRecognized);
        }

        private void InitializeVoiceSynthesizer()
        {
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.SelectVoiceByHints(VoiceGender.Female);
            reader.SpeakAsync("Do You Want To Cancel " + SubOrderDTO.Instance.FoodName);
        }

        private void recEngne_SpechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            string result = e.Result.Text;
            if (result == "Yes")
            {
                this.Close();
                Type type = new Type();
                result = "";
                type.Show();

            }
            else if (result == "No")
            {
                this.Close();

                Quantity quantity = new Quantity();
                quantity.Show();
                result = "";
            }
            else
            {
                speech.SpeakAsyncCancelAll();
            }
            recEngine.RecognizeAsyncCancel();
        }

        private void CancelOrder_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(SubOrderDTO.Instance.ImagePathh);
            lblFood.Text = SubOrderDTO.Instance.FoodName;
        }
    }
}
