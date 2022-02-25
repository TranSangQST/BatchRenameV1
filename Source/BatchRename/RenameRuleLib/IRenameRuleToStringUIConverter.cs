using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    public interface IRenameRuleToStringUIConverter
    {
        string MagicWord { get; }
        public string convert(IRenameRule renameRule);
    }
}
