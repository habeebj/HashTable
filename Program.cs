using ConsoleTables;
using HashTables;

var hashTable = new HashTable(10);

for (int i = 0; i < hashTable.Capacity; i++)
{
    hashTable.Insert(i, i * 100);
}

var item = hashTable.Search(1);
if (item != null)
{
    hashTable.Delete(item);
}

ConsoleTable.From<DataItem>(hashTable.ToList()).Write();