namespace Nyanko.Common
{
    public enum SpeakerType
    {
        None,
        Female,
        Male,
        Narrator
    }

    public class SpeakerInfo
    {
        public SpeakerType Type { get; set; }
        public string Name { get; set; }

        public SpeakerInfo(SpeakerType type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}