using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DirClear
{
    internal abstract class Mover
    {
        static Dictionary<string, string> ExecToPath = new Dictionary<string, string>()
        {
            { "pptx", @"C:\\Users\\SadCy\\OneDrive\\Рабочий стол\\Новая папка (2)" }
        };

        public static void MoveFile (string CurrentPath)
        {
            FileInfo fileInfo = new FileInfo(CurrentPath);
            string extension = fileInfo.Extension.Trim('.');

            if (!ExecToPath.ContainsKey(extension)) return;

            string targetPath = ExecToPath[extension] + '\\' + fileInfo.Name;

            File.Move(CurrentPath, targetPath);
        }

    }
}
