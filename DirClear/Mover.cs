using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DirClear
{
    public abstract class Mover
    {
        static Dictionary<string, string> execToPath = new Dictionary<string, string>();

        static public void SetDictOfPathes(string configPath)
        {
            Dictionary<string, string> execToPath = new Dictionary<string, string>();
            string textFromFile = File.ReadAllText(configPath);
            string[] exec_path = textFromFile.Split('\n');

            foreach (string line in exec_path)
            {
                if (line.Equals(string.Empty)) { break; }

                string[] splitedLine = line.Split('\t');
                string pathInDict = string.Join(' ', splitedLine.Skip(1)).Trim([' ', '\t']);
                
                execToPath[splitedLine[0]] = pathInDict;
            }
        }

        public static void MoveFile (string currentPath)
        {
            FileInfo fileInfo = new FileInfo(currentPath);
            string extension = fileInfo.Extension.Trim('.');

            if (!execToPath.ContainsKey(extension)) return;

            string path = execToPath[extension].Replace("\r", "");
            string name = fileInfo.Name;

            if (path.Equals(string.Empty) || name.Equals(string.Empty)) return;

            string targetPath = path + '\\' + name;

            File.Move(currentPath, targetPath);
        }

    }
}
