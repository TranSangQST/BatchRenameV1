using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrimRule
{
    public class TrimRuleParser : IRenameRuleParser
    {
        public string MagicWord
        {
            get => "Trim";
        }

        public IRenameRule Parse(string infor)
        {
            string[] tokens = infor.Split(new string[] { "Trim " }, StringSplitOptions.None);

            int type = int.Parse(tokens[1].Substring(1, tokens[1].Length - 2));


            IRenameRule rule = new TrimRule(type);

            return rule;
        }
    }
}
