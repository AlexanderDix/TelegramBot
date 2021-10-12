using System;
using System.Collections.Generic;

namespace TelegramBot
{

    /// <summary>
    /// Класс для работы со списками, хранящими названия файлов
    /// </summary>
    public class ListFiles
    {
        public List<string> FileNames { get; set; }
        public List<string> PhotoNames { get; set; }
        public List<string> VoiceNames { get; set; }

        /// <summary>
        /// Название файла хранящего данные о файлах
        /// </summary>
        public readonly string FileName = "listfiles.json";

        public ListFiles()
        {
            FileNames = new List<string>();
            PhotoNames = new List<string>();
            VoiceNames = new List<string>();
        }

        /// <summary>
        /// Добавление названия файла в список
        /// </summary>
        /// <param name="fileName"></param>
        public void AddFileName(string fileName)
        {
            FileNames.Add(fileName);
        }

        /// <summary>
        /// Добавление названия фотографии в список
        /// </summary>
        /// <param name="photoName"></param>
        public void AddPhotoName(string photoName)
        {
            PhotoNames.Add(photoName);
        }

        /// <summary>
        /// Добавление названия голосовой в список
        /// </summary>
        /// <param name="voiceName"></param>
        public void AddVoiceName(string voiceName)
        {
            VoiceNames.Add(voiceName);
        }

    }
}
