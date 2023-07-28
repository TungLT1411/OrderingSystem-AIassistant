using OrderingSystemAI.Repo.DTO;
using OrderingSystemAI.Repo.Models;
using OrderingSystemAI.Repo.Repo;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace OrderingSystemAI
{
    public partial class StartOrdering : Form
    {
        private readonly IBillRepo _context = new BillRepo();
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        public StartOrdering()
        {
            InitializeComponent();

            Choices choices = new Choices();
            string[] text = File.ReadAllLines(Environment.CurrentDirectory + "//grammar.txt");
            choices.Add(text);
            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recEngne_SpechRecognized);

            speech.SelectVoiceByHints(VoiceGender.Male);
        }

        private void recEngne_SpechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;
            //resultLbl.Text += result + ", ";

            if (result == "Start Ordering")
            {
                if (result == "Start Ordering")
                {
                    speech.SpeakAsyncCancelAll();
                    Type type = new Type();
                    this.Hide();
                    type.ShowDialog();
                    result = "";
                    Addbill();
                }

                speech.SpeakAsync(result);
            }
            else
            {
                speech.SpeakAsyncCancelAll();
            }
        }

        private void Addbill()
        {
            Bill newBill = new Bill
            {
                CreateDate = DateTime.Now,
                CreateTime = DateTime.Now.ToString("hh:mm:ss")
            };
            _context.addBill(newBill);
            SubOrderDTO.Instance.BillId = newBill.Id;
        }

        private void StartOrdering_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}