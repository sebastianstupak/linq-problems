using BenchmarkDotNet.Attributes;

namespace LinqProblems.CountVsAnyAll;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private const int SampleSize = 10_000;
    private List<int> _arItems = new();

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
    public bool CountAny()
    {
        return _arItems.Count() > 0;
    }

    [Benchmark]
    public bool CountConditionAny()
    {
        return _arItems.Count(x => x > 10) > 0;
    }

    [Benchmark]
    public bool CountConditionAll()
    {
        return _arItems.Count(x => x < 100) == _arItems.Count;
    }

    [Benchmark]
    public bool Any()
    {
        return _arItems.Any();
    }

    [Benchmark]
    public bool AnyCondition()
    {
        return _arItems.Any(x => x > 10);
    }

    [Benchmark]
    public bool All()
    {
        return _arItems.All(x => x < 100);
    }
}
