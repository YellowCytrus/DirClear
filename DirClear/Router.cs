using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirClear
{
    public abstract class Router
    {

        public static void Run(string currentPath, string configPath)
        {
            
            string[] pathes = Directory.GetFiles(currentPath);
            Mover.SetDictOfPathes(configPath);

            foreach (string s in pathes)
            {
                Mover.MoveFile(s);
            }
        }
    }
}
