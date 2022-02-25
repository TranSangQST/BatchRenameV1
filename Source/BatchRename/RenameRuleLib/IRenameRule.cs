using System;

namespace RenameRuleLib
{
    public interface IRenameRule
    {
        string MagicWord { get; }
        string Rename(string original);
        string ShowDialog();
        string ToString();
        IRenameRule Clone();
    }
}

