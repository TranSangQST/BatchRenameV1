using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCaseRule
{

    public class NewCaseRuleParser : IRenameRuleParser
    {
        public string MagicWord
        {
            get => "NewCase";
        }

        public IRenameRule Parse(string infor)
        {
            string[] tokens = infor.Split(new string[] { "NewCase " }, StringSplitOptions.None);

            int type = int.Parse(tokens[1].Substring(1, tokens[1].Length - 2));


            IRenameRule rule = new NewCaseRule(type);

            return rule;
        }
    }
}
