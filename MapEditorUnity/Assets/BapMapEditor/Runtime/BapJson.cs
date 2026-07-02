using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

// Minimal, dependency-free JSON reader. Parses into Dictionary<string,object> /
// List<object> / string / double / bool / null. Kept tiny on purpose so the map
// core has zero external dependencies (compiles in Unity and in the test harness).
namespace BapMapEditor
{
    public static class BapJson
    {
        public static object Parse(string text)
        {
            int i = 0;
            object v = ParseValue(text, ref i);
            SkipWs(text, ref i);
            if (i != text.Length) throw new FormatException($"Trailing characters at {i}");
            return v;
        }

        static object ParseValue(string s, ref int i)
        {
            SkipWs(s, ref i);
            if (i >= s.Length) throw new FormatException("Unexpected end of JSON");
            char c = s[i];
            switch (c)
            {
                case '{': return ParseObject(s, ref i);
                case '[': return ParseArray(s, ref i);
                case '"': return ParseString(s, ref i);
                case 't': case 'f': return ParseBool(s, ref i);
                case 'n': Expect(s, ref i, "null"); return null;
                default: return ParseNumber(s, ref i);
            }
        }

        static Dictionary<string, object> ParseObject(string s, ref int i)
        {
            var d = new Dictionary<string, object>();
            i++; // {
            SkipWs(s, ref i);
            if (s[i] == '}') { i++; return d; }
            while (true)
            {
                SkipWs(s, ref i);
                string key = ParseString(s, ref i);
                SkipWs(s, ref i);
                if (s[i] != ':') throw new FormatException($"Expected ':' at {i}");
                i++;
                d[key] = ParseValue(s, ref i);
                SkipWs(s, ref i);
                if (s[i] == ',') { i++; continue; }
                if (s[i] == '}') { i++; break; }
                throw new FormatException($"Expected ',' or '}}' at {i}");
            }
            return d;
        }

        static List<object> ParseArray(string s, ref int i)
        {
            var list = new List<object>();
            i++; // [
            SkipWs(s, ref i);
            if (s[i] == ']') { i++; return list; }
            while (true)
            {
                list.Add(ParseValue(s, ref i));
                SkipWs(s, ref i);
                if (s[i] == ',') { i++; continue; }
                if (s[i] == ']') { i++; break; }
                throw new FormatException($"Expected ',' or ']' at {i}");
            }
            return list;
        }

        static string ParseString(string s, ref int i)
        {
            if (s[i] != '"') throw new FormatException($"Expected string at {i}");
            i++;
            var sb = new StringBuilder();
            while (s[i] != '"')
            {
                char c = s[i++];
                if (c == '\\')
                {
                    char e = s[i++];
                    switch (e)
                    {
                        case '"': sb.Append('"'); break;
                        case '\\': sb.Append('\\'); break;
                        case '/': sb.Append('/'); break;
                        case 'b': sb.Append('\b'); break;
                        case 'f': sb.Append('\f'); break;
                        case 'n': sb.Append('\n'); break;
                        case 'r': sb.Append('\r'); break;
                        case 't': sb.Append('\t'); break;
                        case 'u':
                            int code = int.Parse(s.Substring(i, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                            sb.Append((char)code);
                            i += 4;
                            break;
                        default: throw new FormatException($"Bad escape \\{e} at {i}");
                    }
                }
                else sb.Append(c);
            }
            i++; // closing "
            return sb.ToString();
        }

        static bool ParseBool(string s, ref int i)
        {
            if (s[i] == 't') { Expect(s, ref i, "true"); return true; }
            Expect(s, ref i, "false"); return false;
        }

        static double ParseNumber(string s, ref int i)
        {
            int start = i;
            while (i < s.Length && (char.IsDigit(s[i]) || s[i] == '-' || s[i] == '+' || s[i] == '.' || s[i] == 'e' || s[i] == 'E'))
                i++;
            return double.Parse(s.Substring(start, i - start), CultureInfo.InvariantCulture);
        }

        static void Expect(string s, ref int i, string word)
        {
            if (i + word.Length > s.Length || s.Substring(i, word.Length) != word)
                throw new FormatException($"Expected '{word}' at {i}");
            i += word.Length;
        }

        static void SkipWs(string s, ref int i)
        {
            while (i < s.Length && (s[i] == ' ' || s[i] == '\t' || s[i] == '\r' || s[i] == '\n')) i++;
        }

        // Typed accessors over the parsed object graph.
        public static string Str(Dictionary<string, object> o, string k, string def)
            => o.TryGetValue(k, out var v) && v is string s ? s : def;

        public static int Int(Dictionary<string, object> o, string k, int def)
            => o.TryGetValue(k, out var v) && v is double d ? (int)Math.Round(d) : def;

        public static float Flt(Dictionary<string, object> o, string k, float def)
            => o.TryGetValue(k, out var v) && v is double d ? (float)d : def;

        public static bool Bool(Dictionary<string, object> o, string k, bool def)
            => o.TryGetValue(k, out var v) && v is bool b ? b : def;

        public static List<object> Arr(Dictionary<string, object> o, string k)
            => o.TryGetValue(k, out var v) && v is List<object> l ? l : null;
    }
}
