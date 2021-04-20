using Microsoft.Win32;
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

namespace Comma_Sprinkler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = VM.Instance;
        FileSystem fs = new FileSystem();

        string testCase1 = "please sit spot. sit spot, sit. spot here now here.";
        string testCase2 = "one, two. one tree. four tree. four four. five four. six five.";
        string testCase3 = "please sit spot, spot sit.";
        string testCase4 = "please sit spot. sit spot, sit. spot spot here now here";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            fs.OpenFileDialogForm();
            vm.SprinkleComma(vm.TextInput);
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}


