using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyanko.Level5.Binary;
using Nyanko.Level5.Logic;

namespace Nyanko.Level5.T2bþ
{
    public class T2bþ
    {
        private CfgBin CfgBin;

        public Dictionary<int, List<TextValue>> Texts;

        public Dictionary<int, List<TextValue>> Nouns;

        public T2bþ(Stream stream)
        {
            CfgBin = new CfgBin(stream);

            Texts = CfgBin.Entries
                .Where(x => x.GetName() == "TEXT_INFO_BEGIN")
                .SelectMany(x => x.Children)
                .GroupBy(
                    x => Convert.ToInt32(x.Variables[0].Value),
                    y => new TextValue(Convert.ToInt32(y.Variables[1].Value), (y.Variables[2].Value as OffsetTextPair).Text)
                )
                .ToDictionary(group => group.Key, group => group.ToList());

            Nouns = CfgBin.Entries
                .Where(x => x.GetName() == "NOUN_INFO_BEGIN")
                .SelectMany(x => x.Children)
                .GroupBy(
                    x => Convert.ToInt32(x.Variables[0].Value),
                    y => new TextValue(Convert.ToInt32(y.Variables[1].Value), (y.Variables[5].Value as OffsetTextPair).Text)
                )
                .ToDictionary(group => group.Key, group => group.ToList());
        }

        private Dictionary<int, string> GetStringsTable()
        {
            Dictionary<int, string> output = new Dictionary<int, string>();

            string[] allTexts = Texts.Values
                .SelectMany(textList => textList)
                .Select(textValue => textValue.Text)
                .Distinct()
                .ToArray();

            string[] allNouns = Nouns.Values
                .SelectMany(textList => textList)
                .Select(textValue => textValue.Text)
                .Distinct()
                .ToArray();

            int offset = 0;
            string[] textsAndNouns = allTexts.Union(allNouns).ToArray();

            foreach(string text in textsAndNouns)
            {
                if (text != null)
                {
                    output.Add(offset, text);
                    offset += Encoding.UTF8.GetBytes(text).Length + 1;
                }
            }

            return output;
        }

        private Entry GetTextEntry(Dictionary<int, string> strings)
        {
            Entry textEntry = new Entry("TEXT_INFO_BEGIN_0", new List<Variable>() { new Variable(Logic.Type.Int, Texts.Values.Sum(textList => textList.Count)) }, true);

            foreach (KeyValuePair<int, List<TextValue>> textItem in Texts)
            {
                for (int i = 0; i < textItem.Value.Count; i++)
                {
                    TextValue textValue = textItem.Value[i];

                    Entry textItemEntry = new Entry("TEXT_INFO_" + i, new List<Variable>()
                        {
                            new Variable(Logic.Type.Int, textItem.Key),
                            new Variable(Logic.Type.Int, i),
                            new Variable(Logic.Type.String, new OffsetTextPair(strings.FirstOrDefault(x => x.Value == textValue.Text).Key, textValue.Text)),
                            new Variable(Logic.Type.Int, 0),
                        }
                    );

                    textEntry.Children.Add(textItemEntry);
                }
            }

            return textEntry;
        }

        private Entry GetNounEntry(Dictionary<int, string> strings)
        {
            Entry nounEntry = new Entry("NOUN_INFO_BEGIN_0", new List<Variable>() { new Variable(Logic.Type.Int, Nouns.Values.Sum(textList => textList.Count)) }, true);

            foreach (KeyValuePair<int, List<TextValue>> nounItem in Nouns)
            {
                for (int i = 0; i < nounItem.Value.Count; i++)
                {
                    TextValue textValue = nounItem.Value[i];

                    Entry textItemEntry = new Entry("NOUN_INFO_" + i, new List<Variable>()
                        {
                            new Variable(Logic.Type.Int, nounItem.Key),
                            new Variable(Logic.Type.Int, i),
                            new Variable(Logic.Type.String,  new OffsetTextPair(-1, null)),
                            new Variable(Logic.Type.String,  new OffsetTextPair(-1, null)),
                            new Variable(Logic.Type.String,  new OffsetTextPair(-1, null)),
                            new Variable(Logic.Type.String, new OffsetTextPair(strings.FirstOrDefault(x => x.Value == textValue.Text).Key, textValue.Text)),
                            new Variable(Logic.Type.String,  new OffsetTextPair(-1, null)),
                            new Variable(Logic.Type.String,  new OffsetTextPair(-1, null)),
                            new Variable(Logic.Type.String,  new OffsetTextPair(-1, null)),
                            new Variable(Logic.Type.String,  new OffsetTextPair(-1, null)),
                            new Variable(Logic.Type.Int, 0),
                            new Variable(Logic.Type.Int, 0),
                            new Variable(Logic.Type.Int, 0),
                            new Variable(Logic.Type.Int, 0),
                        }
                    );

                    nounEntry.Children.Add(textItemEntry);
                }
            }

            return nounEntry;
        }

        public void Save(string fileName)
        {
            Dictionary<int, string> strings = GetStringsTable();

            Entry textEntry = GetTextEntry(strings);
            Entry nounEntry = GetNounEntry(strings);

            Entry cfgbinTextEntry = CfgBin.Entries.FirstOrDefault(x => x.GetName() == "TEXT_INFO_BEGIN");
            Entry cfgbinNounEntry = CfgBin.Entries.FirstOrDefault(x => x.GetName() == "NOUN_INFO_BEGIN");

            int textEntryIndex = CfgBin.Entries.FindIndex(x => x.GetName() == "TEXT_INFO_BEGIN");
            if (textEntryIndex >= 0)
            {
                CfgBin.Entries[textEntryIndex] = textEntry;
            }
            else
            {
                CfgBin.Entries.Add(textEntry);
            }

            int nounEntryIndex = CfgBin.Entries.FindIndex(x => x.GetName() == "NOUN_INFO_BEGIN");
            if (textEntryIndex >= 0)
            {
                CfgBin.Entries[nounEntryIndex] = nounEntry;
            }
            else
            {
                CfgBin.Entries.Add(nounEntry);
            }

            CfgBin.Strings = strings;
            CfgBin.Save(fileName);
        }
    }
}
