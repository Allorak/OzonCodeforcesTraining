var setAmount = int.Parse(Console.ReadLine());
var moduleDependencies = new Dictionary<string, List<string>>();
var builtModules = new HashSet<string>();
string buildOrder = "";
for (var iteration = 0; iteration < setAmount; iteration++)
{
    Console.ReadLine();
    moduleDependencies.Clear();
    builtModules.Clear();
    var moduleAmount = int.Parse(Console.ReadLine());
    for (int i = 0; i < moduleAmount; i++)
    {
        var dependencies = Console.ReadLine().Split().ToList();
        var module = dependencies[0].Remove(dependencies[0].Length - 1);
        moduleDependencies[module] = new List<string>();
        dependencies.RemoveAt(0);
        moduleDependencies[module].AddRange(dependencies);
    }

    var requestAmount = int.Parse(Console.ReadLine());
    for (int i = 0; i < requestAmount; i++)
    {
        var moduleToBuild = Console.ReadLine();
        BuildModule(moduleToBuild);
        moduleAmount = buildOrder!="" ? buildOrder.Split().Length : 0;
        Console.WriteLine($"{moduleAmount} {buildOrder}");
        buildOrder = "";
    }

    Console.WriteLine();
}

void BuildModule(string module)
{
    if(builtModules.Contains(module))
        return;
    foreach (var dependency in moduleDependencies[module])
    {
        if(!builtModules.Contains(module))
            BuildModule(dependency);
    }
    builtModules.Add(module);
    if (buildOrder != "")
        buildOrder += " ";
    buildOrder += $"{module}";
}