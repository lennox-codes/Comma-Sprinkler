using Microsoft.Win32;
using System.IO;
using System.Text;

namespace Comma_Sprinkler
{
    internal class FileSystem
    {
        readonly VM vm = VM.Instance;

        private OpenFileDialog ofd = new OpenFileDialog();

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
                vm.FileName = ofd.FileName;
                vm.TextInput = File.ReadAllText(vm.FileName);
            }
        }
    }
}


