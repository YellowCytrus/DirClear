using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirClear
{
    public delegate void Move(string s);
    internal abstract class Router
    {
        static Move move = Mover.MoveFile;

        public static void Run(string currentPath, string configPath)
        {
            Mover.SetDictOfPathes(configPath);
            string[] pathes = Directory.GetFiles(currentPath);

            foreach (string s in pathes)
            {
                move(s);
            }
        }
    }
}
