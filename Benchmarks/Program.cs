using BenchmarkDotNet.Running;
using Challanges;

BenchmarkSwitcher
    .FromAssembly(typeof(Day<int>).Assembly)
    .Run(args);