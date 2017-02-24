using System.Text;
using System;

namespace Core
{
	public static class PhonewordTranslator
	{
		public static string ToNumber(string raw)
		{
			if (string.IsNullOrWhiteSpace(raw))
				return "";
			else
				raw = raw.ToUpperInvariant();

			var newNumber = new StringBuilder();

			foreach (var character in raw)
			{
				if (" -0123456789".Contains(character))
					newNumber.Append(character);
				else
				{
					var result = TranslateToNumber(character);
					if (result != null)
						newNumber.Append(result);
				}
				//otherwise we've skipped a non-numeric char
			}

			return newNumber.ToString();
		}

		static bool Contains(this string keyString, char character)
		{
			return keyString.IndexOf(character) >= 0;
		}

		static int? TranslateToNumber(char character)
		{
			if ("ABC".Contains(character))
				return 2;
			else if ("DEF".Contains(character))
				return 3;
			else if ("GHI".Contains(character))
				return 4;
			else if ("JKL".Contains(character))
				return 5;
			else if ("MNO".Contains(character))
				return 6;
			else if ("PQRS".Contains(character))
				return 7;
			else if ("TUV".Contains(character))
				return 8;
			else if ("WXYZ".Contains(character))
				return 9;
			return null;
		}
}
}