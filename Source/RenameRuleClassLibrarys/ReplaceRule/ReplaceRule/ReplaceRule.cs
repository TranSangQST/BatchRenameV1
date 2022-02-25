using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ReplaceRule
{
    public class ReplaceRule: IRenameRule
    {

        public string Needle { get; set; }
        public string Replacer { get; set; }

        public ReplaceRule()
        {
            Needle = "";
            Replacer = "";
        }

        public ReplaceRule(string needle, string replacer)
        {
            Needle = needle;
            Replacer = replacer;
        }

        public string MagicWord
        {
            get => "Replace";
        }

        public IRenameRule Clone()
        {
            return new ReplaceRule();
        }

        public string ToString()
        {

            StringBuilder builder = new StringBuilder();

            builder.Append(MagicWord);
            builder.Append(" ");
            builder.Append($"\"{Needle}\"");
            builder.Append(" => ");
            builder.Append($"\"{Replacer}\"");

            string result = builder.ToString();
            return result;

        }


        public string Rename(string original)
        {
            string result = original;
            result = result.Replace(Needle, Replacer);

            return result;
        }

        public string ShowDialog()
        {

            ReplaceDialog replaceDialog = new ReplaceDialog(Needle, Replacer);


            replaceDialog.ParametersRuleChanged += ReplaceDialog_ParametersRuleChanged;

            Window replaceWindow = new Window
            {
                Title = "Replace",
                Content = replaceDialog,
                Width = 300,
                Height = 250
            };
            replaceWindow.ShowDialog();



            if (replaceWindow.DialogResult == true)
            {
                ReplaceRuleToStringConverter replaceRuleToStringConverter = new ReplaceRuleToStringConverter();
                string result = replaceRuleToStringConverter.convert(this);

                Needle = "";
                Replacer = "";
                return result;
            }
            return "";
        }

        private void ReplaceDialog_ParametersRuleChanged(object sender, ReplaceDialog.ParametersRuleChangedEventArgs e)
        {
            Needle = e.Needle;
            Replacer = e.Replacer;
        }
    }
}
