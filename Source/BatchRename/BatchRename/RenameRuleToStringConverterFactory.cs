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
    class RenameRuleToStringConverterFactory
    {
        Dictionary<string, IRenameRuleToStringConverter> _prototypes = null; // Prototype

        public RenameRuleToStringConverterFactory()
        {

            _prototypes = new Dictionary<string, IRenameRuleToStringConverter>();
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
                    if (t.IsClass && typeof(IRenameRuleToStringConverter).IsAssignableFrom(t))
                    {
                        IRenameRuleToStringConverter renameRuleToStringConverter = (IRenameRuleToStringConverter)Activator.CreateInstance(t);
                        _prototypes.Add(renameRuleToStringConverter.MagicWord, renameRuleToStringConverter);
                    }
                }
            }
        }

        public IRenameRuleToStringConverter Create(string choice)
        {
            IRenameRuleToStringConverter renameRuleToStringConverter = _prototypes[choice];
            return renameRuleToStringConverter;
        }

        public List<IRenameRuleToStringConverter> getAllIRenameRuleToStringConverter()
        {
            return _prototypes.Values.ToList();
        }

    }
}
