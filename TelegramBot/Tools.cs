using System.IO;
using Newtonsoft.Json;
using Telegram.Bot;

namespace TelegramBot
{
    internal class Tools
    {
        public static TelegramBotClient Bot;
        public static ListFiles ListFiles;

        /// <summary>
        /// Инициализация
        /// </summary>
        public static void Init()
        {
            Bot = new TelegramBotClient(Configuration.BotToken);
            ListFiles = new ListFiles();

            Deserialize();
        }

        /// <summary>
        /// Создание и заполнение файла при его отсутствии
        /// </summary>
        private static void CreateFile()
        {
            const string name = "test.test";

            ListFiles.AddFileName(name);
            ListFiles.AddPhotoName(name);
            ListFiles.AddVoiceName(name);

            var json = JsonConvert.SerializeObject(ListFiles);
            File.AppendAllText(ListFiles.FileName, json);
        }

        /// <summary>
        /// Десериализация файлов
        /// </summary>
        public static void Deserialize()
        {
            if (!File.Exists(ListFiles.FileName)) CreateFile();

            var json = File.ReadAllText(ListFiles.FileName);
            ListFiles = JsonConvert.DeserializeObject<ListFiles>(json);
        }

        /// <summary>
        /// Сериализация файлов
        /// </summary>
        public static void Serialize()
        {
            File.Delete(ListFiles.FileName);

            var json = JsonConvert.SerializeObject(ListFiles);
            File.AppendAllText(ListFiles.FileName, json);
        }
    }
}
