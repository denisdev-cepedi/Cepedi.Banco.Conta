// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Cepedi.Banco.Conta.Performance.Test;
using Cepedi.Banco.Conta.Performance.Test.Helpers;
using Cepedi.Banco.Conta.Performance.Tests;

//var summary = BenchmarkRunner.Run<StringConcatenationVsStringBuilderBenchmark>();
//var summary = BenchmarkRunner.Run<IterationBenchmark>();
//var summary = BenchmarkRunner.Run<ArrayCopyBenchmark>();
var summary = BenchmarkRunner.Run<DapperVsEfCoreBenchmark>();
