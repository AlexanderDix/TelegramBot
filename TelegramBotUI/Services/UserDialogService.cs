using System.Windows;
using Microsoft.Win32;
using TelegramBotUI.Services.Interfaces;

namespace TelegramBotUI.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool OpenFile(string title, out string selectedFile,
            string filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*")
        {
            var fileDialog = new OpenFileDialog
            {
                Title = title,
                Filter = filter
            };

            if (fileDialog.ShowDialog() != true)
            {
                selectedFile = null;
                return false;
            }

            selectedFile = fileDialog.FileName;

            return true;
        }

        public void Information(string title, string message) =>
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);

        public void Warning(string title, string message) =>
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);

        public void Error(string title, string message) =>
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
    }
}