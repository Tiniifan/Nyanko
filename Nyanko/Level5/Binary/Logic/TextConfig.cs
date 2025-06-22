using System.Collections.Generic;

namespace Nyanko.Level5.Binary.Logic
{
    public class TextConfig
    {
        public int WashaID;

        public List<StringLevel5> Strings;

        public TextConfig()
        {

        }

        public TextConfig(List<StringLevel5> strings, int washaID = 0)
        {
            WashaID = washaID;
            Strings = strings;
        }
    }

    public class StringLevel5
    {
        public int TextNumber;

        public int VarianceText;

        public string Text;

        public StringLevel5()
        {

        }

        public StringLevel5(int textNumber, string text)
        {
            TextNumber = textNumber;
            Text = text;
        }

        public StringLevel5(int textNumber, string text, int varianceText)
        {
            TextNumber = textNumber;
            Text = text;
            VarianceText = varianceText;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
