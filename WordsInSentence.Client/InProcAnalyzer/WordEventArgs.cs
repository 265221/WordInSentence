using System;

namespace WordsInSentence.Client.InProcAnalyzer
{
    public class WordEventArgs : EventArgs
    {
        public string Word { get; private set; }
        public long WordSequenceNumber { get; private set; }
        public long WordCount { get; private set; }

        public WordEventArgs(string word, long number, long wordCount)
        {
            Word = word;
            WordSequenceNumber = number;
            WordCount = wordCount;
        }
    }
}
