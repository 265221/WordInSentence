using WordsInSentence.Entities;

namespace WordsInSentence.Client.InProcAnalyzer
{
    public interface IWordProcessor
    {
        void ProcessWord(object sender, WordEventArgs args);
        void Reset();
        AnalyzeResult GetFinalResult();
    }
}