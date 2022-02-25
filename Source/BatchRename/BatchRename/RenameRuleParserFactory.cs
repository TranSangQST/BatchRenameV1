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
    class RenameRuleParserFactory
    {
        Dictionary<string, IRenameRuleParser> _prototypes = null; // Prototype

        public RenameRuleParserFactory()
        {

            _prototypes = new Dictionary<string, IRenameRuleParser>();
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
                    if (t.IsClass && typeof(IRenameRuleParser).IsAssignableFrom(t))
                    {
                        IRenameRuleParser renameRuleParser = (IRenameRuleParser)Activator.CreateInstance(t);
                        _prototypes.Add(renameRuleParser.MagicWord, renameRuleParser);
                    }
                }
            }
        }

        public IRenameRuleParser Create(string choice)
        {
            IRenameRuleParser renameRuleParser = _prototypes[choice];
            return renameRuleParser;
        }

        public List<IRenameRuleParser> getAllIRenameRuleParser()
        {
            return _prototypes.Values.ToList();
        }

    }
}
