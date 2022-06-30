var setAmount = int.Parse(Console.ReadLine());
var phoneBook = new SortedDictionary<string, List<string>>();
const int maxPhoneNumbers = 5;
for (var iteration = 0; iteration < setAmount; iteration++)
{
    phoneBook.Clear();
    var entriesAmount = int.Parse(Console.ReadLine());
    for (int entryIndex = 0; entryIndex < entriesAmount; entryIndex++)
    {
        var entry = Console.ReadLine().Split();
        var (person, phone) = (entry[0], entry[1]);
        AddPhone(person,phone);
    }
    foreach (var (person, phoneNumbers) in phoneBook)
    {
        phoneNumbers.Reverse();
        Console.Write(person+": "+phoneNumbers.Count);
        foreach (var phone in phoneNumbers)
        {
            Console.Write(" "+phone);
        }
        Console.WriteLine();
    }

    Console.WriteLine();
}

void AddPhone(string person, string phone)
{
    if (!phoneBook.ContainsKey(person))
    {
        phoneBook[person] = new List<string>() {phone};
        return;
    }

    if (phoneBook[person].Contains(phone))
    {
        phoneBook[person].Remove(phone);
        phoneBook[person].Add(phone);
        return;
    }

    if (phoneBook[person].Count == maxPhoneNumbers)
        phoneBook[person].RemoveAt(0);
    
    phoneBook[person].Add(phone);
}