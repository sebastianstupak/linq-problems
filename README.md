# linq-problems
Showcase of common LINQ problems

## LINQ All vs List TrueForAll

```
BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
AMD Ryzen 5 5600U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100-rc.2.23502.2
  [Host]     : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2

| Method           | Mean      | Error     | StdDev    | Median    | Allocated |
|----------------- |----------:|----------:|----------:|----------:|----------:|
| All              | 13.142 us | 0.0644 us | 0.0503 us | 13.135 us |      40 B |
| TrueForAll       |  7.295 us | 0.0100 us | 0.0088 us |  7.293 us |         - |
| ToListTrueForAll | 10.239 us | 0.2632 us | 0.7719 us |  9.906 us |   40056 B |
```