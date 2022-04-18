using System.IO;
using TelegramBotUI.Services.Interfaces;

namespace TelegramBotUI.Services
{
    internal class TokenService
    {
        private readonly IUserDialog _userDialog;

        public string GetToken()
        {
            string data = null;

            _userDialog.OpenFile("Выбор файла с токеном", out var selectedFile);

            using StreamReader sReader = new(selectedFile);

            while (!sReader.EndOfStream) data = sReader.ReadLine();

            return data;
        }

        public TokenService(IUserDialog userDialog)
        {
            _userDialog = userDialog;
        }
    }
}