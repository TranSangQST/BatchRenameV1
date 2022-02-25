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

namespace TrimRule
{
    /// <summary>
    /// Interaction logic for TrimDialog.xaml
    /// </summary>
    public partial class TrimDialog : UserControl
    {
        public TrimDialog(int type)
        {
            InitializeComponent();

            if (type == 0)
            {
                trimTypeRBtn0.IsChecked = true;
            }
            else if (type == 1)
            {
                trimTypeRBtn1.IsChecked = true;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            int type = 0;
            if (Convert.ToBoolean(trimTypeRBtn0.IsChecked))
            {
                type = 0;
            }
            else if (Convert.ToBoolean(trimTypeRBtn1.IsChecked))
            {
                type = 1; ;
            }
            //string x = trimTypeGroupBox.Content;

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
