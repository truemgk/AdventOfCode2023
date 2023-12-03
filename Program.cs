
//find all classes with DayAttribute that have a method with SolutionAttribute and run it
using System.Reflection;

var types = Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.GetCustomAttributes(typeof(DayAttribute), false).Length > 0)
    .Where(t => t.GetMethods().Any(m => m.GetCustomAttributes(typeof(SolutionAttribute), false).Length > 0));

foreach (var type in types)
{
    var day = type.GetCustomAttribute<DayAttribute>().Day;
    var name = type.GetCustomAttribute<DayAttribute>().Name;
    var input = DayInputLoader.Load(day);
    var solutions = type.GetMethods().Where(m => m.GetCustomAttributes(typeof(SolutionAttribute), false).Length > 0);
    //write the header
    Console.WriteLine($"--- Day {day}: {name} ---");

    foreach (var solution in solutions)
    {
        var solutionName = solution.GetCustomAttribute<SolutionAttribute>().Name;
        Console.WriteLine($"-- Solution: {solutionName} --");
        Console.WriteLine($"-- Result: {solution.Invoke(null, new object[] { input })} --");
        Console.WriteLine("----------");
    }
}


class DayAttribute : Attribute
{
    public DayAttribute(int day, string name)
    {
        Day = day;
        Name = name;
    }

    public int Day { get; }
    public string Name { get; }
}

class SolutionAttribute : Attribute
{
    public SolutionAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}

class DayInputLoader
{
    public static string Load(int day)
    {
        //load input file
        return System.IO.File.ReadAllText($"../../../inputs/day{day}.txt");
    }
}