using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrimRule
{
    public class TrimRuleToStringConverter : IRenameRuleToStringConverter
    {
        public string MagicWord
        {
            get => "Trim";
        }

        public string convert(IRenameRule renameRule)
        {
            TrimRule trimeRule = (TrimRule)renameRule;

            StringBuilder builder = new StringBuilder();

            builder.Append(trimeRule.MagicWord);
            builder.Append(" ");
            builder.Append($"\"{trimeRule.Type}\"");

            string result = builder.ToString();
            return result;
        }
    }
}
