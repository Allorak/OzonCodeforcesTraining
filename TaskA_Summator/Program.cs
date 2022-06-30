int pairAmount = int.Parse(Console.ReadLine());
for (int i = 0; i < pairAmount; i++)
{
    int[] pair = Console.ReadLine().Split().Select(int.Parse).ToArray();
    Console.WriteLine(pair[0] + pair[1]);
}