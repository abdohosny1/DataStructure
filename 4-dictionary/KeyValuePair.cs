namespace _4_dictionary
{
    public partial class Dictionary<TKey, Tvalue> where TKey : class
    {
        class KeyValuePair
        {
            TKey _key;
            Tvalue _value;

            public TKey Key { get { return _key; } }
            public Tvalue Value { get { return _value; } set { _value = value; } }

            public KeyValuePair(TKey key, Tvalue value)
            {
                _key = key;
                _value = value;
            }
        }

    }
}
