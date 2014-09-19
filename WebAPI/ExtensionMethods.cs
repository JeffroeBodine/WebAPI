using System.IO;
using System.Linq;

namespace WebAPI
{
    public static class ExtensionMethods
    {
        public static void Rename(this FileInfo fileInfo, string newName)
        {
            if (fileInfo.Directory != null)
                fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName);
        }

        public static string StripIllegalFilePathCharacters(this string str)
        {
            return Path.GetInvalidFileNameChars().Aggregate(str, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

    }
}