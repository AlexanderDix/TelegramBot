using System.Collections.Generic;
using TelegramBotUI.Models.Interfaces;

namespace TelegramBotUI.Models
{
    internal class Contact : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public ICollection<ContactMessage> Messages { get; set; } = new List<ContactMessage>();
    }
}