using System.Text;

namespace DirClear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\\Users\\SadCy\\OneDrive\\Рабочий стол\\Новая папка";
            string configPath = @"C:\\Codes\\C#\\Own\\DirClear\\DirClear\\config.txt";

            Router.Run(path, configPath);
        }
    }
}
