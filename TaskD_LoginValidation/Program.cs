var setAmount = int.Parse(Console.ReadLine());
var logins = new HashSet<string>();
for (var iteration = 0; iteration < setAmount; iteration++)
{
    logins.Clear();
    var loginsAmount = int.Parse(Console.ReadLine());
    for (var loginIndex = 0; loginIndex < loginsAmount; loginIndex++)
    {
        var login = Console.ReadLine();
        Console.WriteLine(ValidateLogin(login) ? "YES" : "NO");
    }
    Console.WriteLine();
}

bool ValidateLogin(string login)
{
    if (login[0] == '-')
        return false;
    
    const int minLoginLength = 2;
    const int maxLoginLength = 2;
    if (login.Length is < minLoginLength or > maxLoginLength)
        return false;
    
    const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
    if (login.Any(letter => !alphabet.Contains(letter)))
        return false;
    
    var loginToLower = login.ToLower();
    if (logins.Contains(loginToLower))
        return false;
    
    logins.Add(loginToLower);
    return true;
}