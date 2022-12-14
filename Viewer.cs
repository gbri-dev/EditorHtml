using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EditorHtml
{
    public static class Viewer
    {
        public static void Show(String text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO VISUALIZAÇÃO");
            Console.WriteLine("---------------");
            Replace(text);
            Console.WriteLine("----------------");
            Console.ReadKey();
            Menu.Show();
        }
        public static void Replace(String text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");//expressão regular
            var words = text.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(
                    words[i].Substring(
                    words[i].IndexOf('>') + 1, //começando pelo > menos 1 pq a lista conta o zero
                    (
                        (words[i].LastIndexOf('<') - 1 - words[i].IndexOf('>'))
                    //a segunda opção é quantidade que deseja contar
                    )
                    )
                    );
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }

        public static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho que deseja salvar? ");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso.");
            Console.ReadKey();
            Menu.Show();
        }
    }
}