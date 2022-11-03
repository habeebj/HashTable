namespace HashTables
{
    public class HashTable
    {
        DataItem[] _hashArray;

        public IEnumerable<DataItem> ToList() => _hashArray.ToList();

        public HashTable(int capacity)
        {
            _hashArray = new DataItem[capacity];
        }

        public int Capacity => _hashArray.Length;

        private int hashCode(int key)
        {
            return key % _hashArray.Length;
        }

        public DataItem? Search(int key)
        {
            int hashIndex = hashCode(key);

            while (_hashArray.GetValue(hashIndex) != null)
            {
                // or data is -1
                if (_hashArray[hashIndex].Key == key)
                    return _hashArray[hashIndex];

                // go to next cell
                ++hashIndex;

                // wrap around the table
                hashIndex %= _hashArray.Length;
            }

            return null;
        }

        public void Insert(int key, int data)
        {
            var dataItem = new DataItem { Key = key, Data = data };
            // get the hash
            int hashIndex = hashCode(key);

            // move in array until an empty or deleted cell
            // var current = 0;
            while (_hashArray.GetValue(hashIndex) != null && ((DataItem)_hashArray.GetValue(hashIndex)!).Key != -1)
            {
                // TODO: check for capacity -> throw exception if filled
                // ++current;
                // if(current >= _hashArray.Length)
                // {
                //     throw new ArgumentOutOfRangeException();
                // }
                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= _hashArray.Length;
            }

            _hashArray[hashIndex] = dataItem;
        }

        public DataItem? Delete(DataItem dataItem)
        {
            // get the hash 
            int hashIndex = hashCode(dataItem.Key);

            //move in array until an empty 
            while (_hashArray.GetValue(hashIndex) != null)
            {
                if (_hashArray[hashIndex].Key == dataItem.Key)
                {
                    var temp = _hashArray[hashIndex];

                    // assign a dummy item at deleted position
                    _hashArray[hashIndex] = DataItem.Null();
                    return temp;
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= _hashArray.Length;
            }

            return null;
        }
    }
}