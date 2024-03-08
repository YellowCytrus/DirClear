using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DirClear
{
    internal class Mover
    {
        static Dictionary<string, string> execToPath = new Dictionary<string, string>();

        public static void SetDictOfPathes(string configPath)
        {
            using (FileStream fstream = File.OpenRead(configPath))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.ReadAsync(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);

                string[] exec_path = textFromFile.Split('\n');

                foreach (string line in exec_path)
                {
                    if (line.Equals(string.Empty)) { break; }

                    string[] splitedLine = line.Split('\t');
                    string pathInDict = "";

                    for (int i = 1; i < splitedLine.Length; i++)
                    {
                        pathInDict += splitedLine[i];
                    }

                    execToPath[splitedLine[0]] = pathInDict;
                }
            }
        }

        public static void MoveFile (string currentPath)
        {
            FileInfo fileInfo = new FileInfo(currentPath);
            string extension = fileInfo.Extension.Trim('.');

            if (!execToPath.ContainsKey(extension)) return;


            string targetPath = execToPath[extension] + '\\' + fileInfo.Name;

            string b = $"{fileInfo.Name}";

            string c = string.Format("{0}{1}", execToPath[extension], b);
            Console.WriteLine(c);

            
            //Console.WriteLine("String" + "\\" + ".txt");
            //File.Move(CurrentPath, targetPath);
        }

    }
}
