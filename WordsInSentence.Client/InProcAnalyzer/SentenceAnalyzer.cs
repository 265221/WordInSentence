using log4net;
using System.Text.RegularExpressions;
using WordInSentence.Contracts;

namespace WordsInSentence.Client.InProcAnalyzer
{
    /// <summary>
    /// Responsible for splitting text (sentence) to words
    /// </summary>
    public class SentenceAnalyzer : ISentenceAnalyzer
    {
        #region Private members
        private static readonly ILog Log = LogManager.GetLogger(typeof(SentenceAnalyzer));
        private static readonly Regex _regex = new Regex(@"(?<word>([-']?[^\W_]+)?[-']?[^\W_]+[-']?[^\W_]*)");
        private readonly IWordProcessor _wordProcessor;
        #endregion

        #region Constructor
        public SentenceAnalyzer(IWordProcessor wordProcessor)
        {
            _wordProcessor = wordProcessor;
        }
        #endregion

        #region ISentenceAnalyzer implementation

        /// <summary>
        /// Splits parameters.Text to words
        /// Throws event per word
        /// </summary>
        /// <param name="parameters">Text contains sentence(or full text)</param>
        public void Analyze(IProcessSentenceParameters parameters)
        {
            _wordProcessor.Reset();
            var matches = _regex.Matches(parameters.Text);
            long counter = 0;
            foreach (Match match in matches)
            {
                //raise events here
                WordEventArgs args;
                if (match.Success)
                {
                    var word = match.Groups["word"].Value;
                    args = new WordEventArgs(word, ++counter, matches.Count);
                    
                }
                else
                {
                    args = new WordEventArgs(null, ++counter, matches.Count);
                }
                _wordProcessorHandler(this, args);
            }

        }
        #region IInitializable implementation

        public void Initialize()
        {
            _wordProcessorHandler = new WordProcessorHander(_wordProcessor.ProcessWord);
        }
        #endregion

        #endregion

        #region Delegates

        public delegate void WordProcessorHander(object sender, WordEventArgs args);
        private WordProcessorHander _wordProcessorHandler;

        #endregion
    }
}
