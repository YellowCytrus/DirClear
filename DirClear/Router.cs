using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirClear
{
    public class Router
    {
        public Router() { }

        public void Run(string currentPath, string configPath, Mover mover)
        {
            Dictionary<string, string> execToPath = mover.SetDictOfPathes(configPath);
            string[] pathes = Directory.GetFiles(currentPath);

            foreach (string s in pathes)
            {
                mover.MoveFile(s, execToPath);
            }
        }
    }
}
