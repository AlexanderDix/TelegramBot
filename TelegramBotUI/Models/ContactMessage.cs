using System;
using TelegramBotUI.Models.Interfaces;

namespace TelegramBotUI.Models
{
    internal class ContactMessage : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}