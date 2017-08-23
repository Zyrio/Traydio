using System.IO;
using System.Text;

namespace Traydio
{
    public class Utilities
    {
        public static MemoryStream GenerateStreamFromString(string value, Encoding encoding)
        {
            return new MemoryStream(encoding.GetBytes(value ?? ""));
        }

        public static string ReplaceLastOccurrence(string source, string find, string replace)
        {
            int place = source.LastIndexOf(find);

            if (place == -1)
                return source;

            string result = source.Remove(place, find.Length).Insert(place, replace);
            return result;
        }
    }
}
