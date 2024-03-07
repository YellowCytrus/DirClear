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

        public static void Run(string path)
        {
            string[] pathes = Directory.GetFiles(path);

            foreach (string s in pathes)
            {
                move(s);
            }
        }
    }
}
