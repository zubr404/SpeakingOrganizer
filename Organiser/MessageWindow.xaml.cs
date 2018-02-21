using System.Windows;

namespace Organiser
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow()
        {
            InitializeComponent();
        }

        public void MessageSet(string _message)
        {
            MessageTextBlock.Text = _message;
        }
    }
}
