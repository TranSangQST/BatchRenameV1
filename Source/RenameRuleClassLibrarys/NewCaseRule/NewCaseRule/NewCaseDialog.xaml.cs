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

namespace NewCaseRule
{
    /// <summary>
    /// Interaction logic for NewCaseDialog.xaml
    /// </summary>
   public partial class NewCaseDialog : UserControl
    {

        public NewCaseDialog(int type)
        {
            InitializeComponent();

            newCaseTypeCB.SelectedIndex = type;

        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            int type = newCaseTypeCB.SelectedIndex;
            onParametersRuleChanged(type);
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


        void onParametersRuleChanged(int type)
        {
            if (_ParametersRuleChanged != null)
            {
                _ParametersRuleChanged(this, new ParametersRuleChangedEventArgs(type));
            }
        }

        public class ParametersRuleChangedEventArgs : EventArgs
        {
            public int Type { get; set; }
            public ParametersRuleChangedEventArgs(int type)
            {
                Type = type;
            }
        }
    }
}
