using log4net;
using log4net.Appender;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Unity;
using WordInSentence.Contracts;
using WordsInSentence.Client.Bootstrap;
using WordsInSentence.Client.InProcAnalyzer;
using WordsInSentence.Entities;

namespace WordsInSentence.Client
{
    public partial class MainForm : Form
    {
        #region private members
        private readonly IUnityContainer _container;
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm));

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            _container = BootstrapContainer.Instance;
            //establish delegates between analyzer and wordProcessor

            var typesToInitialize = _container.Registrations.Where(r => typeof(IInitializable).IsAssignableFrom(r.RegisteredType)).Select(rt=>rt.RegisteredType);
            foreach(var typeToInitialize in typesToInitialize)
            {
                var objectToInitialize = _container.Resolve(typeToInitialize);
                ((IInitializable)objectToInitialize).Initialize();
            }

            this.Initialize();
            
        }

        #endregion

        #region Event handlers

        private void ObtainResults(object sender, EventArgs e)
        {
            analyzerProgressBar.Value = analyzerProgressBar.Maximum;
            var data = ((WordProcessor)sender).GetFinalResult();
            this.dataGridViewResult.DataSource = data.Items;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            ShowStatus("Status : Please wait...", Color.Black);
            try
            {
                var data = sentenceBox.Text;
                var parameters = new ProcessSentenceParameters(data);
                var analyzer = _container.Resolve<ISentenceAnalyzer>();
                analyzer.Analyze(parameters);
                ShowStatus("Status : OK", Color.Green);
            }
            catch(Exception ex)
            {
                ShowStatus($"Status : Error", Color.Red);
                Log.Error(ex.ToString());
            }
        }

        private void WordProcessedHandler(object sender, WordEventArgs args)
        {
            if (args.WordCount > 0)
            {
                analyzerProgressBar.Value = Convert.ToInt32(analyzerProgressBar.Maximum * args.WordSequenceNumber / args.WordCount);
            }
        }

        private void labelStatus_Click(object sender, EventArgs e)
        {
            try
            {
                var fileAppender = Log.Logger.Repository.GetAppenders().Where(appender => appender is RollingFileAppender).FirstOrDefault();
                var file = ((RollingFileAppender)fileAppender).File;
                if (File.Exists(file))
                {
                    Process.Start("notepad.exe", file);
                }
            }
            catch
            {
                //unfortunately we failed to load the log file
                MessageBox.Show("Unfortunately log file cannot be found", "Error");
            }
        }

        #endregion

        #region Helper methods

        private void ShowStatus(string message, Color color)
        {
            labelStatus.Text = message;
            labelStatus.ForeColor = color;
        }

        private void Initialize()
        {
            //hook up some events between WordProcessor and MainForm
            var wordProcessor = _container.Resolve<IWordProcessor>();
            if (wordProcessor is WordProcessor)
            {
                ((WordProcessor)wordProcessor).WordProcessed += new EventHandler<WordEventArgs>(WordProcessedHandler);
                ((WordProcessor)wordProcessor).LastWordProcessed += new EventHandler(ObtainResults);
            }

            var helpToolTipForStatus = new ToolTip();
            helpToolTipForStatus.ToolTipIcon = ToolTipIcon.Info;
            helpToolTipForStatus.IsBalloon = true;
            helpToolTipForStatus.ShowAlways = true;

            helpToolTipForStatus.SetToolTip(labelStatus, "Please click it in order to peek into log file");
        }
        #endregion
    }

    
}
