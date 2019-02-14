using System.Collections.Generic;

namespace WordsInSentence.Entities
{
    public class AnalyzeResult
    {
        public IList<WordStatisticItem> Items { get;  }

        public AnalyzeResult(IList<WordStatisticItem> data)
        {
            Items = data;
        }
    }
}
