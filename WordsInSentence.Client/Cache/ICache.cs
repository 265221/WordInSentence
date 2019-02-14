using System.Data;

namespace WordsInSentence.Client.Cache
{
    public interface ICache
    {
        void Refresh();
        DataTable EnrichTable(DataTable target);
        long EnrichCache(DataTable source);
        long RecordCount();
        bool IsInitialized { get; }
        string Name { get; }
    }
}
