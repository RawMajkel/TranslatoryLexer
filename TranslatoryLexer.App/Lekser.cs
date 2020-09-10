using System.Collections.Generic;

namespace TranslatoryLexer.App
{
    public class Lekser
    {
        public List<Token> TablicaSymboli = new List<Token>();
        public bool Analizuj(string wyrazenie)
        {
            var indeks = 0;
            var wynik = new WynikAnalizyLeksykalnej
            {
                Wynik = false
            };

            while (indeks < wyrazenie.Length && (wynik = S(wyrazenie, indeks)).Wynik)
            {
                TablicaSymboli.Add(wynik.Token);
                indeks += wynik.Token.Argument.Length;
            }
            return wynik.Wynik;
        }

        public WynikAnalizyLeksykalnej S(string wyrazenie, int i)
        {
            WynikAnalizyLeksykalnej wynik;

            if ((wynik = N(wyrazenie, i)).Wynik) return wynik;
            if ((wynik = O(wyrazenie, i)).Wynik) return wynik;
            if ((wynik = B(wyrazenie, i)).Wynik) return wynik;
            if ((wynik = L(wyrazenie, i)).Wynik) return wynik;

            return wynik;
        }

        public WynikAnalizyLeksykalnej N(string wyrazenie, int i)
        {
            var wynik = new WynikAnalizyLeksykalnej();

            if (wyrazenie[i] == '(' || wyrazenie[i] == ')')
            {
                wynik.Wynik = true;
                wynik.Token = new Token(TypTokenu.Nawias, wyrazenie[i].ToString(), i);
                return wynik;
            }

            wynik.Wynik = false;
            return wynik;
        }

        public WynikAnalizyLeksykalnej O(string wyrazenie, int i)
        {
            var wynik = new WynikAnalizyLeksykalnej();

            if (wyrazenie[i] == '+' || wyrazenie[i] == '-' || wyrazenie[i] == '*' || wyrazenie[i] == '/')
            {
                wynik.Wynik = true;
                wynik.Token = new Token(TypTokenu.Operator, wyrazenie[i].ToString(), i);
                return wynik;
            }

            wynik.Wynik = false;
            return wynik;
        }
        public WynikAnalizyLeksykalnej B(string wyrazenie, int i)
        {
            WynikAnalizyLeksykalnej bufor, wynik = new WynikAnalizyLeksykalnej();

            if (wyrazenie.Length >i +1 && wyrazenie[i] == ' ' && (bufor = B(wyrazenie, i+1)).Wynik)
            {
                wynik.Wynik = true;
                wynik.Token = new Token(TypTokenu.BialeZnaki, wyrazenie[i].ToString() + bufor.Token.Argument, i);
                return wynik;
            } else if (wyrazenie[i] == ' ')
            {
                wynik.Wynik = true;
                wynik.Token = new Token(TypTokenu.BialeZnaki, wyrazenie[i].ToString(), i);
                return wynik;
            }

            wynik.Wynik = false;
            return wynik;
        }
        public WynikAnalizyLeksykalnej L(string wyrazenie, int i)
        {
            WynikAnalizyLeksykalnej bufor, wynik = new WynikAnalizyLeksykalnej();

            if (wyrazenie.Length > i + 1 && "123456789".Contains(wyrazenie[i]) && (bufor = L(wyrazenie, i + 1)).Wynik)
            {
                wynik.Wynik = true;
                wynik.Token = new Token(TypTokenu.Liczba, wyrazenie[i].ToString() + bufor.Token.Argument, i);
                return wynik;
            }
            else if (wyrazenie[i] == '0')
            {
                wynik.Wynik = true;
                wynik.Token = new Token(TypTokenu.Liczba, wyrazenie[i].ToString(), i);
                return wynik;
            }
            else if ("123456789".Contains(wyrazenie[i]))
            {
                wynik.Wynik = true;
                wynik.Token = new Token(TypTokenu.Liczba, wyrazenie[i].ToString(), i);
                return wynik;
            }

            wynik.Wynik = false;
            return wynik;
        }
    }
}
