using BenchmarkDotNet.Running;

BenchmarkRunner.Run<LinqProblems.AllVsTrueForAll.Benchmarks>();
BenchmarkRunner.Run<LinqProblems.WhereFirstVsFirst.Benchmarks>();
BenchmarkRunner.Run<LinqProblems.SingleVsFirst.Benchmarks>();
BenchmarkRunner.Run<LinqProblems.WhereWhereVsWhere.Benchmarks>();
BenchmarkRunner.Run<LinqProblems.CastVsOfType.Benchmarks>();
BenchmarkRunner.Run<LinqProblems.CountVsAnyAll.Benchmarks>();
