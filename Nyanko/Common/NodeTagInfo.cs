using StudioElevenLib.Level5.Text.Logic;

namespace Nyanko.Common
{
    public class NodeTagInfo
    {
        public string Tag { get; set; }
        public StringLevel5 StringRef { get; set; }
        public NodeTagInfo(string tag, StringLevel5 stringRef = null)
        {
            Tag = tag;
            StringRef = stringRef;
        }
        public override string ToString() => Tag;
    }
}
