using BenchmarkDotNet.Attributes;
using static LinqProblems.WhereWhereVsWhere.Vehicle;

namespace LinqProblems.WhereWhereVsWhere;

public class Vehicle
{
    public enum VehicleBrand
    {
        Porsche,
        BMW,
        Mercedes
    }

    public int Id { get; set; }
    public VehicleBrand Brand { get; set; }
    public int ProductionYear { get; set; }
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
                Vehicle vehicle = new()
                {
                    Id = x,
                    Brand = GetRandomBrand(rnd),
                    ProductionYear = rnd.Next(2000, 2024)
                };

                return vehicle;
            })
            .ToList();
    }

    private VehicleBrand GetRandomBrand(Random rnd)
    {
        Array values = Enum.GetValues(typeof(VehicleBrand));
        VehicleBrand rndBrand = (VehicleBrand)values.GetValue(rnd.Next(values.Length))!;

        return rndBrand;
    }

    [Benchmark]
    public List<Vehicle> WhereWhere()
    {
        return _arVehicles
            .Where(x => x.Brand == VehicleBrand.Porsche).Where(x => x.ProductionYear > 2010)
            .ToList();
    }

    [Benchmark]
    public List<Vehicle> Where()
    {
        return _arVehicles
            .Where(x => x.Brand == VehicleBrand.Porsche && x.ProductionYear > 2010)
            .ToList();
    }
}
