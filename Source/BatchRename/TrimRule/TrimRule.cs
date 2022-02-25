using RenameRuleLib;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace TrimRule
{
    enum TrimTypeEnum : int
    {
        REMOVE_FIRST_LAST_SPACE = 0,
        REMOVE_ALL_SPACE = 1,
    }


    public class TrimRule : IRenameRule
    {
        public int Type { get; set; }

        public TrimRule()
        {
            Type = (int)TrimTypeEnum.REMOVE_FIRST_LAST_SPACE;
        }

        public TrimRule(int type)
        {
            Type = type;
        }

        public string MagicWord
        {
            get => "Trim";
        }

        public IRenameRule Clone()
        {
            return new TrimRule();
        }

        public string ToString()
        {

            StringBuilder builder = new StringBuilder();

            builder.Append(MagicWord);
            builder.Append(" ");
            builder.Append($"\"{Type}\"");

            string result = builder.ToString();
            return result;

        }

        public string Rename(string original)
        {
            string result = original;
            switch (Type)
            {
                case (int)TrimTypeEnum.REMOVE_FIRST_LAST_SPACE:
                    {
                        string partern = @"^\s+|\s+$";
                        Regex trimmer = new Regex(partern);
                        result = trimmer.Replace(result, "");

                        return result;
                    }
                case (int)TrimTypeEnum.REMOVE_ALL_SPACE:
                    {
                        string partern = @"\s+";
                        Regex trimmer = new Regex(partern);
                        result = trimmer.Replace(result, "");
                        return result;
                    }
                default:
                    return original;
            }

        }
        public string ShowDialog()
        {

            TrimDialog trimDialog = new TrimDialog(Type);
            trimDialog.ParametersRuleChanged += TrimDialog_ParametersRuleChanged;

            Window trimWindow = new Window
            {
                Title = "Trim",
                Content = trimDialog,
                Width = 300,
                Height = 250
            };
            trimWindow.ShowDialog();



            if (trimWindow.DialogResult == true)
            {
                TrimRuleToStringConverter trimRuleToStringConverter = new TrimRuleToStringConverter();


                string result = trimRuleToStringConverter.convert(this);

                Type = 0;
                return result;
            }
            return "";
        }

        private void TrimDialog_ParametersRuleChanged(object sender, TrimDialog.ParametersRuleChangedEventArgs e)
        {
            Type = e.Type;
        }
    }
}
