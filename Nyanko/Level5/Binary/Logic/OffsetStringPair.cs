namespace Nyanko.Level5.Binary.Logic
{
    public class OffsetTextPair
    {
        public int Offset { get; set; }
        public string Text { get; set; }

        public bool IsNull { get; set; }

        public OffsetTextPair(int offset, string text)
        {
            Offset = offset;
            Text = text;
        }

        public OffsetTextPair(int offset, string text, bool isNull)
        {
            Offset = offset;
            Text = text;
            IsNull = isNull;
        }
    }
}
