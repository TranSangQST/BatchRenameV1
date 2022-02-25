using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RenameRuleLib
{
    public interface IRenameRuleToStringConverter
    {
        string MagicWord { get; }
        public string convert(IRenameRule renameRule);
    }
}
