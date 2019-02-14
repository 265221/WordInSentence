using System.Collections;
using System.Collections.Generic;
using WordsInSentence.Contracts;

namespace WordsInSentence.Entities
{
    public class WordsCache : ICache
    {
        private readonly IDictionary<string, long> _inner;

        public WordsCache()
        {
            _inner = new Dictionary<string, long>();
        }

        public long this[string key] { get => _inner[key]; set => _inner[key] = value; }

        public ICollection<string> Keys => _inner.Keys;

        public ICollection<long> Values => _inner.Values;

        public int Count => _inner.Count;

        public bool IsReadOnly => _inner.IsReadOnly;

        public void Add(string key, long value)
        {
            _inner.Add(key, value);
        }

        public void Add(KeyValuePair<string, long> item)
        {
            _inner.Add(item);
        }

        public void Clear()
        {
            _inner.Clear();
        }

        public bool Contains(KeyValuePair<string, long> item)
        {
            return _inner.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return _inner.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, long>[] array, int arrayIndex)
        {
            _inner.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, long>> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        public bool Remove(string key)
        {
            return _inner.Remove(key);
        }

        public bool Remove(KeyValuePair<string, long> item)
        {
            return _inner.Remove(item);
        }

        public bool TryGetValue(string key, out long value)
        {
            return _inner.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _inner.GetEnumerator();
        }
    }
}
