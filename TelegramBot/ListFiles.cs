using System;
using System.Collections.Generic;

namespace TelegramBot
{
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

        public void AddFileName(string fileName)
        {
            FileNames.Add(fileName);
        }

        public void AddPhotoName(string photoName)
        {
            PhotoNames.Add(photoName);
        }

        public void AddVoiceName(string voiceName)
        {
            VoiceNames.Add(voiceName);
        }

    }
}
