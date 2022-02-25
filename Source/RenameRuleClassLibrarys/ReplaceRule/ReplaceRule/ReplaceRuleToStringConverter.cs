using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceRule
{
    public class ReplaceRuleToStringConverter : IRenameRuleToStringConverter
    {
        public string MagicWord
        {
            get => "Replace";
        }

        public string convert(IRenameRule renameRule)
        {
            ReplaceRule replaceRule = (ReplaceRule)renameRule;

            StringBuilder builder = new StringBuilder();

            builder.Append(replaceRule.MagicWord);
            builder.Append(" ");
            builder.Append($"\"{replaceRule.Needle}\"");
            builder.Append(" => ");
            builder.Append($"\"{replaceRule.Replacer}\"");

            string result = builder.ToString();
            return result;
        }
    }
}
