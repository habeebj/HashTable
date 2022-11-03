namespace HashTables
{
    public class DataItem
    {
        public int Data { get; set; }
        public int Key { get; set; }

        public static DataItem Null()
        {
            return new DataItem
            {
                Key = -1
            };
        }
    }
}