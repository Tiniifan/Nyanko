namespace Nyanko.Level5.Logic
{
    public class TextValue
    {
        public int Variance;

        public string Text;

        public TextValue()
        {

        }

        public TextValue(int variance, string text)
        {
            Variance = variance;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
