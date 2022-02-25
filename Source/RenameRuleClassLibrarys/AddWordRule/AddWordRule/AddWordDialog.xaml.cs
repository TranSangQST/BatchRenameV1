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

namespace AddWordRule
{
    /// <summary>
    /// Interaction logic for AddWordDialog.xaml
    /// </summary>
  public partial class AddWordDialog : UserControl
    {

        public AddWordDialog(string word, int type)
        {
            InitializeComponent();


            addWordTextBox.Text = word;
            addWordTypeCB.SelectedIndex = type;

        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            string word = addWordTextBox.Text;
            int type = addWordTypeCB.SelectedIndex;
            onParametersRuleChanged(word, type);
            Window.GetWindow(this).DialogResult = true;
            return;
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


        void onParametersRuleChanged(string word, int type)
        {
            if (_ParametersRuleChanged != null)
            {
                _ParametersRuleChanged(this, new ParametersRuleChangedEventArgs(word, type));
            }
        }

        public class ParametersRuleChangedEventArgs : EventArgs
        {
            public string Word { get; set; }
            public int Type { get; set; }
            public ParametersRuleChangedEventArgs(string word, int type)
            {
                Word = word;
                Type = type;
            }
        }
    }

    
}
