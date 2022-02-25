using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWordRule
{
    public class AddWordRuleToStringConverter : IRenameRuleToStringConverter
    {
        public string MagicWord
        {
            get => "AddWord";
        }

        public string convert(IRenameRule renameRule)
        {
            AddWordRule addWordRule = (AddWordRule)renameRule;

            StringBuilder builder = new StringBuilder();

            builder.Append(addWordRule.MagicWord);
            builder.Append(" ");
            builder.Append($"\"{addWordRule.Word}\"");
            builder.Append(" ");
            builder.Append($"\"{addWordRule.Type}\"");

            string result = builder.ToString();
            return result;
        }
    }
}
