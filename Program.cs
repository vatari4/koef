using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Укажите путь к вашему Python интерпретатору
        string pythonInterpreter = @"C:/Users/mehak/AppData/Local/Programs/Python/Python312/python.exe"; 
        // Укажите путь к вашему Python скрипту
        string scriptPath = @"c:/Users/mehak/Downloads/Datchik-3.4/Datchik-3.4/templates/prob solvp.py"; 

        // Создаем новый процесс
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = pythonInterpreter;
        start.Arguments = $"\"{scriptPath}\""; // Обратите внимание на кавычки вокруг пути к скрипту
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        start.CreateNoWindow = true;

        // Запускаем процесс и захватываем выходной поток
        using (Process process = Process.Start(start))
        {
            using (System.IO.StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                Console.WriteLine("Output: " + result);
            }

            using (System.IO.StreamReader reader = process.StandardError)
            {
                string error = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Error: " + error);
                }
            }
        }
    }
}
