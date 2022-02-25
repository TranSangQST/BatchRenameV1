using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceRule
{
    public class ReplaceRuleParser : IRenameRuleParser
    {
        public string MagicWord
        {
            get => "Replace";
        }

        public IRenameRule Parse(string infor)
        {
            string[] tokens = infor.Split(new string[] { "Replace " }, StringSplitOptions.None);
            string[] parts = tokens[1].Split(new string[] { " => " }, StringSplitOptions.None);
            // Remove []

            string needle = parts[0].Substring(1, parts[0].Length - 2);

            string replacement = parts[1].Substring(1, parts[1].Length - 2);

            IRenameRule rule = new ReplaceRule(needle, replacement);
            return rule;
        }
    }
}
