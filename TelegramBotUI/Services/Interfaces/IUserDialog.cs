namespace TelegramBotUI.Services.Interfaces
{
    internal interface IUserDialog
    {
        bool OpenFile(string title, out string selectedFile,
            string filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*");

        void Information(string title, string message);

        void Warning(string title, string message);

        void Error(string title, string message);
    }
}