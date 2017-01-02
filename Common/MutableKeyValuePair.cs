namespace Common
{
    public class MutableKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; set; }

        public MutableKeyValuePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
