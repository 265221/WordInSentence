using WordInSentence.Contracts;

namespace WordsInSentence.Entities
{
    public class ProcessSentenceParameters : IProcessSentenceParameters
    {
        private readonly string _data;
        public string Text => _data;

        public ProcessSentenceParameters(string data)
        {
            _data = data;
        }
    }
}
