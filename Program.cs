using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Lab_4
{
	class Program
	{
		static void Main(string[] args)
		{
			async Task<string> Result()
			{
				return await Task.Run(() => GenerateNumber()
			   .ContinueWith(task => GenerateNumbers(task.Result))
			   .ContinueWith(task => CalcSum(task.Result.Result))
			   .ContinueWith(task => TransformToString(task.Result.Result))).Result;
			}
			async Task<int> GenerateNumber()
			{
				return new Random().Next(1, 25);
			}
			async Task<List<double>> GenerateNumbers(int count)
			{
				Console.WriteLine("Результат 1 задачи:");
				Console.WriteLine(count);
				var list = new List<double>();
				for (int i = 0; i < count; i++)
					list.Add(new Random().NextDouble());
				return list;
			}
			async Task<double> CalcSum(List<double> numbers)
			{
				Console.WriteLine("\nРезультат 2 задачи:");
				foreach (double i in numbers) { Console.WriteLine($"{i:f3}"); }
				return numbers.Sum();
			}
			async Task<string> TransformToString(double number)
			{
				Console.WriteLine("\nРезультат 3 задачи:");
				Console.WriteLine($"{number:f3}");
				return "Строка " + number.ToString("f3");
			}
			var task = Result();
			Console.WriteLine("\nРезультат 4 задачи:");
			Console.WriteLine($"{task.Result:f3}");
		}
	}
}