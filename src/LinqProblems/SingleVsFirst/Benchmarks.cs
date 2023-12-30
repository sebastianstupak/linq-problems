using BenchmarkDotNet.Attributes;

namespace LinqProblems.SingleVsFirst;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private const int SampleSize = 10_000;
    private const int Value = 42;
    private List<int> _arItems = new();

    [GlobalSetup]
    public void Setup()
    {
        bool valueAdded = false;
        Random rnd = new(42);
        _arItems = Enumerable
            .Range(0, SampleSize)
            .Select(_ =>
            {
                if (!valueAdded)
                {
                    valueAdded = true;
                    return Value;
                }

                // Ensure there is only one Value in the List for more consistent results
                int val;
                do
                {
                    val = rnd.Next(1, int.MaxValue);
                } while (val == Value);

                return val;
            })
            .OrderBy(x => rnd.Next())
            .ToList();
    }

    [Benchmark]
    public int Single()
    {
        return _arItems.Single(x => x == Value);
    }

    [Benchmark]
    public int First()
    {
        return _arItems.First(x => x == Value);
    }
}
