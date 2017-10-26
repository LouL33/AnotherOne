using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace AnotherOne
{
    public partial class Form1 : Form
    {

        private SpeechRecognitionEngine engine;
        private SpeechSynthesizer synthesizer;

        public void LoadSpeech()
        {
            try
            {
                engine = new SpeechRecognitionEngine();
                engine.SetInputToDefaultAudioDevice(); // define the mic

                engine.LoadGrammar(new DictationGrammar());

                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);

                engine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpeech();
        }

        private void rec(object s, SpeechRecognizedEventArgs e)
        {
            label1.Text = "You: " + e.Result.Text;
        }
    }
}
