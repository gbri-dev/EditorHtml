using System;
using System.Text;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Modo Editor");
            Console.WriteLine("---------------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("----------------");
            Console.WriteLine(" Deseja salvar o arquivo? \n 1 - SIM \n 2 - NÃO");
            short option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: Viewer.Salvar(file.ToString()); break;
                case 2: Menu.Show(); break;
                default: Viewer.Show(file.ToString()); break;
            }
        }
    }
}