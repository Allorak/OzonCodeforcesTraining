var setAmount = int.Parse(Console.ReadLine());
for (var iteration = 0; iteration < setAmount; iteration++)
{
    Console.ReadLine();
    var amounts = Console.ReadLine().Split().Select(int.Parse).ToArray();
    var (compartmentsAmount, requestsAmount) = (amounts[0], amounts[1]);
    var occupiedSeats = new bool[2 * compartmentsAmount];
    var emptyCompartments = new SortedSet<int>();
    for (int i = 0; i < compartmentsAmount; i++)
    {
        emptyCompartments.Add(i);
    }
    for (int i = 0; i < requestsAmount; i++)
    {
        var request = Console.ReadLine().Split();
        var seatNumber = 0;
        if(request.Length>1)
            seatNumber = int.Parse(request[1])-1;
        switch (request[0])
        {
            case "1":
                if (!occupiedSeats[seatNumber])
                {
                    emptyCompartments.Remove(seatNumber/2);
                    occupiedSeats[seatNumber] = true;
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("FAIL");
                }
                break;
            case "2":
                if (occupiedSeats[seatNumber])
                {
                    if(seatNumber % 2 == 0 && !occupiedSeats[seatNumber+1] ||
                       seatNumber % 2 == 1 && !occupiedSeats[seatNumber-1])
                        emptyCompartments.Add(seatNumber/2);
                    occupiedSeats[seatNumber] = false;
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("FAIL");
                }
                break;
            case "3":
                if (emptyCompartments.Any())
                {
                    var firstEmptyCompartment = emptyCompartments.First();
                    Console.WriteLine($"SUCCESS {firstEmptyCompartment * 2 + 1}-{firstEmptyCompartment * 2 + 2}");
                    emptyCompartments.Remove(firstEmptyCompartment);
                    occupiedSeats[firstEmptyCompartment*2] = true;
                    occupiedSeats[firstEmptyCompartment*2 + 1] = true;
                }
                else
                {
                    Console.WriteLine("FAIL");
                }
                break;
        }
    }

    Console.WriteLine();
}