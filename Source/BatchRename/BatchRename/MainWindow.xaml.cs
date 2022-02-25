using RenameRuleLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Forms;
using System.Diagnostics;

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<IRenameRule> rules = new List<IRenameRule>();
        BindingList<IRenameRule> actions = new BindingList<IRenameRule>();

        BindingList<File> fileList = new BindingList<File>();
        BindingList<Folder> folderList = new BindingList<Folder>();

        RenameRuleToStringConverterFactory renameRuleToStringConverterFactory = new RenameRuleToStringConverterFactory();
        RenameRuleParserFactory renameRuleParserFactory = new RenameRuleParserFactory();

        string currentPresetFile = "";


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenameRuleFactory renameRuleFactory = new RenameRuleFactory();
            rules = renameRuleFactory.getAllRule();
            ruleListCbBox.ItemsSource = rules;
            ruleListCbBox.SelectedIndex = 0;

            fileListView.ItemsSource = fileList;
            folderListView.ItemsSource = folderList;

            ActionListBox.ItemsSource = actions;

        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {

            int selectedTabIndex = FileFolderTab.SelectedIndex;

            // File
            if (selectedTabIndex == 0)
            {
                int selectApplyFor = applyForCbBox.SelectedIndex;

                switch (selectApplyFor)
                {
                    //case 1: Extension
                    case 1:
                        {
                            foreach (File file in fileList)
                            {
                                string newExtension = file.Extension;
                                foreach (IRenameRule action in actions)
                                {
                                    newExtension = action.Rename(newExtension);
                                }

                                if (!newExtension.Equals(file.Extension))
                                {
                                    string newName = file.SimpleName + newExtension;

                                    file.NewName = newName;

                                    string oldPath = file.Path;
                                    string oldName = file.OldName;

                                    string[] tokens = oldPath.Split(new string[] { oldName }, StringSplitOptions.None);

                                    string dirPath = tokens[0];
                                    string newPath = dirPath + newName;


                                    int x = 1;
                                    
                                    try
                                    {
                                        
                                        System.IO.File.Move(oldPath, newPath);
                                        file.BatchStatus = "SUCCESS";
                                    }
                                    catch(Exception ex)
                                    {
                                        Debug.WriteLine(ex.Message);
                                        file.BatchStatus = ex.Message;
                                    }

                                }




                            }
                            break;
                        }

                    //case 0 and Defaut: FileName Without Extension
                    default:
                        {
                            foreach (File file in fileList)
                            {
                                string newSimpleName = file.SimpleName;
                                foreach (IRenameRule action in actions)
                                {
                                    newSimpleName = action.Rename(newSimpleName);
                                }

                                if (!newSimpleName.Equals(file.SimpleName))
                                {
                                    string newName = newSimpleName + file.Extension;

                                    file.NewName = newName;

                                    string oldPath = file.Path;
                                    string oldName = file.OldName;

                                    string[] tokens = oldPath.Split(new string[] { oldName }, StringSplitOptions.None);

                                    string dirPath = tokens[0];
                                    string newPath = dirPath + newName;

                                    try
                                    {

                                        System.IO.File.Move(oldPath, newPath);
                                        file.BatchStatus = "SUCCESS";
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine(ex.Message);
                                        file.BatchStatus = ex.Message;
                                    }

                                }

                            }
                            break;
                        }
                }
            }
            //Folder
            else if (selectedTabIndex == 1)
            {
                foreach (Folder folder in folderList)
                {
                    string newName = folder.OldName;
                    foreach (IRenameRule action in actions)
                    {
                        newName = action.Rename(newName);
                    }
                    folder.NewName = newName;

                    string oldPath = folder.Path;
                    string oldName = folder.OldName;


                    string[] tokens = oldPath.Split(new string[] { oldName }, StringSplitOptions.None);

                    string dirPath = tokens[0];
                    string newPath = dirPath + newName;
                    try
                    {

                        System.IO.Directory.Move(oldPath, newPath);
                        folder.BatchStatus = "SUCCESS";
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        folder.BatchStatus = ex.Message;
                    }

                    


                }
            }

        }

        private void previewBtn_Click(object sender, RoutedEventArgs e)
        {

            int selectedTabIndex = FileFolderTab.SelectedIndex;

            // File
            if(selectedTabIndex == 0)
            {
                int selectApplyFor = applyForCbBox.SelectedIndex;
                switch (selectApplyFor)
                {
                    //case 1: Extension
                    case 1:
                        {
                            foreach (File file in fileList)
                            {
                                string newExtension = file.Extension;
                                foreach (IRenameRule action in actions)
                                {
                                    newExtension = action.Rename(newExtension);
                                }
                                file.NewName = file.SimpleName + newExtension;
                            }
                            break;
                        }

                    //case 0 and Defaut: FileName Without Extension
                    default:
                        {
                            foreach (File file in fileList)
                            {
                                string newSimpleName = file.SimpleName;
                                foreach (IRenameRule action in actions)
                                {
                                    newSimpleName = action.Rename(newSimpleName);
                                }
                                file.NewName = newSimpleName + file.Extension;
                            }
                            break;
                        }
                }
            }
            //Folder
            else if(selectedTabIndex == 1)
            {
                foreach (Folder folder in folderList)
                {
                    string newName = folder.OldName;
                    foreach (IRenameRule action in actions)
                    {
                        newName = action.Rename(newName);
                    }
                    folder.NewName = newName;
                }
            }    

        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {

            while(actions.Count > 0)
            {
                actions.RemoveAt(0);
            }    
            
                
            
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void openFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    File file = new File()
                    {
                        OldName = System.IO.Path.GetFileName(filename),
                        SimpleName = System.IO.Path.GetFileNameWithoutExtension(filename),
                        Extension = System.IO.Path.GetExtension(filename),
                        NewName = "",
                        Path = System.IO.Path.GetFullPath(filename),
                        BatchStatus = ""
                    };
                    fileList.Add(file);

                }
            }
        }

        private void openFolderBtn_Click(object sender, RoutedEventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            System.Windows.Forms.DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                string dirPath = folderBrowserDialog.SelectedPath + "\\";
                int dirPathLen = dirPath.Length;
                string[] folderPaths = Directory.GetDirectories(dirPath);

                foreach (string folderPath in folderPaths)
                {
  
                    string folderName = folderPath.Remove(0, dirPathLen);

                    Folder folder = new Folder()
                    {
                        OldName = folderName,
                        NewName = "",
                        Path = folderPath,
                        BatchStatus = ""
                    };
                    folderList.Add(folder);
                }

            }
        }

        private void editMenuItemBtn_Click(object sender, RoutedEventArgs e)
        {
            IRenameRule action = (IRenameRule)ActionListBox.SelectedItem;
            int index = ActionListBox.SelectedIndex;
             

            string lineInfor = action.ShowDialog();

            if (!lineInfor.Equals(""))
            {

                IRenameRuleParser renameRuleParser = renameRuleParserFactory.Create(action.MagicWord);

                actions[index] = renameRuleParser.Parse(lineInfor);
            }   



            //RenameRuleToStringUIConverterFactory renameRuleToStringUIConverterFactory = new RenameRuleToStringUIConverterFactory();

            //IRenameRuleToStringUIConverter renameRuleToStringUIConverter = renameRuleToStringUIConverterFactory.Create(action.MagicWord);

            //string x = renameRuleToStringUIConverter.convert(action);
            //string y = "1";
        }

        private void removeMenuItemBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = ActionListBox.SelectedIndex;
            actions.RemoveAt(index);

        }

        private void addMeThodBtn_Click(object sender, RoutedEventArgs e)
        {
            IRenameRule action = (IRenameRule)ruleListCbBox.SelectedItem;
            actions.Add(action);
        }

        private void savePreset_Click(object sender, RoutedEventArgs e)
        {

            //File Preset chưa tồn tại
            if(currentPresetFile.Equals(""))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentPresetFile = saveFileDialog.FileName;

                    string fileDetail = "";
                    foreach (IRenameRule action in actions)
                    {
                        IRenameRuleToStringConverter renameRuleToStringConverter = renameRuleToStringConverterFactory.Create(action.MagicWord);

                        string actionInfor = renameRuleToStringConverter.convert(action);
                        fileDetail += actionInfor + "\n";

                    }

                    System.IO.File.WriteAllText(currentPresetFile, fileDetail);

                    System.Windows.MessageBox.Show("Saved"); 
                }
            }
            //File Preset đã tồn tại
            else
            {
                string fileDetail = "";
                foreach (IRenameRule action in actions)
                {
                    IRenameRuleToStringConverter renameRuleToStringConverter = renameRuleToStringConverterFactory.Create(action.MagicWord);

                    string actionInfor = renameRuleToStringConverter.convert(action);
                    fileDetail += actionInfor + "\n";

                }

                System.IO.File.WriteAllText(currentPresetFile, fileDetail);
                System.Windows.MessageBox.Show("Saved");
            }    
        }

        private void loadPreset_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;

                actions.Clear();

                using (var reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        // Trích xuất từ đầu tiên để biết nên tạo ra luật gì
                        int firstSpaceIndex = line.IndexOf(" ");
                        string firstWord = "";
                        if (firstSpaceIndex > 0)
                        {
                            firstWord = line.Substring(0, firstSpaceIndex);
                        }
                        else
                        {
                            firstWord = line;
                        }

                        IRenameRuleParser parser = renameRuleParserFactory.Create(firstWord);
                        IRenameRule rule = parser.Parse(line);
                        actions.Add(rule);

                    }
                }
            }
        }

        private void saveAsPreset_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                currentPresetFile = saveFileDialog.FileName;

                string fileDetail = "";
                foreach (IRenameRule action in actions)
                {
                    IRenameRuleToStringConverter renameRuleToStringConverter = renameRuleToStringConverterFactory.Create(action.MagicWord);

                    string actionInfor = renameRuleToStringConverter.convert(action);
                    fileDetail += actionInfor + "\n";

                }

                System.IO.File.WriteAllText(currentPresetFile, fileDetail);
            }
        }

        private void clearFolderBtn_Click(object sender, RoutedEventArgs e)
        {
            folderList.Clear();
        }

        private void clearFileBtn_Click(object sender, RoutedEventArgs e)
        {
            fileList.Clear();
        }

        private void fileListView_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            {
                string[] filenames = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
                
                foreach (string filename in filenames)
                {
                    File file = new File()
                    {
                        OldName = System.IO.Path.GetFileName(filename),
                        SimpleName = System.IO.Path.GetFileNameWithoutExtension(filename),
                        Extension = System.IO.Path.GetExtension(filename),
                        NewName = "",
                        Path = System.IO.Path.GetFullPath(filename),
                        BatchStatus = ""
                    };
                    fileList.Add(file);
                }
            }
        }

    }
}
