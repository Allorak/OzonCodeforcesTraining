var setAmount = int.Parse(Console.ReadLine());
for (var i = 0; i < setAmount; i++)
{
    var itemsAmount = int.Parse(Console.ReadLine());
    var prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
    var shoppingList = new Dictionary<int, int>();
    foreach (var price in prices)
    {
        if (!shoppingList.ContainsKey(price))
            shoppingList[price] = 1;
        else
            shoppingList[price] += 1;
    }
    var totalPrice = 0;
    foreach (var (price, amount) in shoppingList)
    {
        var amountWithSale = amount / 3 * 2 + amount % 3;
        totalPrice += amountWithSale * price;
    }
    
    Console.WriteLine(totalPrice);
}