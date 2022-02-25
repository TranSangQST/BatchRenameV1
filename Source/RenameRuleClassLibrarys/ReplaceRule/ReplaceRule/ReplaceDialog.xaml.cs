using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReplaceRule
{
    /// <summary>
    /// Interaction logic for ReplaceDialog.xaml
    /// </summary>
    public partial class ReplaceDialog : UserControl
    {
        public ReplaceDialog(string needle, string replacer)
        {
            InitializeComponent();
            replaceFromTextbox.Text = needle;
            replaceToTextbox.Text = replacer;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string needle = replaceFromTextbox.Text;
            string replacer = replaceToTextbox.Text;
            onParametersRuleChanged(needle, replacer);
            Window.GetWindow(this).DialogResult = true;

        }


        private event EventHandler<ParametersRuleChangedEventArgs> _ParametersRuleChanged;
        public event EventHandler<ParametersRuleChangedEventArgs> ParametersRuleChanged
        {
            add
            {
                _ParametersRuleChanged += value;
            }
            remove
            {
                _ParametersRuleChanged -= value;
            }
        }


        void onParametersRuleChanged(string needle, string replacer)
        {
            if (_ParametersRuleChanged != null)
            {
                _ParametersRuleChanged(this, new ParametersRuleChangedEventArgs(needle, replacer));
            }
        }

        public class ParametersRuleChangedEventArgs : EventArgs
        {
            public string Needle { get; set; }
            public string Replacer { get; set; }
            public ParametersRuleChangedEventArgs(string needle, string replacer)
            {
                Needle = needle;
                Replacer = replacer;
            }
        }
    }
}
