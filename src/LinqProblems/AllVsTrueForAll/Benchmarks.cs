using BenchmarkDotNet.Attributes;

namespace LinqProblems.AllVsTrueForAll;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private const int SampleSize = 10_000;
    private List<int>? _arItems;
    private IEnumerable<int> EnumerableItems => _arItems!;

    [GlobalSetup]
    public void Setup()
    {
        Random rnd = new(42);
        _arItems = Enumerable
            .Range(0, SampleSize)
            .Select(_ => rnd.Next(1, int.MaxValue))
            .ToList();
    }

    [Benchmark]
    public bool All()
    {
        return EnumerableItems.All(x => x > 0);
    }

    [Benchmark]
    public bool TrueForAll()
    {
        return _arItems!.TrueForAll(x => x > 0);
    }

    [Benchmark]
    public bool ToListTrueForAll()
    {
        return EnumerableItems.ToList().TrueForAll(x => x > 0);
    }
}
