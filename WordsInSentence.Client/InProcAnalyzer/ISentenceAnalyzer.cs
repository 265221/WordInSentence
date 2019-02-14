using WordInSentence.Contracts;

namespace WordsInSentence.Client.InProcAnalyzer
{
    public interface ISentenceAnalyzer : IInitializable
    {
        void Analyze(IProcessSentenceParameters parameters);
    }
}