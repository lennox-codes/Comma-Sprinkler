using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Text;
using System.Windows.Controls;

namespace Comma_Sprinkler
{
    internal class FileSystem
    {
        readonly VM vm = VM.Instance;      
        private OpenFileDialog ofd = new OpenFileDialog();
       
        public string TextInput { get; set; }

        public string FileName { get; set; }

        public StringBuilder Output { get; set; }

        public void OpenFileDialogForm()
        {
            ofd = new OpenFileDialog()
            {
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                Multiselect = false
            };

            bool? isSelected = ofd.ShowDialog();

            if (isSelected == true)
            {
                FileName = ofd.FileName;
                TextInput = File.ReadAllText(FileName);
            }
        }
    }
}


