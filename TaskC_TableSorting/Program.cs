var setAmount = int.Parse(Console.ReadLine());
for (var iteration = 0; iteration < setAmount; iteration++)
{
    Console.ReadLine();
    var tableDimensions = ReadIntArray();
    var (rowsAmount, columnsAmount) = (tableDimensions[0], tableDimensions[1]);
    var table = new int[rowsAmount,columnsAmount];
    for (var i = 0; i < rowsAmount; i++)
    {
        var row = ReadIntArray();
        for (int j = 0; j < columnsAmount; j++)
        {
            table[i, j] = row[j];
        }
    }

    var clicksAmount = int.Parse(Console.ReadLine());
    var clicks = ReadIntArray();
    foreach (var click in clicks)
    {
       SortTable(table, click-1); 
    }
    
    for (var i = 0; i < rowsAmount; i++)
    {
        for (var j = 0; j < columnsAmount-1; j++)
        {
            Console.Write(table[i,j]+" ");
        }
        Console.WriteLine(table[i,columnsAmount-1]);
    }
}

int[] ReadIntArray()
{
    return Console.ReadLine().Split().Select(int.Parse).ToArray();;
}

void SortTable(int[,] table, int columnNumber)
{
    for (var i = 0; i < table.GetLength(0); i++)
    {
        for (var j = 0; j < table.GetLength(0)-1; j++)
        {
            if (table[j, columnNumber] > table[j+1, columnNumber])
            {
                for (int k = 0; k < table.GetLength(1); k++)
                {
                    (table[j, k], table[j+1, k]) = (table[j+1, k], table[j, k]);
                }
            }
        }
    }
}