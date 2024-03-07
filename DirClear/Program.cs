using System.Text;

namespace DirClear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\\Users\\SadCy\\OneDrive\\Рабочий стол\\Новая папка";
            string configPath = @"C:\\Codes\\C#\\Own\\DirClear\\DirClear\\config.txt";

            using (FileStream fstream = File.OpenRead(configPath))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.ReadAsync(buffer, 0, buffer.Length);
                // декодируем байты в строкуs
                string textFromFile = Encoding.Default.GetString(buffer);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
            //Router.Run(path);
        }
    }
}
