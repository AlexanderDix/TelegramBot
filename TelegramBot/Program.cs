using System;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace TelegramBot
{
    internal class Program
    {
        [Obsolete]
        private static void Main()
        {
            Tools.Init();

            Console.WriteLine("Старт");

            Tools.Bot.StartReceiving();
            Tools.Bot.OnMessage += Bot_OnMessage;

            Console.ReadKey();

            Tools.Bot.StopReceiving();

            Console.WriteLine("Конец");
        }

        /// <summary>
        /// Обработка сообщений от пользователя
        /// </summary>
        [Obsolete]
        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"Type: {e.Message.Type}");
            var chatId = e.Message.Chat.Id;
            var messageId = e.Message.MessageId;

            switch (e.Message.Type)
            {
                case MessageType.Document:
                    {
                        var document = e.Message.Document;
                        MainLogic.DownloadFile(chatId, document);
                        return;
                    }
                case MessageType.Photo:
                    {
                        var photo = e.Message.Photo;
                        MainLogic.DownloadPhoto(chatId, photo);
                        return;
                    }
                case MessageType.Voice:
                    {
                        var voiceId = e.Message.Voice.FileId;
                        var voice = await Tools.Bot.GetFileAsync(voiceId);

                        Console.WriteLine($"{voice.FilePath}");
                        MainLogic.DownloadVoice(chatId, voiceId);
                        return;
                    }
                case MessageType.Sticker:
                    return;
            }

            if (e.Message.Text.StartsWith("/uploadfile("))
            {
                var fileName = e.Message.Text.Split('(')[1].Split(')')[0];
                await MainLogic.UploadFile(chatId, fileName);
                return;
            }

            if (e.Message.Text.StartsWith("/uploadphoto("))
            {
                var photoName = e.Message.Text.Split('(')[1].Split(')')[0];
                await MainLogic.UploadPhoto(chatId, photoName);
                return;
            }

            if (e.Message.Text.StartsWith("/uploadvoice("))
            {
                var voiceName = e.Message.Text.Split('(')[1].Split(')')[0];
                await MainLogic.UploadVoice(chatId, voiceName);
                return;
            }

            switch (e.Message.Text)
            {
                case "/start":
                    await Tools.Bot.SendTextMessageAsync(chatId, "Старт бота");
                    return;
                case "/files":
                    MainLogic.ShowFiles(chatId);
                    return;
                case "/images":
                    MainLogic.ShowImages(chatId);
                    return;
                case "/voices":
                    MainLogic.ShowVoices(chatId);
                    return;
                default:
                    await MainLogic.DefaultMessage(chatId, messageId);
                    break;
            }
        }
    }
}
