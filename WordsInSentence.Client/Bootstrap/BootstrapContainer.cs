using Unity;
using WordsInSentence.Client.InProcAnalyzer;
using WordsInSentence.Contracts;
using WordsInSentence.Entities;

namespace WordsInSentence.Client.Bootstrap
{
    public sealed class BootstrapContainer : UnityContainer
    {
        private static BootstrapContainer _instance = new BootstrapContainer();
        public static BootstrapContainer Instance { get { return _instance; } }

        private BootstrapContainer() : base()
        {
            this.RegisterType<ICache, WordsCache>();
            this.RegisterSingleton<ISentenceAnalyzer, SentenceAnalyzer>();
            this.RegisterSingleton<IWordProcessor, WordProcessor>();
        }
    }
}
