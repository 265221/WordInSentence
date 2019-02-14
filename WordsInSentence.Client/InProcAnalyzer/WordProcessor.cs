using log4net;
using System;
using System.Linq;
using Unity;
using WordsInSentence.Contracts;
using WordsInSentence.Entities;

namespace WordsInSentence.Client.InProcAnalyzer
{
    /// <summary>
    /// Responsible for counting words and notifying other components (currently UI only) about it
    /// </summary>
    public class WordProcessor: IWordProcessor
    {
        #region Private fields
        private static object lockObject = new object();
        private readonly IUnityContainer _container = Bootstrap.BootstrapContainer.Instance;
        private long _count = 0;
        private static readonly ILog Log = LogManager.GetLogger(typeof(WordProcessor));
        private readonly ICache _wordCache;
        #endregion

        public WordProcessor(ICache wordCache)
        {
            _wordCache = wordCache;
        }

        #region Events
        public event EventHandler<WordEventArgs> WordProcessed;
        public event EventHandler LastWordProcessed;
        #endregion

        #region IWordProcessor implementation

        /// <summary>
        /// Adds word to dictionary. Sends event about any words processed.
        /// Sends last word event in order to notify that full data can be pulled out in sync way
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ProcessWord(object sender, WordEventArgs args)
        {
            //ignore
            if (_count >= args.WordCount)
                return;

            //some unsuccessful parse came
            if(args.Word == null)
            {
                Log.Warn($"Some unsuccessfully parse value has arrived");
                _count++;
                EvaluateEndCondition(args);
                return;
            }

            lock (lockObject)
            {
                var key = args.Word.ToLower();
                if (_wordCache.Keys.Contains(key))
                {
                    _wordCache[key]++;
                }
                else
                {
                    _wordCache.Add(key, 1);
                }
                _count++;

                EvaluateEndCondition(args);


            }
        }

        public void Reset()
        {
            _count = 0;
            _wordCache.Clear();
        }

        /// <summary>
        /// Get Final result
        /// </summary>
        /// <returns>Statistics for words</returns>
        public AnalyzeResult GetFinalResult()
        {
            var items = _wordCache.Select(item => new WordStatisticItem(item.Key, item.Value)).OrderByDescending(i => i.Count).ThenBy(j => j.Word).ToList();
            var result = new AnalyzeResult(items);
            return result;
        }

        #endregion

        #region Helper methods

        private void EvaluateEndCondition(WordEventArgs args)
        {
            if (_count == args.WordCount)
            {
                //raise an final event here
                Log.Debug("Last word has arrived. It is the time to notify that results are ready");
                LastWordProcessed(this, EventArgs.Empty);
            }
            else
            {
                //TODO: raise an event here
                WordProcessed(this, args);
            }
        }

        #endregion
    }
}
