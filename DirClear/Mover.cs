using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DirClear
{
    public class Mover
    {
        StringBuilder builder = new StringBuilder();
        public Mover() { }

        public Dictionary<string, string> SetDictOfPathes(string configPath)
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
            return execToPath;
        }

        public void MoveFile (string currentPath, Dictionary<string, string> execToPath)
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
