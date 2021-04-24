using Microsoft.Win32;
using System.IO;
using System.Text;

namespace Comma_Sprinkler
{
    internal class FileSystem
    {
        readonly VM vm = VM.Instance;

        private OpenFileDialog ofd = new OpenFileDialog();

        public bool OpenFileDialogForm()
        {
            ofd = new OpenFileDialog()
            {
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                Multiselect = false,
                Title = "Browse Text Files"
                
            };

            bool? isSelected = ofd.ShowDialog();

            if (isSelected == true)
            {
                vm.FileName = ofd.FileName;
                vm.TextInput = File.ReadAllText(vm.FileName);
            }

            return (bool)isSelected;
        }
    }
}


