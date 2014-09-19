using System.IO;

namespace WebAPI
{
    public static class ExtensionMethods
    {
        public static void Rename(this FileInfo fileInfo, string newName)
        {
            if (fileInfo.Directory != null) 
                fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName);
        }
    }
}