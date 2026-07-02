using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameAnalyticsSDK.Utilities
{
	public class GA_MiniJSON
	{
		public sealed class Parser : IDisposable
		{
			public enum TOKEN
			{
				NONE = 0,
				CURLY_OPEN = 1,
				CURLY_CLOSE = 2,
				SQUARED_OPEN = 3,
				SQUARED_CLOSE = 4,
				COLON = 5,
				COMMA = 6,
				STRING = 7,
				NUMBER = 8,
				TRUE = 9,
				FALSE = 10,
				NULL = 11
			}

			public const string WORD_BREAK = "{}[],:\"";

			[NonSerialized]
			public StringReader json;

			public char PeekChar => '\0';

			public char NextChar => '\0';

			public string NextWord => null;

			public TOKEN NextToken => default(TOKEN);

			public static bool IsWordBreak(char c)
			{
				return false;
			}

			public Parser(string jsonString)
			{
			}

			public static object Parse(string jsonString)
			{
				return null;
			}

			public void Dispose()
			{
			}

			public Dictionary<string, object> ParseObject()
			{
				return null;
			}

			public List<object> ParseArray()
			{
				return null;
			}

			public object ParseValue()
			{
				return null;
			}

			public object ParseByToken(TOKEN token)
			{
				return null;
			}

			public string ParseString()
			{
				return null;
			}

			public object ParseNumber()
			{
				return null;
			}

			public void EatWhitespace()
			{
			}
		}

		public sealed class Serializer
		{
			[NonSerialized]
			public StringBuilder builder;

			public static string Serialize(object obj)
			{
				return null;
			}

			public void SerializeValue(object value)
			{
			}

			public void SerializeObject(IDictionary obj)
			{
			}

			public void SerializeArray(IList anArray)
			{
			}

			public void SerializeString(string str)
			{
			}

			public void SerializeOther(object value)
			{
			}
		}

		public static object Deserialize(string json)
		{
			return null;
		}

		public static string Serialize(object obj)
		{
			return null;
		}
	}
}
