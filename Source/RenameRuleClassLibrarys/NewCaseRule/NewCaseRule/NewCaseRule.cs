using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NewCaseRule
{

    enum NewCaseTypeEnum : int
    {
        UPPER = 0,
        LOWER = 1,
        PASCAL = 2,
    }


    public class NewCaseRule : IRenameRule
    {
        public int Type { get; set; }

        public NewCaseRule()
        {
            Type = (int)NewCaseTypeEnum.UPPER;
        }

        public NewCaseRule(int type)
        {
            Type = type;
        }

        public string MagicWord
        {
            get => "NewCase";
        }

        public IRenameRule Clone()
        {
            return new NewCaseRule();
        }

        public string ToString()
        {

            StringBuilder builder = new StringBuilder();

            builder.Append(MagicWord);
            builder.Append(" ");

            string type = "";

            switch (Type){
                case (int)NewCaseTypeEnum.UPPER:
                {
                        type = "To Upper";
                        break;
                }
                case (int)NewCaseTypeEnum.LOWER:
                {
                        type = "To Lower";
                        break;
                }
                case (int)NewCaseTypeEnum.PASCAL:
                    {
                        type = "To Pascal";
                        break;
                    }
                default:
                    type = "To Upper";
                    break;
            }

            builder.Append($"\"{Type}\"");

            string result = builder.ToString();
            return result;

        }

        public string Rename(string original)
        {
            string result = original;
            switch (Type)
            {
                case (int)NewCaseTypeEnum.UPPER:
                    {
                        result = result.ToUpper();

                        return result;
                    }
                case (int)NewCaseTypeEnum.LOWER:
                    {
                        result = result.ToLower();

                        return result;
                    }
                case (int)NewCaseTypeEnum.PASCAL:
                    {
                        //string partern = @"\s+";
                        //Regex trimmer = new Regex(partern);
                        //result = trimmer.Replace(result, "");                       

                        //Thay các kí tự đặc biệt thành 
                        Regex removeSpecialCharRegex = new Regex(@"[^a-zA-Z0-9]");
                        result = removeSpecialCharRegex.Replace(result, " ");

                        //In hoa các kí tự đầu
                        Regex upperFirstLetterWordRegex = new Regex(@"\s+.|^.");
                        result = upperFirstLetterWordRegex.Replace(result, m => " " + m.ToString().ToUpper());


                        //Xóa đi tất cả khoảng trắng
                        Regex trimmer = new Regex(@"\s+");
                        result = trimmer.Replace(result, "");


                        return result;
                    }
                default:
                    return original;
            }

        }

        public string ShowDialog()
        {


            NewCaseDialog newCaseDialog = new NewCaseDialog(Type);


            newCaseDialog.ParametersRuleChanged += NewCaseDialog_ParametersRuleChanged;

            Window newCaseWindow = new Window
            {
                Title = "NewCase",
                Content = newCaseDialog,
                Width = 300,
                Height = 250
            };
            newCaseWindow.ShowDialog();



            if (newCaseWindow.DialogResult == true)
            {
                NewCaseRuleToStringConverter newCaseRuleToStringConverter = new NewCaseRuleToStringConverter();


                string result = newCaseRuleToStringConverter.convert(this);
                Type = 0;
                
                return result;
            }
            return "";
        }

        private void NewCaseDialog_ParametersRuleChanged(object sender, NewCaseDialog.ParametersRuleChangedEventArgs e)
        {
            Type = e.Type;
        }
    }
}
