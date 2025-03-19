using Microsoft.Win32; // для работы с диалогами открытия и сохранения файлов
using System.IO; // Содержит классы для элементов управления
using System.Windows;
using System.Windows.Controls;

namespace TextEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow() // Конструктор класса
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) // обработчик события для "сохранить"
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*", // виды файлов
                Title = "Сохранить текстовый файл" // загаловок
            };

            if (saveFileDialog.ShowDialog() == true) 
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);// сохраниение
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Открыть текстовый файл"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //Обработчик события для изменения размера шрифта
        {
            if (fontSizeComboBox.SelectedItem is ComboBoxItem selectedItem) // получение элемента
            {
                if (int.TryParse(selectedItem.Content.ToString(), out int fontSize)) //преобразование в целое число
                {
                    textBox.FontSize = fontSize;
                }
            }
        }

        private void fontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedFont = selectedItem.Content.ToString(); //Извлекает текст шрифта
                textBox.FontFamily = new System.Windows.Media.FontFamily(selectedFont); // установка шрифта
            }
        }
    }
}