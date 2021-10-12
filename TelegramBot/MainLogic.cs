using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using File = System.IO.File;

namespace TelegramBot
{
    internal class MainLogic
    {
        #region Работа с голосовыми

        /// <summary>
        /// Скачать голосовую
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="voiceId">ID голосовой</param>
        public static async void DownloadVoice(long chatId, string voiceId)
        {
            var voice = await Tools.Bot.GetFileAsync(voiceId);
            var fileName = voice.FilePath.Split('/')[1];
            var filePath = "Files" + "\\" + fileName;

            Tools.ListFiles.AddVoiceName(fileName);
            Tools.Serialize();

            try
            {
                await using var saveVoice = File.Open(filePath, FileMode.Create);
                await Tools.Bot.DownloadFileAsync(voice.FilePath, saveVoice);

                await Tools.Bot.SendTextMessageAsync(chatId, "Голосовая сохранена");
            }
            catch (Exception)
            {
                await Tools.Bot.SendTextMessageAsync(chatId, "Ошибка сохранения голосовой");
            }
        }

        /// <summary>
        /// Показать список голосовых
        /// </summary>
        /// <param name="chatId"></param>
        public static async void ShowVoices(long chatId)
        {
            var text = new StringBuilder("Список голосовых:\n");

            foreach (var voiceName in Tools.ListFiles.VoiceNames.Skip(1))
            {
                text.AppendLine(voiceName);
            }

            await Tools.Bot.SendTextMessageAsync(chatId, text.ToString());
        }

        /// <summary>
        /// Выгрузить голосовые пользователю
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="voiceName"></param>
        public static async Task UploadVoice(long chatId, string voiceName)
        {
            var check = Tools.ListFiles.VoiceNames.Contains(voiceName);

            if (!check)
            {
                await Tools.Bot.SendTextMessageAsync(chatId, "Ошибка выгрузки, проверьте правильнотсь ввода");
                return;
            }

            await using var fStream = File.OpenRead("Files\\" + voiceName);

            var onlineFile = new InputOnlineFile(fStream, voiceName);

            await Tools.Bot.SendVoiceAsync(chatId, onlineFile);

            await Tools.Bot.SendTextMessageAsync(chatId, "Выгрузка завершена");
        }

        #endregion

        #region Работа с фотографиями

        /// <summary>
        /// Загрузить файл на компьютер
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="photoSizes">Массив размеров фотографии</param>
        public static async void DownloadPhoto(long chatId, PhotoSize[] photoSizes)
        {
            string fileId = null;

            foreach (var photoSize in photoSizes)
            {
                fileId = photoSize.FileId;
            }

            var photo = await Tools.Bot.GetFileAsync(fileId);
            var fileName = photo.FilePath.Split('/')[1];
            var filePath = "Files" + "\\" + fileName;

            Tools.ListFiles.AddPhotoName(fileName);
            Tools.Serialize();

            try
            {
                await using var savePhoto = File.Open(filePath, FileMode.Create);

                await Tools.Bot.DownloadFileAsync(photo.FilePath, savePhoto);

                await Tools.Bot.SendTextMessageAsync(chatId, "Фотография сохранена");
            }
            catch (Exception)
            {
                await Tools.Bot.SendTextMessageAsync(chatId, "Ошибка сохранения фотографии");
            }
        }

        /// <summary>
        /// Показать фотографии
        /// </summary>
        /// <param name="chatId">ID чата</param>
        public static async void ShowImages(long chatId)
        {
            var text = new StringBuilder("Список фотографий:\n");

            foreach (var photoName in Tools.ListFiles.PhotoNames.Skip(1))
            {
                text.AppendLine(photoName);
            }

            await Tools.Bot.SendTextMessageAsync(chatId, text.ToString());
        }

        /// <summary>
        /// Выгрузить фотографию пользователю
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="photoName">Название фотографии</param>
        /// <returns></returns>
        public static async Task UploadPhoto(long chatId, string photoName)
        {
            var check = Tools.ListFiles.PhotoNames.Contains(photoName);

            if (!check)
            {
                await Tools.Bot.SendTextMessageAsync(chatId, "Ошибка выгрузки, проверьте имя фотографии");
                return;
            }

            await using var fStream = File.OpenRead("Files\\" + photoName);

            var onlineFile = new InputOnlineFile(fStream, photoName);

            await Tools.Bot.SendPhotoAsync(chatId, onlineFile);

            await Tools.Bot.SendTextMessageAsync(chatId, "Выгрузка завершена");
        }

        #endregion

        #region Работа с файлами

        /// <summary>
        /// Показать файлы
        /// </summary>
        /// <param name="chatId">ID чата</param>
        public static async void ShowFiles(long chatId)
        {
            var text = new StringBuilder("Список файлов:\n");

            if (Tools.ListFiles.FileNames != null)
                foreach (var fileName in Tools.ListFiles.FileNames.Skip(1))
                {
                    text.AppendLine(fileName);
                }

            await Tools.Bot.SendTextMessageAsync(chatId, text.ToString());
        }

        /// <summary>
        /// Загрузка документа на компьютер
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="document">Документ</param>
        public static async void DownloadFile(long chatId, Document document)
        {
            var file = await Tools.Bot.GetFileAsync(document.FileId);
            var fileName = document.FileName;
            var filePath = "Files" + "\\" + fileName;

            Tools.ListFiles.AddFileName(fileName);
            Tools.Serialize();

            try
            {
                await using var saveDocument = File.Open(filePath, FileMode.Create);

                await Tools.Bot.DownloadFileAsync(file.FilePath, saveDocument);

                await Tools.Bot.SendTextMessageAsync(chatId, "Документ сохранен на диск");
            }
            catch (Exception)
            {
                await Tools.Bot.SendTextMessageAsync(chatId, "Ошибка сохранения документа");
            }
        }

        /// <summary>
        /// Выгрузить файл в чат пользователем
        /// </summary>
        /// <param name="chatId">ID чат</param>
        /// <param name="message">Сообщение</param>
        /// <returns></returns>
        public static async Task UploadFile(long chatId, string message)
        {
            if (!Tools.ListFiles.FileNames.Contains(message))
            {
                await Tools.Bot.SendTextMessageAsync(chatId, "Ошибка выгрузки, проверьте имя файла");
                return;
            }

            await using var fStream = File.OpenRead("Files\\" + message);

            var onlineFile = new InputOnlineFile(fStream, message);

            await Tools.Bot.SendDocumentAsync(chatId, onlineFile);

            await Tools.Bot.SendTextMessageAsync(chatId, "Выгрузка завершена");
        }

        #endregion


        /// <summary>
        /// Выдаем сообщение при вводе текста, не относящегося к командам
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="messageId">ID сообщения</param>
        /// <returns></returns>
        public static async Task DefaultMessage(long chatId, int messageId)
        {
            await Tools.Bot.SendTextMessageAsync(chatId,
                "Не понимаю вашу команду",
                replyToMessageId: messageId,
                replyMarkup: new ReplyKeyboardRemove());
        }
    }
}
