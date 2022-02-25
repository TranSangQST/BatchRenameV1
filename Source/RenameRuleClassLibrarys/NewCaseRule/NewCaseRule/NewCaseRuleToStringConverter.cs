using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCaseRule
{
    public class NewCaseRuleToStringConverter : IRenameRuleToStringConverter
    {
        public string MagicWord
        {
            get => "NewCase";
        }

        public string convert(IRenameRule renameRule)
        {
            NewCaseRule newCaseRule = (NewCaseRule)renameRule;

            StringBuilder builder = new StringBuilder();

            builder.Append(newCaseRule.MagicWord);
            builder.Append(" ");
            builder.Append($"\"{newCaseRule.Type}\"");

            string result = builder.ToString();
            return result;
        }
    }
}
