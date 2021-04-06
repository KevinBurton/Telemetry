using PacketCommunication;
using System.Windows;

namespace CloudSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MainWindowViewModel();
            var server = new Server(mainViewModel.OnReceiveCallback);
            server.Start();
            DataContext = mainViewModel;
        }
    }
}
