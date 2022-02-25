using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWordRule
{
    public class AddWordRuleParser : IRenameRuleParser
    {
        public string MagicWord
        {
            get => "AddWord";
        }

        public IRenameRule Parse(string infor)
        {
            string[] tokens = infor.Split(new string[] { "AddWord " }, StringSplitOptions.None);
            string[] parts = tokens[1].Split(new string[] { " " }, StringSplitOptions.None);
            string word = parts[0].Substring(1, parts[0].Length - 2);
            int type = int.Parse(parts[1].Substring(1, parts[1].Length - 2));
            IRenameRule rule = new AddWordRule(word, type);
            return rule;
        }
    }
}
