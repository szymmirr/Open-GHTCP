using System;
using System.Collections.Generic;
using ns14;

namespace ns15
{
	public class InstrumentType : Track<int, List<string>>
	{
		public InstrumentType()
		{
		}

		public InstrumentType(string[] string_0) : this()
		{
			if (string_0.Length != 0)
			{
				for (int i = 0; i < string_0.Length; i++)
				{
					string text = string_0[i];
					string[] array = text.Split(new[]
					{
						' ',
						'\t',
						'=',
						'"',
						'E'
					}, StringSplitOptions.RemoveEmptyEntries);
                    method_5(ChartParser.getNoteFromResolution(array[0]), array[1]);
				}
			}
		}

		public void method_5(int int_0, string string_0)
		{
			if (ContainsKey(int_0))
			{
				base[int_0].Add(string_0);
				return;
			}
			Add(int_0, new List<string>(new[]
			{
				string_0
			}));
		}
	}
}
