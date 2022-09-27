using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

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

namespace TestPrinter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string csvFileData;
        string roxFileData;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void sendToPrinter(string message)
        {
            //TcpClient tcpClient = new TcpClient(new IPEndPoint(IPAddress.Parse(tbIP.Text), Convert.ToInt32(tbPort.Text)));
            //NetworkStream networkStream = tcpClient.GetStream();
            //networkStream.Write(Encoding.UTF8.GetBytes(message), 0, message.Length);
            //networkStream.Close();
            //tcpClient.Close();
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); ;
            socket.Connect(new IPEndPoint(IPAddress.Parse(tbIP.Text), Convert.ToInt32(tbPort.Text)));
            socket.Send(Encoding.UTF8.GetBytes(message));
            socket.Close();
        }
        private void bCSVAdd_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";
            ofd.ShowDialog();
            csvFileData = File.ReadAllText(ofd.FileName);
        }

        private void bROXConnect_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "ROX Files (*.rox)|*.rox";
            ofd.ShowDialog();
            roxFileData = File.ReadAllText(ofd.FileName);
        }

        private void bMerge_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
