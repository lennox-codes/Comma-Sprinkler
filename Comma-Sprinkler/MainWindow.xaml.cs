using System.Windows;

namespace Comma_Sprinkler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VM vm = VM.Instance;
        readonly FileSystem fs = new FileSystem();

        /*
        string testCase1 = "please sit spot. sit spot, sit. spot here now here.";
        string testCase2 = "one, two. one tree. four tree. four four. five four. six five.";
        string testCase3 = "please sit spot, spot sit.";
        string testCase4 = "please sit spot. sit spot, sit. spot spot here now here";
        */

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


