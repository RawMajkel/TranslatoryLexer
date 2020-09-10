namespace TranslatoryLexer.App
{
    public class Token
    {
        public string Nazwa { get; set; }
        public string Argument { get; set; }
        public int Index { get; set; }


        public Token(string nazwa, string argument, int index)
        {
            Nazwa = nazwa;
            Argument = argument;
            Index = index;
        }
    }
}
