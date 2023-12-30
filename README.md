# linq-problems
Showcase of common LINQ problems

All benchmarks were run on:

```
BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
AMD Ryzen 5 5600U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-rc.2.23502.2
  [Host]     : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
```

# LINQ All vs List TrueForAll

[Medium article](https://medium.com/@sebastian.stupak/stop-using-this-linq-method-37173d0bfe3d)

```
| Method           | Mean      | Error     | StdDev    | Allocated |
|----------------- |----------:|----------:|----------:|----------:|
| All              | 13.142 us | 0.0644 us | 0.0503 us |      40 B |
| TrueForAll       |  7.295 us | 0.0100 us | 0.0088 us |         - |
| ToListTrueForAll | 10.239 us | 0.2632 us | 0.7719 us |   40056 B |
```

# Common LINQ Problems

## Single() vs First()
```
| Method | Mean      | Error     | StdDev    | Allocated |
|------- |----------:|----------:|----------:|----------:|
| Single | 13.037 us | 0.0691 us | 0.0612 us |      40 B |
| First  |  5.836 us | 0.0253 us | 0.0224 us |      40 B |
```

## Where().First() vs First()

```
| Method     | Mean     | Error     | StdDev    | Allocated |
|----------- |---------:|----------:|----------:|----------:|
| WhereFirst | 6.498 us | 0.1039 us | 0.0972 us |      72 B |
| First      | 5.854 us | 0.1114 us | 0.0988 us |      40 B |
```

## Where().Where() vs Where()

```
| Method     | Mean     | Error    | StdDev   | Allocated |
|----------- |---------:|---------:|---------:|----------:|
| WhereWhere | 25.77 us | 0.374 us | 0.292 us |  32.47 KB |
| Where      | 20.28 us | 0.405 us | 0.741 us |   32.3 KB |
```

## Count() instead of Any() or All()

```
| Method            | Mean          | Error       | StdDev      | Allocated |
|------------------ |--------------:|------------:|------------:|----------:|
| CountAny          |      2.277 ns |   0.0303 ns |   0.0284 ns |         - |
| CountConditionAny | 13,225.195 ns |  76.6100 ns |  71.6610 ns |      40 B |
| CountConditionAll | 13,089.614 ns | 123.1911 ns | 109.2057 ns |      40 B |
| Any               |      2.680 ns |   0.0577 ns |   0.0540 ns |         - |
| AnyCondition      |     10.145 ns |   0.2328 ns |   0.6679 ns |      40 B |
| All               |      9.716 ns |   0.2209 ns |   0.2456 ns |      40 B |
```