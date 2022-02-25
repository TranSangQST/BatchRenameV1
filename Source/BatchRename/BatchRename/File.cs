using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename
{
    public class File : INotifyPropertyChanged, ICloneable
    {
        public string OldName { get; set; }
        public string NewName { get; set; }

        public string SimpleName { get; set; }
        public string Extension { get; set; }

        public string Path { get; set; }
        public string BatchStatus { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
