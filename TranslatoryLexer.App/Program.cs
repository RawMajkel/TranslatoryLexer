using System;
using System.Linq;

namespace TranslatoryLexer.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var wyrazenie = "(2 + (2*34)";
            var lexer = new Lekser();

            if (lexer.Analizuj(wyrazenie))
            {
                Console.WriteLine("Rozpoznano wyrażenie");
            }
            else
            {
                int indeks;
                Console.WriteLine("Błąd analizy leksykalnej");
                Console.WriteLine("Nieznany token: {1}, na pozycji: {0}",
                    indeks = lexer.TablicaSymboli.Count() > 0 ? lexer.TablicaSymboli.Last().Index + 1 : 0,
                    wyrazenie.Substring(indeks, wyrazenie.Length > 10 ? 10 : wyrazenie.Length - indeks)
                );
            }

            foreach (var token in lexer.TablicaSymboli)
            {
                Console.WriteLine("<{0},{1}>", token.Nazwa, token.Argument);
            }
        }
    }
}
