using BenchmarkDotNet.Attributes;
using static LinqProblems.WhereWhereVsWhere.Vehicle;

namespace LinqProblems.CastVsOfType;

public class Vehicle
{
    public int Id { get; set; }
}

public class Car : Vehicle
{
    public bool Convertible { get; set; }
}

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private const int SampleSize = 10_000;
    private List<Vehicle> _arVehicles = new();

    [GlobalSetup]
    public void Setup()
    {
        Random rnd = new(42);
        _arVehicles = Enumerable
            .Range(0, SampleSize)
            .Select(x =>
            {
                if (x % 2 == 0)
                {
                    return new Vehicle
                    {
                        Id = x
                    };
                }
                else
                {
                    return new Car
                    {
                        Id = x,
                        Convertible = rnd.Next(2) == 0
                    };
                }
            })
            .ToList();
    }

    [Benchmark]
    public List<Car?> CastAsThenNullCheck()
    {
        return _arVehicles
            .Select(x => x as Car)
            .Where(x => x != null)
            .ToList();
    }

    [Benchmark]
    public List<Car> DirectCast()
    {
        return _arVehicles
            .Where(x => x is Car)
            .Select(x => (Car)x)
            .ToList();
    }

    [Benchmark]
    public List<Car?> CastAs()
    {
        return _arVehicles
            .Where(x => x is Car)
            .Select(x => x as Car)
            .ToList();
    }

    [Benchmark]
    public List<Car> OfType()
    {
        return _arVehicles
            .OfType<Car>()
            .ToList();
    }
}
