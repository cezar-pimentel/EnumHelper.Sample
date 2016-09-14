using System;
using System.ComponentModel;
using System.Linq;

namespace EnumHelper.Sample
{
	internal class Program
	{
		internal enum TestEnum
		{
			[Description("ITEM 1 DESCRIPTION")]
			Item1
		}

		private static void Main()
		{
			Console.WriteLine($"{EnumHelper<TestEnum>.GetDescription(TestEnum.Item1)}");
			Console.WriteLine("\nFINISHED");
			Console.ReadLine();
		}
	}

	internal static class EnumHelper<T> where T : struct
	{
		internal static string GetDescription(T value)
		{
			var field = typeof(T).GetField(value.ToString());
			return field.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().Select(x => x.Description).FirstOrDefault();
		}
	}
}