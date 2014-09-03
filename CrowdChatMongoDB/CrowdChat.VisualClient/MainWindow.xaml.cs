
namespace CrowdChat.VisualClient
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using CrowdChat.Data;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataPersister data;

        public MainWindow()
        {
            this.InitializeComponent();
            this.data = new DataPersister();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var username = this.Tb_Username.Text;
            this.data.RegisterUser(username);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var message = this.Tb_Message.Text;
            var user = this.data.GetCurrentUser();

            this.data.SendMessage(user, message);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var msgs = this.data.GetAllMessages().ToList();

            foreach (var m in msgs)
            {
                var mFormat = string.Format("[{0}] {1}: {2}", m.Date, m.Username.Username, m.Text);
                this.Lb_All_Messages.Items.Add(mFormat);
            }
        }
    }
}