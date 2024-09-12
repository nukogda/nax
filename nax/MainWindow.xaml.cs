using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nax
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // XOR-шифрование
        private string XorCipher(string message, int key)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in message)
            {
                result.Append((char)(c ^ key));
            }

            return result.ToString();
        }

        // Обработка нажатия кнопки "Зашифровать"
        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string message = InputMessage.Text;
            if (int.TryParse(Key.Text, out int key))
            {
                string encryptedMessage = XorCipher(message, key);
                ResultText.Text = $"Зашифрованное сообщение: {encryptedMessage}";
            }
            else
            {
                MessageBox.Show("Введите корректный числовой ключ.");
            }
        }

        // Обработка нажатия кнопки "Расшифровать"
        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedMessage = InputMessage.Text;
            if (int.TryParse(Key.Text, out int key))
            {
                string decryptedMessage = XorCipher(encryptedMessage, key);
                ResultText.Text = $"Расшифрованное сообщение: {decryptedMessage}";
            }
            else
            {
                MessageBox.Show("Введите корректный числовой ключ.");
            }
        }
    }
}