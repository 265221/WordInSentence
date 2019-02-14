namespace WordsInSentence.Entities
{
    public class WordStatisticItem
    {
        private readonly string _word;
        private readonly long _count;

        public WordStatisticItem(string word, long count)
        {
            _word = word;
            _count = count;
        }

        public string Word => _word;
        public long Count => _count;
    }
}
