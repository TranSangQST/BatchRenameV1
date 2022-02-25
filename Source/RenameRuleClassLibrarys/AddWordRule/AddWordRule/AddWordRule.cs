using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AddWordRule
{

    enum AddWordTypeEnum : int
    {
        ADD_PREFIX = 0,
        ADD_SUFFIX = 1,
    }


    public class AddWordRule : IRenameRule
    {

        public string Word { get; set; }
        public int Type { get; set; }

        public AddWordRule()
        {
            Type = (int)AddWordTypeEnum.ADD_PREFIX;
            Word = "";
        }

        public AddWordRule(string word, int type)
        {
            Word = word;
            Type = type;
        }


        public string MagicWord
        {
            get => "AddWord";
        }


        public IRenameRule Clone()
        {
            return new AddWordRule();
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
            string result = "";
            switch (Type)
            {
                case (int)AddWordTypeEnum.ADD_PREFIX:
                    {

                        result = $"{Word}{original}";

                        return result;
                    }
                case (int)AddWordTypeEnum.ADD_SUFFIX:
                    {
                        result = $"{original}{Word}";
                        return result;
                    }
                default:
                    return original;
            }

        }

        public string ShowDialog()
        {


            AddWordDialog addWordDialog = new AddWordDialog(Word, Type);


            addWordDialog.ParametersRuleChanged += AddWordDialog_ParametersRuleChanged; ;

            Window addWordWindow = new Window
            {
                Title = "AddWord",
                Content = addWordDialog,
                Width = 300,
                Height = 250
            };
            addWordWindow.ShowDialog();



            if (addWordWindow.DialogResult == true)
            {
                AddWordRuleToStringConverter addWordRuleToStringConverter = new AddWordRuleToStringConverter();


                string result = addWordRuleToStringConverter.convert(this);

                Word = "";
                Type = 0;
                
                return result;
            }
            return "";
        }

        private void AddWordDialog_ParametersRuleChanged(object sender, AddWordDialog.ParametersRuleChangedEventArgs e)
        {
            Word = e.Word;
            Type = e.Type;
        }
    }
}
