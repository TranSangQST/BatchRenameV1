using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename
{
    public class RenameRuleFactory
    {
        Dictionary<string, IRenameRule> _prototypes = null; // Prototype

        public RenameRuleFactory()
        {

            _prototypes = new Dictionary<string, IRenameRule>();
            // Nạp danh sách các tập tin dll
            string exePath = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(exePath);
            var fis = new DirectoryInfo(folder).GetFiles("*.dll");

            foreach (var f in fis) // Lần lượt duyệt qua các file dll
            {
                var assembly = Assembly.LoadFile(f.FullName);
                var types = assembly.GetTypes();

                foreach (var t in types)
                {
                    if (t.IsClass && typeof(IRenameRule).IsAssignableFrom(t))
                    {
                        IRenameRule renameRule = (IRenameRule)Activator.CreateInstance(t);
                        _prototypes.Add(renameRule.MagicWord, renameRule);
                    }
                }
            }
        }

        public IRenameRule Create(string choice)
        {
            IRenameRule renameRule = _prototypes[choice].Clone();

            return renameRule;
        }

        public List<IRenameRule> getAllRule()
        {
            return _prototypes.Values.ToList();
        }


    }
}
