namespace Nyanko.Common
{
    public class CharacterInfo
    {
        public int Id { get; }
        public string Name { get; }

        public CharacterInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}